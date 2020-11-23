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
      try
      {
        GetState();
        GetCurrentProduct();
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
      if (productsCb.SelectedItem == null)
      {
        respondTb.Text = "Select a product before starting.";
        return String.Empty;
      }

      string product = ((PfProduct) productsCb.SelectedItem).ProductCode;

      string cmd = $"startMeasurement/{product}";
      isMeasuring = true;
      return SendCommand(cmd);
    }

    private string StopMeasuring()
    {
      string cmd = "stopMeasurement";
      isMeasuring = false;
      return SendCommand(cmd);
    }

    private string SendCommand(string cmd)
    {
      serialNumber = ((PfInstrument) instrumentsCb.SelectedItem).SerialNumber;
      System.Net.WebClient wc = new System.Net.WebClient();
      string webData = wc.DownloadString($"http://{ip}:7913/instrument/{serialNumber}/{cmd}");
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
      Statelbl.Text = $"State: {state}.";
      return state;
    }

    private void GetCurrentProduct()
    {
      string prodInfo = SendCommand("currentProduct");
      
      if (string.IsNullOrEmpty(prodInfo)) return;

      var product = JObject.Parse( $"{{'Product':{prodInfo} }}");
      string curProduct = (string) product["Product"]["name"];
      productLbl.Text = $"Current product: {curProduct}";
    }


    private void GetProducts()
    {
      string response = SendCommand("products");

      string products = $"{{'ProductList': {{'Products':{response}}} }}";

      var jProduct = JObject.Parse(products);

      JArray jProducts = (JArray)jProduct["ProductList"]["Products"];
      productsCb.Items.Clear();

      foreach (var product in jProducts)
      {
        productsCb.Items.Add(new PfProduct((string)product["name"], (string)product["productCode"]));
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
      instrumentsCb.Items.Clear();

      foreach (var instrument in jInstruments)
      {
        instrumentsCb.Items.Add(new PfInstrument((string)instrument["friendlyName"], (string)instrument["serialNumber"]));
      }

      if (instrumentsCb.Items.Count > 0)
      {
        instrumentsCb.SelectedItem = instrumentsCb.Items[0];
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
      instrumentsCb.Items.Clear();
      instrumentsCb.Text = String.Empty;
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
      if (GetState().Equals("\"Measuring\""))
      {
        string cmd = $"switchProduct/{((PfProduct)productsCb.SelectedItem).ProductCode}";
        SendCommand(cmd);
      }
    }



    #endregion

    private void resetInstrumentBtn_Click(object sender, EventArgs e)
    {
      SendCommand("resetInstrument");
    }
  }
}
