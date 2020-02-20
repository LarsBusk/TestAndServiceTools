using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FindInFIles
{
  public partial class Form1 : Form
  {
    private string folderToSearch;
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
        findButton.Enabled = true;
      }
    }

    private void findButton_Click(object sender, EventArgs e)
    {
      string[] fileNames = Directory.GetFiles(folderToSearch);
      richTextBoxRes.Clear();

      foreach (var fileName in fileNames)
      {
        int numberOfInstances = File.ReadAllLines(fileName).Count(l => l.Contains(searchTextBox.Text));

        if (numberOfInstances > 0)
        {
          richTextBoxRes.AppendText($"{fileName} contains text {numberOfInstances} times. \n");
        }
      }
    }
  }
}
