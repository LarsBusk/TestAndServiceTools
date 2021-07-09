using System;
using System.Globalization;
using System.IO;
using System.Text;
using System.Windows.Forms;
using OPCClient.Communicators;
using OPCClient.OPCTags;
using OPCCsvLoggerClient.Properties;

namespace OPCCsvLoggerClient
{

  public partial class MainForm : Form
  {
    #region Public properties



    #endregion Public properties

    #region Private fileds

    private const int NoSampleCounter = -1;
    private const string fileName = "OpcTags.csv";
    private const string dateTimeFormat = "dd/MM yyyy HH:mm:ss";

    /// <summary>
    /// date time written to file should be in ISO format.
    /// Note that : is a literal - if it wasn't : would be substituted for the current culture's hour separator
    /// </summary>
    private const string isoDateTimeFormatForFile = "yyyy-MM-dd HH':'mm':'ss','fff";

    private int lastSampleCounter = NoSampleCounter;
    private string lastSampleNumber = string.Empty;
    private MeatMasterOPCCommunicatior meatMasterOPCCommunicatior;
    private bool fossOpcServer = true;
    private QueueThread<TagsInformation> logWriterThread = new QueueThread<TagsInformation>(WriteToFile, "IS");

    #endregion Private fields

    public MainForm()
    {
      InitializeComponent();
      cbOpcServer.Text = Properties.Settings.Default.KepServerName;
      tbGroupName.Text = Properties.Settings.Default.KepServerGroupName;
    }

    private void ConnectToMeatMasterOPCServer()
    {
      try
      {
        meatMasterOPCCommunicatior = new MeatMasterOPCCommunicatior(OPCServerType.MeatMaster);
        meatMasterOPCCommunicatior.ConnectToMeatMasterOPCServer();
      }
      catch (Exception exception)
      {
        MessageBox.Show(exception.Message);
        return;
      }

      File.AppendAllLines(fileName, new[] {"DateTime(utc);SampleId;OpcClientTime;SampleTime;SampleCounter"});
    }

    private void ConnectToKepServer()
    {
      int updateRate = 100;
      int.TryParse(tbUpdateRate.Text, out updateRate);

      try
      {
        string kepServerName = cbOpcServer.Text == "KepServer V6" ? "Kepware.KEPServerEX.V6" : "Kepware.KEPServerEX.V5";
        string groupName = tbGroupName.Text ?? Properties.Settings.Default.KepServerGroupName;
        meatMasterOPCCommunicatior = new MeatMasterOPCCommunicatior(OPCServerType.KepServer);
        meatMasterOPCCommunicatior.ConnectToKepServer(kepServerName, groupName, updateRate);
      }
      catch (Exception exception)
      {
        MessageBox.Show(exception.Message);
        return;
      }

      File.AppendAllLines(fileName,
        new[]
        {
          "DateTime(utc);SampleNumberN;OpcClientTime;SampleTime;ElapsedTime;SampleCounter;Fat;Weight;Reg01;Reg02;StartMeasuring;ProductCodeN;SampleNoOut;FatOut;WeightOut"
        });
    }

    private void ConnectButtonClick(object sender, EventArgs e)
    {
      fossOpcServer = cbOpcServer.Text == "FossOpcServer";

      if (fossOpcServer)
      {
        ConnectToMeatMasterOPCServer();
      }
      else
      {
        ConnectToKepServer();
      }
    }

    private void DisconnectButtonClick(object sender, EventArgs e)
    {
      meatMasterOPCCommunicatior.DisconnectFromOPCServer();
      meatMasterOPCCommunicatior = null;
      lastSampleCounter = NoSampleCounter; //No sample counter
    }

