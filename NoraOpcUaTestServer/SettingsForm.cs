using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using NoraOpcUaTestServer.OpcNodes;

namespace NoraOpcUaTestServer
{
  public partial class SettingsForm : Form
  {
    public SettingsForm()
    {
      InitializeComponent();
    }

    private void SettingsForm_Load(object sender, EventArgs e)
    {
      serverTextBox.Text = MainForm.ServerName;
      rootFolderTextBox.Text = MainForm.RootFolderName;
      nodeSeparatorTextBox.Text = NodeBase.NodeSeparator;
      opcNamespaceTextBox.Text = NodeBase.OpcNameSpace;
    }

    private void cancelButton_Click(object sender, EventArgs e)
    {
      this.Close();
    }

    private void saveButton_Click(object sender, EventArgs e)
    {
      MainForm.RootFolderName = rootFolderTextBox.Text;
      NodeBase.NodeSeparator = nodeSeparatorTextBox.Text;
      NodeBase.OpcNameSpace = opcNamespaceTextBox.Text;
      MainForm.ServerName = serverTextBox.Text;
      this.Close();
    }
  }
}
