using log4net;
using OPCClient.Communicators;
using System;
using System.ComponentModel;
using System.IO;
using System.Runtime.CompilerServices;
using System.Timers;
using System.Windows;
using System.Xml;
using System.Xml.Serialization;
using Timer = System.Timers.Timer;

namespace RegistrationClient
{
    class MainWindowViewModel : INotifyPropertyChanged
    {
        #region Public properties

        public string Value1
        {
            get => value1.ToString();

            set
            {
                if (int.TryParse(value, out value1))
                {
                    NotifyPropertyChanged();
                }
            }
        }

        public string Value2
        {
            get => value2.ToString();

            set
            {
                if (int.TryParse(value, out value2))
                {
                    NotifyPropertyChanged();
                }
            }
        }

        public bool InsertRandom
        {
            get => insertRandom;

            set
            {
                insertRandom = value;
                NotifyPropertyChanged();
            }
        }

        public bool SendProductCode
        {
            get => sendProductCode;

            set
            {
                sendProductCode = value;
                NotifyPropertyChanged();
            }
        }

        public bool SendRegistrations
        {
            get => sendRegistrations;

            set
            {
                sendRegistrations = value;
                NotifyPropertyChanged();
            }
        }

        public bool Continous
        {
            get => continous;

            set
            {
                continous = value;
                SetButtonIsEnabled = !value;
                NotifyPropertyChanged();
            }
        }

        public bool SetButtonIsEnabled
        {
            get => setButtonIsEnabled;

            set
            {
                setButtonIsEnabled = value;
                NotifyPropertyChanged();
            }
        }

        public string Server
        {
            get => server;

            set
            {
                server = value;
                NotifyPropertyChanged();
            }
        }

        public int SampleId
        {
            get => sampleId;

            set
            {
                sampleId = value;
                UpdateStatus();
                NotifyPropertyChanged();
            }
        }

        public bool SimulateBoxes
        {
            get => simulateBoxes;

            set
            {
                simulateBoxes = value;
                InsertRandomEnabled = !simulateBoxes;
                NotifyPropertyChanged();
            }
        }

        public bool MeasureButtonEnabled
        {
            get => measureButtonEnabled;

            set
            {
                measureButtonEnabled = value;
                NotifyPropertyChanged();
            }
        }

        public string MeasureButtonText
        {
            get => measureButtonText;

            set
            {
                measureButtonText = value;
                NotifyPropertyChanged();
            }
        }

        public int ModeN
        {
            get => modeN;

            set
            {
                modeN = value;
                UpdateStatus();
                NotifyPropertyChanged();
            }
        }

        public int ProductCodeN
        {
            get => productCodeN;

            set
            {
                productCodeN = value;
                //SetProductCode(productCodeN);
                NotifyPropertyChanged();
            }
        }

        public bool IsConnected
        {
            get => isConnected;

            set
            {
                isConnected = value;
                ConnectButtonText = isConnected ? "Disconnect" : "Connect";
                NotifyPropertyChanged();
            }
        }

        public string ConnectButtonText
        {
            get => connectButtonText;

            set
            {
                connectButtonText = value;
                NotifyPropertyChanged();
            }
        }

        public string Status
        {
            get => status;

            set
            {
                status = value;
                NotifyPropertyChanged();
            }
        }

        public string Group
        {
            get => @group;

            set
            {
                @group = value;
                NotifyPropertyChanged();
            }
        }

        public bool InsertRandomEnabled
        {
            get => insertRandomEnabled;

            set
            {
                insertRandomEnabled = value;
                NotifyPropertyChanged();
            }
        }

        public string Watchdog
        {
            get => watchdog;

            set
            {
                watchdog = value;
                NotifyPropertyChanged();
            }
        }

        public SampleVariationController SampleVariationController { get; set; }

        #endregion

        #region Private fields

        private int value1;

        private int value2;

        private bool insertRandom;

        private bool sendRegistrations;

        private bool continous;

        private int sampleId;

        private string server;

        private bool isKepServer;

        private bool setButtonIsEnabled;

        private bool measureButtonEnabled = false;

        private string measureButtonText = "Start";

        private Timer mainTimer;

        private string watchdog;

        private int watchdogCounter;

        private int oldWatchog = -1;

        private bool simulateBoxes;

        private bool sendProductCode;

        private bool isMeasuring;

        private int modeN;

        private int productCodeN;

        private bool isConnected;

        private string connectButtonText;

        private KepServerCommunicator kepServerCommunicator;

        private string group;

        private string status;

        private bool insertRandomEnabled = true;

        private readonly ILog log = LogManager.GetLogger(typeof(MainWindowViewModel));

        #endregion

        #region public methods

        public MainWindowViewModel()
        {
            log4net.Config.XmlConfigurator.Configure();
            log.Debug("Starting up...");
            mainTimer = new Timer(100);
            mainTimer.Enabled = false;
            mainTimer.Elapsed += MainTimerOnElapsed;
            SampleVariationController = new SampleVariationController();
            Initialize();
        }

        public void InsertValues()
        {
            if (InsertRandom)
            {
                RegistrationValues values = SampleVariationController.GetRandomValues();
                Value1 = values.RegValue1.ToString();
                Value2 = values.RegValue2.ToString();
                ProductCodeN = values.ProductCode;
            }

            if (SimulateBoxes)
            {
                RegistrationValues values = SampleVariationController.GetValuesFromBoxes();
                Value1 = values.RegValue1.ToString();
                Value2 = values.RegValue2.ToString();
                ProductCodeN = values.ProductCode;
            }

            WriteValues();
        }

