using NoraOpcUaTestServer.States;
using Opc.UaFx;
using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace NoraOpcUaTestServer
{
    public partial class MainForm : Form
    {
        public static string RootFolderName = "Foss.Nora";
        public static string ServerName = Properties.Settings.Default.ServerName;
        private OpcUaHelper helper;
        private readonly Logger statesLogger = new Logger("States.txt");
        private bool forceMeasure;

        #region Private delegates

        private delegate void SetStartStopButtonTextCallback(string text);

        private delegate void UpdateLabelTextCallback(Label label, string text);

        private delegate void AppendToRichTextBoxDelegate(string text);

        #endregion


        private IState CurrentState
        {
            get => currentState;
            set
            {
                currentState = value;
                currentState.ForceMeasure = forceMeasure;
                UpdateLabelText(stateLabel, $"State: {currentState.StateName}");
            }
        }

        private IState currentState;


        public MainForm()
        {
            InitializeComponent();
            Initialise();
        }

        #region EventHandlers

        private void SampleCounter_AfterApplyChanges(object sender, OpcNodeChangesEventArgs e)
        {
            UpdateLabelText(fatLabel, $"Fat: {helper.FatValue.ToString("#.###")} {helper.FatUnit}");
        }

        private void ProductName_AfterApplyChanges(object sender, OpcNodeChangesEventArgs e)
        {
            var node = (OpcDataVariableNode<string>)sender;
            string product = node.Value;
            UpdateLabelText(productLabel, $"Product: {product}");
        }

        private void WatchdogNode_AfterApplyChanges(object sender, OpcNodeChangesEventArgs e)
        {
            var node = (OpcDataVariableNode<uint>)sender;
            var watchdog = node.Value.ToString();
            UpdateLabelText(watchdogLabel, watchdog);
            helper.UpdateServerWatchdog();
        }

        private void EventsCount_AfterApplyChanges(object sender, OpcNodeChangesEventArgs e)
        {
            var node = (OpcDataVariableNode<uint>)sender;
            var count = node.Value;
            eventsButton.ForeColor = count > 0 ? Color.Red : Color.Black;
        }


        private void StateNode_AfterApplyChanges(object sender, Opc.UaFx.OpcNodeChangesEventArgs e)
        {
            var state = e.Changes;
            var node = (OpcDataVariableNode<string>)sender;
            var noraState = node.Value;

            if (SettingsForm.LogOptions.LogStates)
            {
                statesLogger.LogInfo($"Type: {state} New state: {noraState}");
            }

            AppendToRichTextBox(noraState);

            switch (noraState)
            {
                case "Measuring":
                    CurrentState = new StateNoraMeasuring(helper);
                    SetStartStopButtonText("Stop");
                    break;
                case "Stopped":
                    CurrentState = new StateNoraStopped(helper);
                    SetStartStopButtonText("Start");
                    break;
                case "ZeroSetting":
                    CurrentState = new StateNoraZeroing(helper);
                    break;
                case "ManualCleaning":
                    CurrentState = new StateNoraCleaning(helper);
                    break;
                case "PrepareMeasuring":
                    CurrentState = new StateNoraPreparing(helper);
                    break;
                case "ProcessCleaning":
                    CurrentState = new StateNoraCleaning(helper);
                    break;
                case "CleanInPlace":
                    CurrentState = new StateNoraCip(helper);
                    SetStartStopButtonText("Stop");
                    break;
            }
        }


        private void Server_StateChanged(object sender, Opc.UaFx.Server.OpcServerStateChangedEventArgs e)
        {
            var mes = e.NewState.ToString();
            AppendToRichTextBox(mes);

            serverStateLabel.Text = mes;

            switch (mes)
            {
                case "Started":
                    CurrentState = new StateServerStarted(helper);
                    break;
                case "Stopped":
                    CurrentState = new StateServerStopped(helper);
                    break;
            }
        }

        #endregion EventHandlers

        #region Ui Events

        private void startButton_Click(object sender, EventArgs e)
        {
            CurrentState.StartServer();
        }

        private void stopButton_Click(object sender, EventArgs e)
        {
            CurrentState.StopServer();
        }

        private void nodesButton_Click(object sender, EventArgs e)
        {
            if (!helper.Server.State.Equals(Opc.UaFx.Server.OpcServerState.Started)) return;

            var nodesForm = new NodesForm(helper);
            nodesForm.Show();
        }

        private void startStopButton_Click(object sender, EventArgs e)
        {
            CurrentState.StartStopMeasuring(productTextBox.Text);
        }

        private void cipButton_Click(object sender, EventArgs e)
        {
            CurrentState.SetCip();
        }

        private void productTextBox_TextChanged(object sender, EventArgs e)
        {
            CurrentState.ChangeProduct(productTextBox.Text);
        }

        private void zeroButton_Click(object sender, EventArgs e)
        {
            CurrentState.EnqueueZero();
        }

        private void cleanButton_Click(object sender, EventArgs e)
        {
            CurrentState.EnqueueRinse();
        }

        private void settingsToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            CurrentState.OpenSettings();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!(helper is null))
            {
                CurrentState.StopServer();
            }

            this.Close();
        }

        #endregion Ui Events

        private void Initialise()
        {
            if (!Directory.Exists(Properties.Settings.Default.LogFolder))
            {
                Directory.CreateDirectory(Properties.Settings.Default.LogFolder);
            }

            helper = new OpcUaHelper(ServerName, RootFolderName);
            helper.Server.StateChanged += Server_StateChanged;
            helper.StateNode.AfterApplyChanges += StateNode_AfterApplyChanges;
            helper.WatchdogNode.AfterApplyChanges += WatchdogNode_AfterApplyChanges;
            helper.ProductName.AfterApplyChanges += ProductName_AfterApplyChanges;
            helper.SampleCounterNode.AfterApplyChanges += SampleCounter_AfterApplyChanges;
            helper.EventsCount.AfterApplyChanges += EventsCount_AfterApplyChanges;
            CurrentState = new StateServerStopped(helper);
            SettingsForm.LogOptions = InitialiseLogging();
        }

        private LogOptions InitialiseLogging()
        {
            return new LogOptions
            {
                LogJitter = true,
                LogStates = true,
                LogMeasuredValues = true,
                LogNodeValues = true
            };
        }


        private void HandleEvents()
        {
            var eventMessages = helper.EventMessages;

            if (eventMessages is null) return;
     
            foreach (var eventMessage in eventMessages)
            {
                if (string.IsNullOrEmpty(eventMessage)) break;

                AppendToRichTextBox($"{eventMessage}\n");
            }
        }

        #region Updaters

        private void SetStartStopButtonText(string text)
        {
            if (startStopButton.InvokeRequired)
            {
                SetStartStopButtonTextCallback d = SetStartStopButtonText;
                this.Invoke(d, new object[] { text });
                return;
            }

            startStopButton.Text = text;
        }

        private void UpdateLabelText(Label label, string text)
        {
            if (label.InvokeRequired)
            {
                UpdateLabelTextCallback d = new UpdateLabelTextCallback(UpdateLabelText);
                this.Invoke(d, new object[] { label, text });
                return;
            }

            label.Text = text;
        }


        private void AppendToRichTextBox(string text)
        {
            if (richTextBox1.InvokeRequired)
            {
                AppendToRichTextBoxDelegate d = AppendToRichTextBox;
                this.Invoke(d, new object[] { text });
                return;
            }

            richTextBox1.AppendText($"{DateTime.Now}: {text}\n");
            richTextBox1.ScrollToCaret();
        }

        #endregion

        private void alarmsButton_Click(object sender, EventArgs e)
        {
            var alarmsForm = new AlarmsForm(helper);
            alarmsForm.Show();
        }

        private void sampleRegButton_Click(object sender, EventArgs e)
        {
            helper.SetSampleRegistration(sampleregTextbox.Text);
        }

        private void noDelayedResCb_CheckedChanged(object sender, EventArgs e)
        {
            helper.SetNoDelayedResults(noDelayedResCb.Checked);
        }

        private void forceMeasureCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            forceMeasure = forceMeasureCheckBox.Checked;
        }

        private void eventsButton_Click(object sender, EventArgs e)
        {
            var eventsForm = new EventsForm(helper);
            eventsForm.Show();
        }
    }
}
