using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace ProFossJsonTest
{
  public partial class Form1 : Form
  {
    private bool isSimulating = false;
    private string ip;
    private string serialNumber;
    private int simTime = 0;
    private bool isMeasuring = false;

    private Timer simTimer = new Timer();
    private Timer updateTimer = new Timer();

    public Form1()
    {
      InitializeComponent();

      simTimer.Interval = 1000;
      simTimer.Tick += SimTimer_Tick;

      updateTimer.Interval = 1000;
      updateTimer.Tick += UpdateTimer_Tick;
      updateTimer.Enabled = true;

      respondTb.Lines = new string[5];
      ip = ipTb.Text;
    }

    private void UpdateTimer_Tick(object sender, EventArgs e)
    {
      StringBuilder sb = new StringBuilder();

      try
      {
        foreach (var item in instrumentListBox.Items)
        {
          serialNumber = ((PfInstrument) item).SerialNumber;
          string instrumentName = ((PfInstrument) item).Name;
          sb.AppendLine($"{instrumentName}: {GetState()} Product: {GetCurrentProduct()}");
        }

        respondTb.Text = sb.ToString();
      }
      catch (Exception exception)
      {
        respondTb.Text = exception.Message;
      }
    }

    private void SimTimer_Tick(object sender, EventArgs e)
    {
      if (isSimulating)
      {
        simTime++;

        if (simTime < int.Parse(measureTb.Text))
        {
          if (!isMeasuring)
          {
            StartMeasuring();
          }
        }

        if (simTime > int.Parse(measureTb.Text))
        {
          if (isMeasuring)
          {
            StopMeasuring();
          }
        }

        if (simTime > int.Parse(measureTb.Text) + int.Parse(pauseTb.Text))
        {
          simTime = 0;
        }
      }
    }


    #region Private methods


    private string StartMeasuring()
    {
      string returnValue = string.Empty;
      string product = ((PfProduct) productsCb.SelectedItem).ProductId;

      foreach (var item in instrumentListBox.SelectedItems)
      {
        serialNumber = ((PfInstrument) item).SerialNumber;
        string cmd = $"startMeasurement/{product}";
        isMeasuring = true;
        returnValue = SendCommand(cmd);
      }

      return returnValue;
    }

    private string StopMeasuring()
    {
      string returnValue = String.Empty;

      foreach (var selectedItem in instrumentListBox.SelectedItems)
      {
        serialNumber = ((PfInstrument) selectedItem).SerialNumber;
        string cmd = "stopMeasurement";
        isMeasuring = false;
        returnValue = SendCommand(cmd);
      }

      return returnValue;
    }

    private string SendCommand(string cmd)
    {
      //serialNumber = ((PfInstrument) instrumentsCb.SelectedItem).SerialNumber;
      System.Net.WebClient wc = new System.Net.WebClient();
      string command = $"http://{ip}:7913/instrument/{serialNumber}/{cmd}";
      respondTb.Text = command;
      string webData = wc.DownloadString(command);
      return webData;
    }

    private string GetStuff()
    {
      System.Net.WebClient wc = new System.Net.WebClient();
      string webData = wc.DownloadString($"http://{ip}:7913/Debug.html");
      return webData;
    }

    private string GetState()
    {
      string state = SendCommand("state");
      return state;
    }

    private string GetCurrentProduct()
    {
      string prodInfo = SendCommand("currentProduct");

      if (string.IsNullOrEmpty(prodInfo)) return String.Empty;

      var product = JObject.Parse($"{{'Product':{prodInfo} }}");
      string curProduct = (string) product["Product"]["name"];
      return curProduct;
    }


    private void GetProducts()
    {
      string response = SendCommand("products");

      string products = $"{{'ProductList': {{'Products':{response}}} }}";

      var jProduct = JObject.Parse(products);

      JArray jProducts = (JArray) jProduct["ProductList"]["Products"];
      productsCb.Items.Clear();

      foreach (var product in jProducts)
      {
        productsCb.Items.Add(new PfProduct((string) product["name"], (string) product["id"]));
      }

      if (productsCb.Items.Count > 0)
      {
        productsCb.SelectedItem = productsCb.Items[0];
      }
    }

    private void GetInstruments()
    {
      System.Net.WebClient wc = new System.Net.WebClient();
      string webData = wc.DownloadString($"http://{ip}:7913/instruments");
      string instruments = $"{{'InstrumentList': {{'Instruments':{webData} }} }}";

      var jInstrumentList = JObject.Parse(instruments);

      JArray jInstruments = (JArray) jInstrumentList["InstrumentList"]["Instruments"];
      instrumentListBox.Items.Clear();

      foreach (var instrument in jInstruments)
      {
        instrumentListBox.Items.Add(new PfInstrument((string) instrument["friendlyName"],
          (string) instrument["serialNumber"]));
      }

      if (instrumentListBox.Items.Count > 0)
      {
        serialNumber = ((PfInstrument) instrumentListBox.Items[0]).SerialNumber;
        instrumentListBox.SelectedItem = instrumentListBox.Items[0];
      }
    }

    private void CalibrationSample()
    {
      foreach (var item in instrumentListBox.SelectedItems)
      {
        serialNumber = ((PfInstrument) item).SerialNumber;
        isMeasuring = true;
        SendCommand("MarkAsCalibration");
      }
    }

    #endregion

    #region Ui methods

    private void startBtn_Click(object sender, EventArgs e)
    {
      StartMeasuring();
    }

    private void stopBtn_Click(object sender, EventArgs e)
    {
      StopMeasuring();
    }

    private void startStopBtn_Click(object sender, EventArgs e)
    {
      if (isSimulating)
      {
        startStopBtn.Text = "Start";
        simTimer.Enabled = false;
      }
      else
      {
        startStopBtn.Text = "Stop";
        simTimer.Enabled = true;
      }

      isSimulating = !isSimulating;
    }

    private void getProductsBtn_Click(object sender, EventArgs e)
    {
      GetProducts();
    }

    private void ipTb_TextChanged(object sender, EventArgs e)
    {
      ip = ipTb.Text;
      productsCb.Items.Clear();
      productsCb.Text = String.Empty;
      respondTb.Text = string.Empty;
      try
      {
        GetInstruments();
        respondTb.Text = "Connected.";
      }
      catch (WebException exception)
      {
        respondTb.Text = exception.Message;
      }
    }

    private void getInstrumentsBtn_Click(object sender, EventArgs e)
    {
      GetInstruments();
    }

    private void instrumentsCb_SelectedIndexChanged(object sender, EventArgs e)
    {
      GetProducts();
    }

    private void productsCb_SelectedIndexChanged(object sender, EventArgs e)
    {
      foreach (var item in instrumentListBox.SelectedItems)
      {
        serialNumber = ((PfInstrument) item).SerialNumber;
        if (GetState().Equals("\"Measuring\""))
        {
          string cmd = $"switchProduct/{((PfProduct) productsCb.SelectedItem).ProductId}";
          SendCommand(cmd);
        }
      }
    }

    private void resetInstrumentBtn_Click(object sender, EventArgs e)
    {
      foreach (var item in instrumentListBox.SelectedItems)
      {
        serialNumber = ((PfInstrument) item).SerialNumber;
        isMeasuring = true;
        SendCommand("resetInstrument");
      }
    }

    private void calibrationButton_Click(object sender, EventArgs e)
    {
      CalibrationSample();
    }

    #endregion

  }
}
