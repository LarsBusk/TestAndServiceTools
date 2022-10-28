using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.Design;

namespace FindInFIles
{
  public partial class Form1 : Form
  {
    private string folderToSearch
    {
      get => folder;
      set
      {
        folder = value; 
        AppendTextToRtb($"{folderToSearch}\n");
      }
    }

    private string folder;

    private delegate void AppendRichTextBoxCallBack(string text);

    private delegate void UpdateProgressCallback(int total, int actual, string fileName);

    private delegate void UpdateProgressBarCallback(int actual);
    public Form1()
    {
      InitializeComponent();
    }

    private void FolderButton_Click(object sender, EventArgs e)
    {
      FolderBrowserDialog dialog = new FolderBrowserDialog();

      if (dialog.ShowDialog() != DialogResult.Cancel)
      {
        folderToSearch = dialog.SelectedPath;
      }
    }

    private void findButton_Click(object sender, EventArgs e)
    {
      if (string.IsNullOrEmpty(folderToSearch) || string.IsNullOrEmpty(searchComboBox.Text)) return;
      string lookFor = searchComboBox.Text;
      new Thread(() => DisplayFindings(lookFor)).Start();
    }

    private void DisplayFindings(string lookFor)
    {
      string[] fileNames = Directory.GetFiles(folderToSearch);
      int numFiles = fileNames.Length;

      for (int i = 0; i < numFiles; i++)
      {
        string fileName = Path.GetFileName(fileNames[i]);
        UpdateStatus(numFiles, i + 1, fileName);
        int numberOfInstances = File.ReadAllLines(fileNames[i]).Where(l => l.Contains(lookFor)).Count(); 

        if (numberOfInstances > 0)
        {
          AppendTextToRtb($"{fileName} contains {lookFor} {numberOfInstances} times. \n");
        }
      }
    }

    private void DisplayGreatestTimeSpan()
    {
      string[] filesToSearch = new[]
      {
        "CleanupLog", "LineScanProcessing", "Nova_Client", "NovaOperatorActions", "OnTopManager", "ServerHost",
        "SampleCache", "ServiceManager", "WatchDog", "XRayManager", "InstrumentTrace", "StateMachine"
      };

      string[] fileNames = Directory.GetFiles(folderToSearch).Where(f => f.Contains("txt") && filesToSearch.Any(s => f.Contains(s))).ToArray();
      int numFiles = fileNames.Length;

      for (int i = 0; i < numFiles; i++)
      {
        string fileName = Path.GetFileName(fileNames[i]);
        UpdateStatus(numFiles, i + 1, fileName);
        Tuple<TimeSpan, int> longesTimeSpan = FindGreatestTimeSpan(fileNames[i]);
        AppendTextToRtb($"The longest time between lines in {fileName} is: {longesTimeSpan.Item1} in line {longesTimeSpan.Item2}. \n");
      }

      UpdateProgressBar(0);
    }

    private Tuple<TimeSpan, int> FindGreatestTimeSpan(string fileName)
    {
      string[] lines = File.ReadAllLines(fileName);
      TimeSpan maxTimeSpan = TimeSpan.Zero;
      DateTime lineDateTime = LineDateTime(lines[0]);
      int numLines = lines.Length;
      int lineNo = 0;

      for (int i = 1; i < numLines; i++)
      {
        var nextLineTime = LineDateTime(lines[i]);
        var timeSpan = lineDateTime.Equals(DateTime.MinValue) ? TimeSpan.MinValue : nextLineTime - lineDateTime;

        if (timeSpan > maxTimeSpan)
        {
          maxTimeSpan = timeSpan;
          lineNo = i;
        }

        lineDateTime = nextLineTime;

        if (i % 100 ==0)
        {
          UpdateProgressBar(100* i / numLines);
        }

        
      }

      return new Tuple<TimeSpan, int>(maxTimeSpan, lineNo);
    }

    private DateTime LineDateTime(string resultLine)
    {
      DateTimeFormatInfo dtInfo = new DateTimeFormatInfo();
      dtInfo.FullDateTimePattern = "yyyy-MM-dd hh:mm:ss,fff";
      DateTime resultDateTime = DateTime.MinValue;

      if (string.IsNullOrEmpty(resultLine)) return resultDateTime;

      string[] lineParts = resultLine.Split(' ');
      string dtString = $"{lineParts[0]} {lineParts[1]}";


      try
      {
        resultDateTime = DateTime.ParseExact(dtString, "yyyy-MM-dd HH:mm:ss,fff", dtInfo);
      }
      catch (Exception e)
      {
      }

      return resultDateTime;
    }

    private void Form1_DragDrop(object sender, DragEventArgs e)
    {
      var s = e.Data.GetData(DataFormats.FileDrop);
      folderToSearch = ((string[])s)[0];
    }

    private void Form1_DragEnter(object sender, DragEventArgs e)
    {
      if (e.Data.GetDataPresent(DataFormats.FileDrop))
        e.Effect = DragDropEffects.Copy;
      else
        e.Effect = DragDropEffects.None;
    }

    private void AppendTextToRtb(string text)
    {
      if (richTextBoxRes.InvokeRequired)
      {
        AppendRichTextBoxCallBack d = new AppendRichTextBoxCallBack(AppendTextToRtb);
        this.Invoke(d, new object[] { text });
        return;
      }

      richTextBoxRes.AppendText(text); 
    }

    private void UpdateStatus(int total, int actual, string fileName)
    {
      if (statusLabel.InvokeRequired)
      {
        UpdateProgressCallback d = new UpdateProgressCallback(UpdateStatus);
        this.Invoke(d, new object[] {total, actual, fileName});
        return;
      }

      statusLabel.Text = $"Searching {fileName} {actual} of {total}";
    }

    private void UpdateProgressBar( int actual)
    {
      if (statusLabel.InvokeRequired)
      {
        UpdateProgressBarCallback d = new UpdateProgressBarCallback(UpdateProgressBar);
        this.Invoke(d, new object[] { actual});
        return;
      }

      progressBar1.Value = actual;
    }



    private void findTimeSpanButton_Click(object sender, EventArgs e)
    {
      if (!string.IsNullOrEmpty(folderToSearch) )
      {
        new Thread(DisplayGreatestTimeSpan).Start();
      }
    }
  }
}
