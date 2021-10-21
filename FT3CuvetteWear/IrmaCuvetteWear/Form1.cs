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

namespace IrmaCuvetteWear
{
  public partial class Form1 : Form
  {
    private LogFileHelper helper;
    private delegate void SetProgressCallback(int progress);

    private delegate void SetStateLabelCallback(string state);


    public Form1()
    {
      InitializeComponent();
      helper = new LogFileHelper();
      helper.ProgressEvent += Helper_ProgressEvent;
    }

    private void Helper_ProgressEvent(object sender, ProgressEventArgs e)
    {
      SetProgress(e.Progress);
      UpdateStatusLabel(e.State);
    }

    private void browseButton_Click(object sender, EventArgs e)
    {
      FolderBrowserDialog dialog = new FolderBrowserDialog();

      if (!dialog.ShowDialog().Equals(DialogResult.Cancel))
      {
        string
          folder = dialog
            .SelectedPath; 
        new Thread(() => helper.CreateCsvFile(folder)).Start();
      }
    }

    private void Form1_DragDrop(object sender, DragEventArgs e)
    {
      var s = e.Data.GetData(DataFormats.FileDrop);
      string name = ((string[])s)[0];
      new Thread(() => helper.CreateCsvFile(name)).Start();
    }

    private void Form1_DragEnter(object sender, DragEventArgs e)
    {
      if (e.Data.GetDataPresent(DataFormats.FileDrop))
        e.Effect = DragDropEffects.Copy;
      else
        e.Effect = DragDropEffects.None;
    }

   
    private void SetProgress(int progress)
    {
      if (progressBar.InvokeRequired)
      {
        SetProgressCallback d = new SetProgressCallback(SetProgress);
        this.Invoke(d, new object[] { progress });
        return;
      }

      progressBar.Value = progress;
    }

    private void UpdateStatusLabel(string state)
    {
      if (labelState.InvokeRequired)
      {
        SetStateLabelCallback d = new SetStateLabelCallback(UpdateStatusLabel);
        this.Invoke(d, new object[] { state });
        return;
      }

      labelState.Text = state;
    }
  }
}
