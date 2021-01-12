using System;
using System.Collections.Generic;
using System.Globalization;
using System.Windows.Forms;
using OpcLabs.EasyOpc.UA;
using OpcLabs.EasyOpc.UA.OperationModel;
using log4net;

[assembly:CLSCompliant(true)]

namespace OpcUaTestClient
{
  public partial class MainForm : Form
  {
    private OpcUaClient opcUaClient;
    private bool _isSubscribed /* = false*/;
    private QueueThread<List<OpcNodeResult>> resultWriterThread;
    private QueueThread<Dictionary<string, UAAttributeData>> resultWriterThread2;
    private string mode;
    private int lastSampleCounter = -1;

    private Timer timer;
  

    private static readonly ILog log = LogManager.GetLogger(typeof(MainForm));

    public MainForm()
    {
      InitializeComponent();
      log4net.Config.XmlConfigurator.Configure();
      resultWriterThread = new QueueThread<List<OpcNodeResult>>(CsvWriter.WriteToFile);
      resultWriterThread2 = new QueueThread<Dictionary<string, UAAttributeData>>(CsvWriter.WriteToFile);
      timer = new Timer()
      {
        Interval = 500,
        Enabled = false
      };
      timer.Tick += Timer_Tick;
    }

    private void Timer_Tick(object sender, EventArgs e)
    {
      var results = opcUaClient.ReadAll2();

      int counter = int.Parse(results["SampleCounter"].DisplayValue());
      if (counter.Equals(lastSampleCounter))
      {
        log.Error($"This sample counter {counter} last sample counter: {lastSampleCounter}");
        return;
      }

      lastSampleCounter = counter;

      resultWriterThread2.Enqueue(results);
    }

    private void readButton_Click(object sender, EventArgs e)
    {
      UAAttributeData attributeData = null;
      Exception exception = null;
      try
      {
        attributeData = opcUaClient.ReadSingleValue(nodeIdTextBox.Text);
      }
      catch (UAException ex)
      {
        exception = ex;
      }

      DisplayAttributeData(attributeData);
      DisplayException(exception);
    }

    private void DisplayAttributeData(UAAttributeData attributeData)
    {
      if (attributeData == null)
      {
        valueTextBox.Text = "";
        statusTextBox.Text = "";
        sourceTimestampTextBox.Text = "";
        serverTimestampTextBox.Text = "";
      }
      else
      {
        valueTextBox.Text = attributeData.DisplayValue();
        statusTextBox.Text = attributeData.StatusCode.ToString();
        sourceTimestampTextBox.Text = attributeData.SourceTimestamp.ToString(CultureInfo.CurrentCulture);
        serverTimestampTextBox.Text = attributeData.ServerTimestamp.ToString(CultureInfo.CurrentCulture);
      }
    }

    private void DisplayException(Exception exception)
    {
      exceptionTextBox.Text = exception == null ? "" : exception.GetBaseException().Message;
    }

    public bool IsSubscribed
    {
      get { return _isSubscribed; }
      set
      {
        _isSubscribed = value;
        subscribeMonitoredItemButton.Enabled = !_isSubscribed;
      }
    }

    private void subscribeButton_Click(object sender, EventArgs e)
    {
      this.opcUaClient.SubscribeSingleNode(nodeIdTextBox.Text);
      IsSubscribed = true;
    }


    private void closeButton_Click(object sender, EventArgs e)
    {
      opcUaClient.Unsubscribe();
      Close();
    }

    private void writeValueButton_Click(object sender, EventArgs e)
    {
      Exception exception = null;
      try
      {
        opcUaClient.WriteItem(nodeIdTextBox.Text, valueToWriteTextBox.Text);
      }
      catch (UAException ex)
      {
        exception = ex;
      }

      DisplayException(exception);
    }

    private void connectButton_Click(object sender, EventArgs e)
    {
      opcUaClient = new OpcUaClient(serverUriTextBox.Text, groupTextbox.Text);
      opcUaClient.RaiseDataChangeEvent += OpcUaClient_RaiseDataChangeEvent;
      WriteMode();
    }

    private void OpcUaClient_RaiseDataChangeEvent(object sender, OpcClientEventArgs e)
    {
      if (int.Parse(e.NewValue).Equals(lastSampleCounter))
      {
        log.Error($"Last samplecounter: {lastSampleCounter}. This samplecounter: {e.NewValue}");
        return;
      }

      if (int.Parse(e.NewValue) - lastSampleCounter != 1)
      {
        log.Error($"The samplecounter increased with more than 1. Last samplecounter: {lastSampleCounter}. This samplecounter: {e.NewValue}");
      }

      lastSampleCounter = int.Parse(e.NewValue);

      var results = opcUaClient.ReadAll2();

      resultWriterThread2.Enqueue(results);
      //CsvWriter.WriteToFile(results);
    }

    private void subscribeResultsButton_Click(object sender, EventArgs e)
    {
      log.Info($"Starting subscribtion with {samplerateTextbox.Text} ms samplerate.");
      if (int.TryParse(samplerateTextbox.Text, out int sampleRate))
        opcUaClient.SubscribeSampleCounter(sampleRate);
      else
        opcUaClient.SubscribeSampleCounter();
    }

    private void unsubscribeButton_Click(object sender, EventArgs e)
    {
      opcUaClient.Unsubscribe();
    }

    private void WriteMode()
    {
      string modeNode = "ns=2;s=MMII.PDx.Instrument.Mode";
      mode = opcUaClient.ReadSingleValue(modeNode).DisplayValue();
      modeLabel.Text = mode;
    }

    private void startStopButton_Click(object sender, EventArgs e)
    {

    }

    private void startButton_Click(object sender, EventArgs e)
    {
      log.Info($"Starting timer with {samplerateTextbox.Text} ms interval.");
      timer.Interval = int.Parse(samplerateTextbox.Text);
      timer.Enabled = true;
    }
  }
}
