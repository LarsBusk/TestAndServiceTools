using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Net.Mime;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using log4net;
using OPCClient.KepServer;
using OPCClient.OPCTags;
using ProfossOpcClient;
using Timer = System.Timers.Timer;

namespace MstOpcClient
{
  public partial class MainForm : Form
  {
    #region Private fields

    private KepServerCommunicator kepServerCommunicator;

    private static readonly ILog log = LogManager.GetLogger(typeof(MainForm));

    private delegate void SetLabelCallback(Label label, string text);

    private delegate void UpdateButtonCallback(Button button, bool enabled, string text);

    private Timer simulationTimer;

    private int opcWatchdog;

    private Timer updateTagsTimer;

    private bool connected;

    private int state;

    private int sampleCounter;

    private bool isSimulating;

    private int simTimerCounter;

    #endregion Private fields

    #region Private properties


    private bool Connected
    {
      get { return connected; }
      set
      {
        connected = value;
        UpdateStates();
        UpdateButtonStates();
      }
    }



    private int State
    {
      get { return state; }

      set
      {
        state = value;
        UpdateButtonStates();
        SetLabel(lblState, Enum.GetName(typeof(ProFossStateTypes), state));
      }
    }

    private int SampleCounter
    {
      get => sampleCounter;

      set
      {
        sampleCounter = value;
        SetLabel(lblSampleCounter, $"Sample counter: {value}");
      }
    }

    private bool IsSimulating
    {
      get => isSimulating;

      set
      {
        string btnText = isSimulating ? "Stop" : "Start";
        UpdateButton(btnStartSimulation, true, btnText);
      }
    }

    #endregion Private properties

    public MainForm()
    {
      InitializeComponent();
      log4net.Config.XmlConfigurator.Configure();
      Startup();
    }

    private void ConnectToKepServer()
    {
      string kepServerName = ((KepServerItems) cbOpcServer.SelectedItem).KepServerName;
      string groupName = tbGroupName.Text;
      log.InfoFormat("Connecting to KeServer: {0}, group: {1}", kepServerName, groupName);

      try
      {
        kepServerCommunicator = new OPCClient.KepServer.KepServerCommunicator();
        kepServerCommunicator.ConnectToKepServer(kepServerName, groupName);
      }
      catch (Exception exception)
      {
        log.ErrorFormat("Failed connecting to Kepserver name: {0} group: {1}. {2}", kepServerName, groupName,
          exception.Message);
        MessageBox.Show(exception.Message, "Failed connection");
        return;
      }

      log.Info("Connected to KepServer.");
      Connected = true;
    }

    private void Startup()
    {
      updateTagsTimer = new Timer(1000);
      updateTagsTimer.Elapsed += On_updateTagsTimer;

      simulationTimer = new Timer(1000);
      simulationTimer.Elapsed += SimulationTimer_Elapsed;

      cbOpcServer.Items.Add(new KepServerItems("KepServer V6", "Kepware.KEPServerEX.V6"));
      cbOpcServer.Items.Add(new KepServerItems("KepServer V5", "Kepware.KEPServerEX.V5"));

      cbOpcServer.SelectedItem = cbOpcServer.Items[0];
      tbGroupName.Text = "ProFoss.Pdx";

      Connected = false;
      isSimulating = false;
    }

    private void On_updateTagsTimer(object sender, ElapsedEventArgs args)
    {
      KepServerCommunicator.OpcHelp.OPCGetData.ReadAllOPCData();

      var opcTags = KepServerCommunicator.KepServerOpcTags;

      if (!State.Equals(opcTags.InstrumentGroup.ModeN.Value))
        State = opcTags.InstrumentGroup.ModeN.Value;

      if (!SampleCounter.Equals(opcTags.InstrumentGroup.SampleCounter.Value))
        SampleCounter = opcTags.InstrumentGroup.SampleCounter.Value;



      SetLabel(lblWatchdog, string.Format("Watchdog: {0}", opcTags.InstrumentGroup.WatchdogCounter.Value));
      SetLabel(lblCalibrationSample,
        string.Format("Doing calibration: {0}", opcTags.InstrumentGroup.DoingCalibrationSample.Value));

      KepServerCommunicator.UpdateWatchDogCounter(opcWatchdog);
      opcWatchdog++;
    }

    private void btnConnect_Click(object sender, EventArgs e)
    {
      ConnectToKepServer();
    }