        public void StartStopMeasuring()
        {
            if (isMeasuring)
            {
                KepServerCommunicator.KepServerStartMeasuring(false);
                return;
            }

            KepServerCommunicator.KepServerStartMeasuring(true);
        }

        #endregion

        #region Private methods

        private void LoadBoxIds()
        {
            BoxIdentifiers boxIdentifiers = new BoxIdentifiers();

            if (!File.Exists("Boxes.xml"))
            {
                WriteBoxFile();
            }

            using (XmlReader reader = XmlReader.Create("Boxes.xml"))
            {
                XmlSerializer serializer = new XmlSerializer(typeof(BoxIdentifiers));
                boxIdentifiers = (BoxIdentifiers)serializer.Deserialize(reader);
                SampleVariationController.SampleIds = boxIdentifiers.SampleIds;
                SampleVariationController.ProductCodes = boxIdentifiers.ProductCodes;
            }
        }

        private void WriteBoxFile()
        {
            BoxIdentifiers boxIdentifiers = new BoxIdentifiers();
            boxIdentifiers.SampleIds.AddRange(new int[] { 12, 13, 14 });
            boxIdentifiers.ProductCodes.AddRange(new[] { 101, 102, 103, 104 });
            XmlSerializer serializer = new XmlSerializer(typeof(BoxIdentifiers));

            using (XmlWriter writer = XmlWriter.Create("Boxes.xml"))
            {
                serializer.Serialize(writer, boxIdentifiers);
                writer.Flush();
            }
        }

        private void Initialize()
        {
            Server = "KepServer";
            ConnectButtonText = "Connect";
            Group = "MMII.PDx";
            IsConnected = false;
            Continous = false;
            SampleId = -1;
            LoadBoxIds();
            log.Debug("Initialization done.");
        }



        private void MainTimerOnElapsed(object sender, ElapsedEventArgs elapsedEventArgs)
        {
            KepServerCommunicator.OpcHelp.OPCGetData.ReadAllOPCData();

            UpdateMode();
            UpdateWatchDog();

            int currentSampleId = KepServerCommunicator.KepServerOpcTags.InstrumentGroup.SampleCounter.Value;

            if (currentSampleId == SampleId)
                return;

            log.Debug($"Current sampleId is {currentSampleId}, last sampleId is {SampleId}");
            SampleId = currentSampleId;

            if (Continous) InsertValues();
        }

        private void UpdateMeasureButton()
        {
            switch (modeN)
            {
                case 5:
                    MeasureButtonEnabled = true;
                    MeasureButtonText = "Start";
                    break;
                case 6:
                    MeasureButtonEnabled = true;
                    MeasureButtonText = "Stop";
                    break;
                default:
                    MeasureButtonEnabled = false;
                    MeasureButtonText = "Start";
                    break;
            }
        }

        private void UpdateWatchDog()
        {
            int watchdogIn = KepServerCommunicator.KepServerOpcTags.InstrumentGroup.WatchdogCounter.Value;

            if (watchdogIn == oldWatchog) return;

            watchdogCounter = (watchdogCounter > 65000) ? 0 : watchdogCounter++;


            KepServerCommunicator.UpdateWatchDogCounter(watchdogCounter);
            Watchdog = $"Wd in {watchdogIn} Wd out {watchdogCounter}";


        }

        private void UpdateMode()
        {
            ModeN = KepServerCommunicator.KepServerOpcTags.InstrumentGroup.ModeN.Value;
        }

        private bool ConnectToKepServer()
        {
            try
            {
                kepServerCommunicator.ConnectToKepServer("Kepware.KEPServerEX.V6", Group);
                if (modeN.Equals(5))
                    KepServerCommunicator.KepServerStartMeasuring(false);
                return true;
            }
            catch (Exception exception)
            {
                MessageBox.Show($"{exception.Message}\n{exception.InnerException}");
                log.Error($"Failed connecting to KepServer {exception}");
                return false;
            }
        }

        private void WriteValues()
        {
            if (SendRegistrations)
            {
                SampleVariationController.WriteRegistrationValuesToPDxTags();
            }

            if (SendProductCode) SampleVariationController.WriteProductCodeN(ProductCodeN);
        }

        private void UpdateStatus()
        {
            Status = $"Mode: {ModeN} Samplecounter: {SampleId}";
            isMeasuring = modeN.Equals(6);
            //log.Debug(Status);

            UpdateMeasureButton();
        }

        #endregion

        #region Implement INotifyPropertyChanged

        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChangedEventArgs args = new PropertyChangedEventArgs(propertyName);
                PropertyChanged(this, args);
            }
        }

        #endregion

        internal void DisConnect()
        {
            KepServerCommunicator.OpcHelp.Disconnect();
            IsConnected = false;
            mainTimer.Stop();
        }

        internal void ConnectToServer()
        {
            kepServerCommunicator = new KepServerCommunicator();
            log.Debug("Connecting to KepServer.");
            IsConnected = ConnectToKepServer();
            mainTimer.Start();
            SampleVariationController.IsKepServer = isKepServer;
        }
    }
}
