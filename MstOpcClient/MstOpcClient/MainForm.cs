﻿using System;
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

    private double fat = 10;
    private int sampleCounterOut = 1;
    private int sampleNumber =1;

    private bool connected;

    private int state;

    private bool isInCip;

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
        SetLabel(lblState, Enum.GetName(typeof(MatildeStateTypes), state));
      }
    }

    private bool IsInCip
    {
      get { return isInCip; }
      set
      {
        isInCip = value;
        HandleCip();
        SetLabel(lblCip, $"Cip: {value}");
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
        isSimulating = value;
        string btnText = isSimulating ? "Stop" : "Start";
        UpdateButton(btnStartSimulation, true, btnText);
        simLbl.Text = $"Simulating: {isSimulating}";
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

      simulationTimer = new Timer(200);
      simulationTimer.Elapsed += SimulationTimer_Elapsed;

      cbOpcServer.Items.Add(new KepServerItems("KepServer V6", "Kepware.KEPServerEX.V6"));
      cbOpcServer.Items.Add(new KepServerItems("KepServer V5", "Kepware.KEPServerEX.V5"));

      cbOpcServer.SelectedItem = cbOpcServer.Items[0];
      tbGroupName.Text = "Siemens.S71500"; //"Matilde.Pdx";

      IsInCip = false;
      Connected = false;
      IsSimulating = false;
    }

    private void On_updateTagsTimer(object sender, ElapsedEventArgs args)
    {
      KepServerCommunicator.OpcHelp.OPCGetData.ReadAllOPCData();

      var opcTags = KepServerCommunicator.KepServerOpcTags;

      if (!State.Equals(opcTags.InstrumentGroup.ModeN.Value))
        State = opcTags.InstrumentGroup.ModeN.Value;

      if (!IsInCip.Equals(opcTags.ControllerGroup.CIP.Value))
        IsInCip = opcTags.ControllerGroup.CIP.Value;

      if (!SampleCounter.Equals(opcTags.InstrumentGroup.SampleCounter.Value))
        SampleCounter = opcTags.InstrumentGroup.SampleCounter.Value;



      SetLabel(lblWatchdog, string.Format("Watchdog: {0}", opcTags.InstrumentGroup.WatchdogCounter.Value));
      SetLabel(lblCalibrationSample,
        string.Format("Doing calibration: {0}", opcTags.InstrumentGroup.DoingCalibrationSample.Value));

      //KepServerCommunicator.UpdateWatchDogCounter(opcWatchdog);
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
        case 5:
          UpdateButton(btnStartStop, true, "Start measuring");
          UpdateButton(btnWaterReference, true, "Start WaterRef");
          UpdateButton(btnCalibration, false);
          UpdateButton(btnCip, true, "Start CIP");
          UpdateButton(btnStartSimulation, true);
          tbProductCode.Enabled = Connected;
          break;
        case 6:
          UpdateButton(btnStartStop, true, "Stop measuring");
          UpdateButton(btnWaterReference, false, "Start WaterRef");
          UpdateButton(btnCalibration, true);
          UpdateButton(btnCip, false);
          UpdateButton(btnStartSimulation, true);
          tbProductCode.Enabled = Connected;
          break;
        case 21:
          UpdateButton(btnWaterReference, true, "Stop WaterRef");
          UpdateButton(btnStartStop, false, "Start measuring");
          UpdateButton(btnCip, false);
          UpdateButton(btnCalibration, false);
          UpdateButton(btnStartSimulation, true);
          break;
        default:
          UpdateButton(btnStartStop, false, "Start measuring");
          UpdateButton(btnCalibration, false);
          UpdateButton(btnWaterReference, false, "Start WaterRef");
          UpdateButton(btnStartSimulation, false);
          UpdateButton(btnCip, false);
          break;
      }
    }

    private void HandleCip()
    {
      State = Connected ? 5 : 0;

      if (IsInCip)
      {
        KepServerCommunicator.KepServerStartMeasuring(false);
        UpdateButton(btnCip, true, "Stop CIP");
        UpdateButton(btnStartStop, false);
        UpdateButton(btnWaterReference, false);
      }
      else
      {
        UpdateButton(btnCip, true, "Start CIP");
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
      int productCode;

      if (int.TryParse(tbProductCode.Text, out productCode))
      {
        if (state.Equals(5))
        {
          KepServerCommunicator.KepServerStartMeasuring(true);
        }
        else if (state.Equals(6))
        {
          KepServerCommunicator.KepServerStartMeasuring(false);
        }
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

    private void btnWaterReference_Click(object sender, EventArgs e)
    {
      if (State.Equals(5))
      {
        KepServerCommunicator.SetWaterRef(true);
      }
      else if (State.Equals(21))
      {
        KepServerCommunicator.SetWaterRef(false);
      }
    }

    private void btnCip_Click(object sender, EventArgs e)
    {
      if (IsInCip)
      {
        KepServerCommunicator.SetCip(false);
      }
      else
      {
        KepServerCommunicator.SetCip(true);
      }
    }

    private void btnStartSimulation_Click(object sender, EventArgs e)
    {
      IsSimulating = !IsSimulating;

      if (IsSimulating)
      {
        simulationTimer.Start();
        simTimerCounter = 0;
      }
      else
      {
        simulationTimer.Stop();
        KepServerCommunicator.KepServerStartMeasuring(false);
        KepServerCommunicator.SetCip(false);
        KepServerCommunicator.SetWaterRef(false);
      }
    }

    private void SimulationTimer_Elapsed(object sender, ElapsedEventArgs e)
    {

      /*int sampleTime = int.Parse(tbMeasureTime.Text);
      int waterRefTime = int.Parse(tbWaterRefTime.Text);
      int cipTime = int.Parse(tbCipTime.Text);

      if (simTimerCounter<sampleTime)
      {
        if (state == 5)
        {
          KepServerCommunicator.KepServerStartMeasuring(true);
        }
      }
      else if (simTimerCounter > sampleTime & simTimerCounter < sampleTime + cipTime)
      {
        if (state == 6)
        {
          KepServerCommunicator.KepServerStartMeasuring(false);
          Thread.Sleep(TimeSpan.FromSeconds(20));
          KepServerCommunicator.SetCip(true);
        }
      }
      else if (simTimerCounter > sampleTime + cipTime & simTimerCounter < sampleTime + cipTime + waterRefTime)
      {
        KepServerCommunicator.SetCip(false);
        KepServerCommunicator.SetWaterRef(true);
      }

      simTimerCounter++;

      if (simTimerCounter > sampleTime + cipTime + waterRefTime)
      {
        simTimerCounter = 0;
        KepServerCommunicator.SetWaterRef(false);
      }

      SimCtrLbl.Text = $"Simulation counter: {simTimerCounter}";
      */
      SimNewSample();
    }

    private void newSampleButton_Click(object sender, EventArgs e)
    {
      SimNewSample();
    }

    private void SimNewSample()
    {
      KepServerCommunicator.TestNewResult(fat, sampleNumber, sampleCounterOut);
      fat += 0.2;
      sampleNumber++;
      sampleCounterOut++;
    }

    private void button1_Click(object sender, EventArgs e)
    {
      simulationTimer.Stop();
    }

    private void button2_Click(object sender, EventArgs e)
    {
      simulationTimer.Interval = int.Parse(intervalTextBox.Text);
      simulationTimer.Start();
    }
  }
}
