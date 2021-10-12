using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IrmaCuvetteWear
{
  public partial class Form1 : Form
  {
    
    private string folderName;
    public Form1()
    {
      InitializeComponent();
    }

    private void browseButton_Click(object sender, EventArgs e)
    {
        FolderBrowserDialog dialog = new FolderBrowserDialog();

        if (!dialog.ShowDialog().Equals(DialogResult.Cancel))
        {
          string folder = dialog.SelectedPath;// "C:\\Users\\lab\\Projects\\GitHub\\TestAndServiceTools\\FT3CuvetteWear\\NovaLogs";
          CreateCsvFile(folder);
        }
    }

    private void CreateCsvFile(string folder)
    {
      //string folder = dialog.SelectedPath;// "C:\\Users\\lab\\Projects\\GitHub\\TestAndServiceTools\\FT3CuvetteWear\\NovaLogs";
      var hostFiles = ServerHostfiles(folder);
      var info = CuvetteLines(hostFiles);
      SaveToCsv(info);
    }

    private List<string> ServerHostfiles(string folder)
    {
      var files = Directory.GetFiles(folder).Where(f => f.Contains("IrmaDairyServerHost"));
      return files.ToList();
    }

    private List<WearInfo> CuvetteLines(List<string> files)
    {
      List<WearInfo> wearInfos= new List<WearInfo>();
      foreach (var logFile in files)
      {
        var lines = File.ReadAllLines(logFile).Where(l => l.Contains("Updating the SBRef average."));
        foreach (var line in lines)
        {
          wearInfos.Add(GetWearInfo(line));
        }
      }

      wearInfos.Sort();
      return wearInfos;
    }

    private WearInfo GetWearInfo(string logLine)
    {
      string[] lineParts = logLine.Split(' ');
      var info = new WearInfo();
      info.Date = lineParts[0];
      info.Time = lineParts[1];
      string correctionPart = lineParts.First(lp => lp.StartsWith("intensityCorrection"));
      info.Correction = correctionPart.Split('=')[1];

      return info;
    }

    private void SaveToCsv(List<WearInfo> infos)
    {
      List<string> csvLines = new List<string>();
      csvLines.Add("Date;Time;Correction");
      foreach (var wearInfo in infos)
      {
        csvLines.Add(wearInfo.ToString());
      }

      File.WriteAllLines("WearLog.csv", csvLines);
    }

    private void Form1_DragDrop(object sender, DragEventArgs e)
    {
      var s = e.Data.GetData(DataFormats.FileDrop);
      string name = ((string[])s)[0];
      CreateCsvFile(name);
    }

    private void Form1_DragEnter(object sender, DragEventArgs e)
    {
      if (e.Data.GetDataPresent(DataFormats.FileDrop))
        e.Effect = DragDropEffects.Copy;
      else
        e.Effect = DragDropEffects.None;
    }

    private void dropTextBox_DragEnter(object sender, DragEventArgs e)
    {
      if (e.Data.GetDataPresent(DataFormats.FileDrop))
        e.Effect = DragDropEffects.Copy;
      else
        e.Effect = DragDropEffects.None;
    }

    private void dropTextBox_DragDrop(object sender, DragEventArgs e)
    {
      var s = e.Data.GetData(DataFormats.FileDrop);
      string name = ((string[]) s)[0];
      CreateCsvFile(name);
    }

    private void Form1_Load(object sender, EventArgs e)
    {
      label4.Text = CultureInfo.CurrentCulture.DisplayName;
    }
  }
}