    private void GetSampleTimerTick(object sender, EventArgs e)
    {
      if (meatMasterOPCCommunicatior == null)
        return;
      DateTime startTime = DateTime.Now;

      DateTime sampleTime;
      DateTime opcClientTime;
      int elapsedTime = 0;
      int sampleCounter;
      string sampleNumber;
      int sampleNumberN = 0;
      double fat;
      double weight;
      int registration1;
      int registration2;
      bool startMeasuring;
      int productCodeN;
      double fatOut = 0;
      double weightOut = 0;
      int sampleNoOut = 0;

      MeatMasterOPCCommunicatior.OpcHelp.OPCGetData.ReadAllOPCData();

      if (fossOpcServer)
      {
        opcClientTime = DateTime.Now;
        var mmOpcSampleGroup = MeatMasterOPCCommunicatior.MeatMasterIIOPCTags.GetSampleGroup;
        sampleCounter = mmOpcSampleGroup.Identifier.Value;

        if (sampleCounter == lastSampleCounter) return;

        sampleNumber = mmOpcSampleGroup.Number.Value;
        sampleTime = mmOpcSampleGroup.Time.Value;
        fat = 0;
        weight = 0;
        registration1 = 0;
        registration2 = 0;
        startMeasuring = false;
        productCodeN = 0;
      }
      else
      {
        int newSampleCounter = MeatMasterOPCCommunicatior.KepServerOpcTags.InstrumentGroup.SampleCounter.Value;
        string newSampleNumber = MeatMasterOPCCommunicatior.KepServerOpcTags.SampleGroup.SampleGroup.Number.Value;

        if (newSampleCounter == lastSampleCounter) return;

        MeatMasterOPCCommunicatior.OpcHelp.OPCGetData.ReadAllOPCData();

        opcClientTime = DateTime.Now;
        var kepServerTestGroup = MeatMasterOPCCommunicatior.KepServerOpcTags.TestGroup;
        var kepServerSampleGroup = MeatMasterOPCCommunicatior.KepServerOpcTags.SampleGroup;
        sampleCounter = MeatMasterOPCCommunicatior.KepServerOpcTags.InstrumentGroup.SampleCounter.Value;
        sampleTime = GetSampleDateTime(kepServerSampleGroup.SampleGroup);
        elapsedTime = (int) opcClientTime.Subtract(sampleTime).TotalMilliseconds;
        sampleNumber = kepServerSampleGroup.SampleGroup.Number.Value;
        sampleNumberN = kepServerSampleGroup.SampleGroup.NumberN.Value;
        fat = kepServerSampleGroup.SampleParametersGroup.Fat.Value;
        weight = kepServerSampleGroup.SampleParametersGroup.Weight.Value;
        registration1 = kepServerSampleGroup.SampleParametersGroup.Registration01.Value;
        registration2 = kepServerSampleGroup.SampleParametersGroup.Registration02.Value;
        productCodeN = kepServerSampleGroup.SampleGroup.ProductCodeN.Value;
        startMeasuring = MeatMasterOPCCommunicatior.KepServerOpcTags.ControllerGroup.StartMeasuring.Value;
        sampleNoOut = kepServerTestGroup.SampleNoOut.Value;
        fatOut = kepServerTestGroup.FatOut.Value;
        weightOut = kepServerTestGroup.WeightOut.Value;

        sampleTimeLabel.Text = (newSampleCounter != lastSampleCounter && lastSampleNumber == newSampleNumber)
          ? "Data inconsistency"
          : sampleTime.ToString(dateTimeFormat);
      }

      lastSampleCounter = sampleCounter;
      lastSampleNumber = sampleNumber;
      sampleIdLabel.Text = sampleCounter.ToString(CultureInfo.InvariantCulture);

      sampleNumberLabel.Text = sampleNumber;
      opcClientTimeLabel.Text = DateTime.Now.ToString(dateTimeFormat);

      logWriterThread.Enqueue(new TagsInformation(sampleNumberN, opcClientTime, sampleTime, elapsedTime,
        sampleCounter, fat, weight,
        registration1, registration2, startMeasuring, productCodeN, fatOut, weightOut, sampleNoOut));
    }

    private static void WriteToFile(TagsInformation tagsInfo)
    {
      var sb = new StringBuilder();
      sb.Append($"{DateTime.Now.ToUniversalTime().ToString(isoDateTimeFormatForFile)};");
      sb.Append($"{tagsInfo.SampleNumberN};");
      sb.Append($"{tagsInfo.OpcClientTime.ToUniversalTime().ToString(isoDateTimeFormatForFile)};");
      sb.Append($"{tagsInfo.SampleTime.ToUniversalTime().ToString(isoDateTimeFormatForFile)};");
      sb.Append($"{tagsInfo.ElapsedTime};");
      sb.Append($"{tagsInfo.SampleCounter};");
      sb.Append($"{tagsInfo.Fat};");
      sb.Append($"{tagsInfo.Weight};");
      sb.Append($"{tagsInfo.Registration1};");
      sb.Append($"{tagsInfo.Registration2};");
      sb.Append($"{tagsInfo.StartMeasuring};");
      sb.Append($"{tagsInfo.ProductCodeN};");
      sb.Append($"{tagsInfo.SampleNoOut};");
      sb.Append($"{tagsInfo.FatOut};");
      sb.Append($"{tagsInfo.WeightOut}");

      // only write difference when there is an actual difference between 2 samples
      if (tagsInfo.SampleCounter != NoSampleCounter)
      {
        File.AppendAllLines(fileName, new[] {sb.ToString()});
      }
    }

    private DateTime GetSampleDateTime(KepServerSampleGroup kepServerSampleGroup)
    {
      DateTime sampleTime = DateTime.Now;

      try
      {
        sampleTime = new DateTime(
          kepServerSampleGroup.Year.Value,
          kepServerSampleGroup.Month.Value,
          kepServerSampleGroup.Day.Value,
          kepServerSampleGroup.Hour.Value,
          kepServerSampleGroup.Minute.Value,
          kepServerSampleGroup.Second.Value,
          kepServerSampleGroup.MilliSecond.Value
        );
      }
      catch (Exception)
      {
      }

      return sampleTime;
    }

    private void textBox1_TextChanged(object sender, EventArgs e)
    {

    }
  }
}
