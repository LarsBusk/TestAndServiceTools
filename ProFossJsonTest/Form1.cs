using Newtonsoft.Json.Linq;
using System;
using System.Text;
using System.Windows.Forms;

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

        public Form1()
        {
            InitializeComponent();

            simTimer.Interval = 1000;
            simTimer.Tick += SimTimer_Tick;
            respondTb.Lines = new string[5];
            ip = ipTb.Text;
        }

        private void UpdateStatus()
        {
            var sb = new StringBuilder();

            try
            {
                foreach (var item in instrumentListBox.Items)
                {
                    serialNumber = ((PfInstrument)item).SerialNumber;
                    var instrumentName = ((PfInstrument)item).Name;
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
            if (!isSimulating) return;

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


        #region Private methods


        private string StartMeasuring()
        {
            var returnValue = string.Empty;
            var product = ((PfProduct)productsCb.SelectedItem).ProductId;

            foreach (var item in instrumentListBox.SelectedItems)
            {
                serialNumber = ((PfInstrument)item).SerialNumber;
                var cmd = $"startMeasurement/{product}";
                isMeasuring = true;
                returnValue = SendCommand(cmd);
            }

            UpdateStatus();
            return returnValue;
        }

        private string StopMeasuring()
        {
            var returnValue = string.Empty;

            foreach (var selectedItem in instrumentListBox.SelectedItems)
            {
                serialNumber = ((PfInstrument)selectedItem).SerialNumber;
                var cmd = "stopMeasurement";
                isMeasuring = false;
                returnValue = SendCommand(cmd);
            }

            UpdateStatus();
            return returnValue;
        }

        private string SendCommand(string cmd)
        {
            var wc = new System.Net.WebClient();
            var command = $"http://{ip}:7913/instrument/{serialNumber}/{cmd}";
            respondTb.Text = command;
            var webData = wc.DownloadString(command);
            return webData;
        }

        private string GetStuff()
        {
            var wc = new System.Net.WebClient();
            var webData = wc.DownloadString($"http://{ip}:7913/Debug.html");
            return webData;
        }

        private string GetState()
        {
            var state = SendCommand("state");
            return state;
        }

        private string GetCurrentProduct()
        {
            var prodInfo = SendCommand("currentProduct");

            if (string.IsNullOrEmpty(prodInfo)) return string.Empty;

            var product = JObject.Parse($"{{'Product':{prodInfo} }}");
            var curProduct = (string)product["Product"]["name"];
            return curProduct;
        }


        private void GetProducts()
        {
            var response = SendCommand("products");
            var products = $"{{'ProductList': {{'Products':{response}}} }}";
            var jProduct = JObject.Parse(products);
            JArray jProducts = (JArray)jProduct["ProductList"]["Products"];
            productsCb.Items.Clear();

            foreach (var product in jProducts)
            {
                productsCb.Items.Add(new PfProduct((string)product["name"], (string)product["id"]));
            }

            if (productsCb.Items.Count > 0)
            {
                productsCb.SelectedItem = productsCb.Items[0];
            }
        }

        private void GetInstruments()
        {
            System.Net.WebClient wc = new System.Net.WebClient();
            var webData = wc.DownloadString($"http://{ip}:7913/instruments");
            var instruments = $"{{'InstrumentList': {{'Instruments':{webData} }} }}";
            var jInstrumentList = JObject.Parse(instruments);
            JArray jInstruments = (JArray)jInstrumentList["InstrumentList"]["Instruments"];
            instrumentListBox.Items.Clear();

            foreach (var instrument in jInstruments)
            {
                instrumentListBox.Items.Add(new PfInstrument((string)instrument["friendlyName"],
                    (string)instrument["serialNumber"]));
            }

            if (instrumentListBox.Items.Count > 0)
            {
                serialNumber = ((PfInstrument)instrumentListBox.Items[0]).SerialNumber;
                instrumentListBox.SelectedItem = instrumentListBox.Items[0];
            }

            UpdateStatus();
        }

        private void CalibrationSample()
        {
            foreach (var item in instrumentListBox.SelectedItems)
            {
                serialNumber = ((PfInstrument)item).SerialNumber;
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

        private void getInstrumentsBtn_Click(object sender, EventArgs e)
        {
            GetInstruments();
        }

        private void productsCb_SelectedIndexChanged(object sender, EventArgs e)
        {
            foreach (var item in instrumentListBox.SelectedItems)
            {
                serialNumber = ((PfInstrument)item).SerialNumber;
                if (GetState().Equals("\"Measuring\""))
                {
                    string cmd = $"switchProduct/{((PfProduct)productsCb.SelectedItem).ProductId}";
                    SendCommand(cmd);
                }
            }
        }

        private void resetInstrumentBtn_Click(object sender, EventArgs e)
        {
            foreach (var item in instrumentListBox.SelectedItems)
            {
                serialNumber = ((PfInstrument)item).SerialNumber;
                isMeasuring = true;
                SendCommand("resetInstrument");
            }
        }

        private void calibrationButton_Click(object sender, EventArgs e)
        {
            CalibrationSample();
        }

        #endregion

        private void ipTb_TextChanged(object sender, EventArgs e)
        {
            ip = ipTb.Text;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            GetStuff();
        }
    }
}
