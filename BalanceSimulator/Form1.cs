using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace BalanceSimulator
{
  public partial class Form1 : Form
  {
    private SerialHelper helper;
    private Logger log;

    public Form1()
    {
      InitializeComponent();
    }

    private void Form1_Load(object sender, EventArgs e)
    {
      helper = new SerialHelper();
      log = new Logger();
      serialsComboBox.Items.AddRange(helper.AvailablePorts());
    }

    private void connectButton_Click(object sender, EventArgs e)
    {
      helper.Serial.PortName = serialsComboBox.Text;
      helper.Serial.Open();
      helper.Serial.DataReceived += Serial_DataReceived;
    }

    private void Serial_DataReceived(object sender, System.IO.Ports.SerialDataReceivedEventArgs e)
    {
      string receivedText = helper.Serial.ReadExisting();
      receivedText = Regex.Replace(receivedText, "\x1B", "{ESC}", RegexOptions.IgnoreCase);
      receivedText = Regex.Replace(receivedText, "\r", "{CR}", RegexOptions.IgnoreCase);
      receivedText = Regex.Replace(receivedText, "\n", "{LF}", RegexOptions.IgnoreCase);
      richTextBox1.AppendText($"{receivedText}\n");
      log.LogInfo(receivedText);
      helper.SendWeight();
    }

    private void disconnectButton_Click(object sender, EventArgs e)
    {
      helper.Serial.Close();
    }
  }
}