    private void UpdateStates()
    {
      btnConnect.Enabled = !Connected;
      btnDisconnect.Enabled = Connected;
      lblConnected.Text = Connected ? "Connected" : "Disconnected";
      lblConnected.ForeColor = Connected ? Color.Green : Color.Red;
      cbOpcServer.Enabled = !Connected;
      tbGroupName.Enabled = !Connected;
      updateTagsTimer.Enabled = Connected;
      tbProductCode.Enabled = Connected;
    }

    private void btnDisconnect_Click(object sender, EventArgs e)
    {
      kepServerCommunicator.DisconnectFromKepServer();
      kepServerCommunicator = null;
      Connected = false;
      State = 0;
    }

    private void UpdateButtonStates()
    {
      switch (State)
      {
        case 2:
          UpdateButton(btnStartStop, true, "Start measuring");
          UpdateButton(btnCalibration, false);
          UpdateButton(btnStartSimulation, true);
          tbProductCode.Enabled = Connected;
          break;
        case 3:
          UpdateButton(btnStartStop, true, "Stop measuring");
          UpdateButton(btnCalibration, true);
          UpdateButton(btnStartSimulation, true);
          tbProductCode.Enabled = Connected;
          break;
        case 9:
          UpdateButton(btnStartStop, false, "Start measuring");
          UpdateButton(btnCalibration, false);
          UpdateButton(btnStartSimulation, true);
          break;
        default:
          UpdateButton(btnStartStop, false, "Start measuring");
          UpdateButton(btnCalibration, false);
          UpdateButton(btnStartSimulation, false, "Start");
          break;
      }
    }


    private void SetLabel(Label label, string text)
    {
      if (lblWatchdog.InvokeRequired)
      {
        SetLabelCallback d = new SetLabelCallback(SetLabel);
        this.Invoke(d, new object[] {label, text});
        return;
      }

      label.Text = text;
    }

    private void UpdateButton(Button button, bool enabled, string text = "")
    {
      if (button.InvokeRequired)
      {
        UpdateButtonCallback d = new UpdateButtonCallback(UpdateButton);
        this.Invoke(d, new object[] {button, enabled, text});
      }

      button.Enabled = enabled;

      if (!text.Equals("")) button.Text = text;
    }


    private void btnStartStop_Click(object sender, EventArgs e)
    {
      if (state.Equals(2))
      {
        StartMeasuring();
      }
      else if (state.Equals(3))
      {
        KepServerCommunicator.KepServerStartMeasuring(false);
      }
    }

    private void tbProductCode_TextChanged(object sender, EventArgs e)
    {
      int productCode;

      if (int.TryParse(tbProductCode.Text, out productCode))
      {
        KepServerCommunicator.KepServerSetProductCodeN(productCode);
      }
    }

    private void btnCalibration_Click(object sender, EventArgs e)
    {
      KepServerCommunicator.SetCalibrationSample(true);
      Thread.Sleep(TimeSpan.FromSeconds(1));
      KepServerCommunicator.SetCalibrationSample(false);
    }

    private void btnStartSimulation_Click(object sender, EventArgs e)
    {
      if (isSimulating)
      {
        simulationTimer.Stop();
        btnStartSimulation.Text = "Start";
        KepServerCommunicator.KepServerStartMeasuring(false);
      }
      else
      {
        simulationTimer.Start();
        btnStartSimulation.Text = "Stop";
        simTimerCounter = 0;
      }

      isSimulating = !isSimulating;
    }

    private void SimulationTimer_Elapsed(object sender, ElapsedEventArgs e)
    {
      int sampleTime = int.Parse(tbMeasureTime.Text);
      int pauseTime = int.Parse(tbPauseTime.Text);
      lblSimCounter.Text = $"Simulation counter: {simTimerCounter}";

      if (simTimerCounter < sampleTime)
      {
        if (state == 2)
        {
          StartMeasuring();
        }
      }
      else if (simTimerCounter > sampleTime & simTimerCounter < sampleTime + pauseTime)
      {
        if (state == 3)
        {
          KepServerCommunicator.KepServerStartMeasuring(false);
          Thread.Sleep(TimeSpan.FromSeconds(20));
        }
      }

      simTimerCounter++;

      if (simTimerCounter > sampleTime + pauseTime)
      {
        simTimerCounter = 0;
      }
    }

    private void StartMeasuring()
    {
      int productCode;

      if (int.TryParse(tbProductCode.Text, out productCode))
      {
        KepServerCommunicator.KepServerSetProductCodeN(productCode);
        KepServerCommunicator.KepServerStartMeasuring(true);
      }
    }
  }
}
