using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using NoraOpcUaTestServer.States;
using Opc.UaFx;
using Timer = System.Windows.Forms.Timer;

namespace NoraOpcUaTestServer
{
  public partial class MainForm : Form
  {
    public static string RootFolderName = "Foss";
    public static string ServerName = Properties.Settings.Default.ServerName;
    private OpcUaHelper helper;
    private CsvHelper2 csvHelper = new CsvHelper2("States.txt");

    #region Private delegates

    private delegate void SetStartStopButtonTextCallback(string text);

    private delegate void UpdateLabelTextCallback(Label label, string text);

    private delegate void UpdateButtonStateCallback(Button button, bool enabled);

    private delegate void AppendToRichTextBoxDelegate(string text);

    #endregion


    private IState currentState
    {
      get => state;
      set
      {
        state = value;
        UpdateLabelText(stateLabel, $"State: {state.StateName}");
      }
    }

    private IState state;


    public MainForm()
    {
      InitializeComponent();
      Initialise();
    }

    #region EventHandlers

    private void FatValue_AfterApplyChanges(object sender, OpcNodeChangesEventArgs e)
    {
      var node = (OpcDataVariableNode<double>) sender;
      double fatValue = node.Value;
      UpdateLabelText(fatLabel, $"Fat: {fatValue.ToString("#.###")} {helper.FatUnit}");
    }

    private void ProductName_AfterApplyChanges(object sender, OpcNodeChangesEventArgs e)
    {
      var node = (OpcDataVariableNode<string>) sender;
      string product = node.Value;
      UpdateLabelText(productLabel, $"Product: {product}");
    }

    private void HeartbeatNode_AfterApplyChanges(object sender, OpcNodeChangesEventArgs e)
    {
      var node = (OpcDataVariableNode<uint>) sender;
      string beat = node.Value.ToString();
      UpdateLabelText(heartBeatLabel, beat);
    }

    private void EventsCount_AfterApplyChanges(object sender, OpcNodeChangesEventArgs e)
    {
      var node = (OpcDataVariableNode<uint>)sender;
      uint count = node.Value;

      if (count > 0)
      {
        HandleEvents();
      }
    }

    private void StateNode_AfterApplyChanges(object sender, Opc.UaFx.OpcNodeChangesEventArgs e)
    {
      var args = e;
      var state = e.Changes;
      var node = (OpcDataVariableNode<string>) sender;
      string noraState = node.Value;
      csvHelper.WriteValues($"Type: {state} New state: {noraState}");
      AppendToRichTextBox(noraState);

      switch (noraState)
      {
        case "Measuring":
          currentState = new StateNoraMeasuring(helper);
          SetStartStopButtonText("Stop");
          break;
        case "Stopped":
          currentState = new StateNoraStopped(helper);
          SetStartStopButtonText("Start");
          break;
        case "Zeroing":
          currentState = new StateNoraZeroing(helper);
          break;
        case "ManualCleaning":
          currentState = new StateNoraCleaning(helper);
          break;
        case "PrepareMeasuring":
          currentState = new StateNoraPreparing(helper);
          break;
        case "ProcessCleaning":
          currentState = new StateNoraCleaning(helper);
          break;
      }
    }


    private void Server_StateChanged(object sender, Opc.UaFx.Server.OpcServerStateChangedEventArgs e)
    {
      string mes = e.NewState.ToString();
      AppendToRichTextBox(mes);
      serverStateLabel.Text = mes;

      switch (mes)
      {
        case "Started":
          currentState = new StateServerStarted(helper);
          break;
        case "Stopped":
          currentState = new StateServerStopped(helper);
          break;
      }
    }

    #endregion EventHandlers

    #region Ui Events

    private void startButton_Click(object sender, EventArgs e)
    {
      currentState.StartServer();
    }

    private void stopButton_Click(object sender, EventArgs e)
    {
      currentState.StopServer();
    }

    private void button1_Click(object sender, EventArgs e)
    {
      if (helper == null) return;

      var nodes = helper.Server.DefaultNodeManager.Nodes;
      richTextBox1.Clear();
      foreach (var node in nodes)
      {
        richTextBox1.AppendText($"{node.Id}\n");
      }
    }

    private void startStopButton_Click(object sender, EventArgs e)
    {
      currentState.StartStopMeasuring(productTextBox.Text);
    }

    private void cipButton_Click(object sender, EventArgs e)
    {
      //helper.SetCip();
    }

    private void productTextBox_TextChanged(object sender, EventArgs e)
    {
      currentState.ChangeProduct(productTextBox.Text);
    }

    private void zeroButton_Click(object sender, EventArgs e)
    {
      currentState.StartZero();
    }

    private void cleanButton_Click(object sender, EventArgs e)
    {
      currentState.StartRinse();
    }

    private void settingsToolStripMenuItem1_Click(object sender, EventArgs e)
    {
      currentState.OpenSettings();
    }

    private void exitToolStripMenuItem_Click(object sender, EventArgs e)
    {
      if (helper != null)
      {
        currentState.StopServer();
      }

      this.Close();
    }

    #endregion Ui Events

    private void Initialise()
    {
      helper = new OpcUaHelper(ServerName, RootFolderName);
      helper.Server.StateChanged += Server_StateChanged;
      helper.StateNode.AfterApplyChanges += StateNode_AfterApplyChanges;
      helper.HeartbeatNode.AfterApplyChanges += HeartbeatNode_AfterApplyChanges;
      helper.ProductName.AfterApplyChanges += ProductName_AfterApplyChanges;
      helper.FatValue.AfterApplyChanges += FatValue_AfterApplyChanges;
      helper.EventsCount.AfterApplyChanges += EventsCount_AfterApplyChanges;
      currentState = new StateServerStopped(helper);
    }


    private void HandleEvents()
    {
      richTextBox1.Clear();
      foreach (var eventMessage in helper.EventMessages)
      {
        richTextBox1.AppendText($"{eventMessage}\n");
      }
    }

    #region Updaters

    private void SetStartStopButtonText(string text)
    {
      if (stateLabel.InvokeRequired)
      {
        SetStartStopButtonTextCallback d = new SetStartStopButtonTextCallback(SetStartStopButtonText);
        this.Invoke(d, new object[] {text});
        return;
      }

      startStopButton.Text = text;
    }

    private void UpdateLabelText(Label label, string text)
    {
      if (stateLabel.InvokeRequired)
      {
        UpdateLabelTextCallback d = new UpdateLabelTextCallback(UpdateLabelText);
        this.Invoke(d, new object[] {label, text});
        return;
      }

      label.Text = text;
    }

    private void AppendToRichTextBox(string text)
    {
      if (richTextBox1.InvokeRequired)
      {
        AppendToRichTextBoxDelegate d = AppendToRichTextBox;
        this.Invoke(d, new object[] {text});
        return;
      }

      richTextBox1.AppendText($"{DateTime.Now}: {text}\n");
      richTextBox1.ScrollToCaret();
    }

    private void UpdateButtonState(Button button, bool enabled)
    {
      if (stateLabel.InvokeRequired)
      {
        UpdateButtonStateCallback d = new UpdateButtonStateCallback(UpdateButtonState);
        this.Invoke(d, new object[] {button, enabled});
        return;
      }

      button.Enabled = enabled;
    }

    #endregion

  }
}
