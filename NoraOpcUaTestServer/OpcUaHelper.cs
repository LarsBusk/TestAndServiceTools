using Opc.UaFx;
using Opc.UaFx.Server;
using System;
using System.Threading;
using NoraOpcUaTestServer.OpcNodes;

namespace NoraOpcUaTestServer
{
    public class OpcUaHelper
    {
        #region Public properties

        public double FatValue => this.noraNodes.SampleNodes.ParametersNodes.FatValue.Value;
        public string FatUnit => this.noraNodes.SampleNodes.ParametersNodes.FatUnit.Value;
        public double ProteinValue => this.noraNodes.SampleNodes.ParametersNodes.ProteinValue.Value;
        public string ProteinUnit => this.noraNodes.SampleNodes.ParametersNodes.ProteinUnit.Value;
        public double LactoseValue => this.noraNodes.SampleNodes.ParametersNodes.LactoseValue.Value;
        public double TsValue => this.noraNodes.SampleNodes.ParametersNodes.TsValue.Value;
        public double SnfValue => noraNodes.SampleNodes.ParametersNodes.SnfValue.Value;
        public string SampleNumber => noraNodes.SampleNodes.SampleNumber.Value;
        public string SampleRegistrationValue => noraNodes.SampleNodes.SampleRegistrationValue.Value;
        public DateTime SampleDateTime => noraNodes.SampleNodes.TimeStampNodes.SampleDateTime.Value;
        public int Mode => this.noraNodes.InstrumentNodes.ModeN.Value;
        public OpcDataVariableNode<string> ProductName => this.noraNodes.InstrumentNodes.ProductName;
        public OpcDataVariableNode<uint> EventsCount => noraNodes.EventNodes.EventsCount;
        public string[] EventMessages => noraNodes.EventNodes.EventMessages.Value;

        public OpcServer Server;
        public OpcDataVariableNode<string> StateNode => noraNodes.InstrumentNodes.State;
        public OpcDataVariableNode<uint> WatchdogNode => noraNodes.InstrumentNodes.WatchdogNode;
        public OpcDataVariableNode<uint> SampleCounterNode => this.noraNodes.InstrumentNodes.SampleCounter;

        #region AlarmNodes

        public OpcDataVariableNode<bool> UninterruptableMode => noraNodes.AlarmNodes.UninterruptibleMode;
        public OpcDataVariableNode<bool> Zeroincomplete => noraNodes.AlarmNodes.ZeroSettingIncomplete;
        public OpcDataVariableNode<bool> SystemAlarms => noraNodes.AlarmNodes.SystemAlarms;
        public OpcDataVariableNode<bool> CabinetDoorOpen => noraNodes.AlarmNodes.CabinetDoorOpen;

        #endregion


        #endregion

        #region Private fields

        private readonly NoraNodes noraNodes;
        private readonly CsvHelper csvHelper;
        private readonly Logger logger;
        private DateTime lastOpcServerDateTime = DateTime.MinValue;

        #endregion



        public OpcUaHelper(string serverName, string homeFolderName = "Foss.Nora")
        {
            noraNodes = new NoraNodes(homeFolderName);
            csvHelper = new CsvHelper();
            logger = new Logger("NodeValues.txt");

            Opc.UaFx.Licenser.LicenseKey =
                "AALSA4IRQPJKOGVQOZP32DTKRRNAIWS3CQLTG7RJEPUAZGVQG6NPQK2OL4DOJNVLSSUDQOEUY5KDHHJWYQSTXUITOEOGOOFL2R5TEIIMCGFE5JV6CQM7TDVFY35SPAB" +
                "5T4YNCIPWM2Y7YCY2ZLFSWL5ZU64WK3J4M7AL7CCMS7SPGXUJ22YFGCJUV6F5OZALRVWJ5W73O6CQUGPEFZQJVHYZS3ORBJ75O3BS6N2JM75CCQTK5V6NIQOUB2PIHK" +
                "C6XIA7OU6PYI6NX5XAABZ7QGSNRZICR44DL5OGS2DXUQV4JBDAXDLXYK3VDBPDEFEUR7E2CBVAU4BI6I2EYJ3MRUNYTQK5UQXDKCOEMKZW52XMK3X27YNRPMNPNSSJF" +
                "LT737QGAJILKL2KCQFSW4PSN7BXXGT3GUQO4BBL7MUKZ5EUTQRE3DTAQATVRPL427ZPZJOLBNDGUOGH6L4SH34PFHHANIG2IKNLPVN3OFNKHFHA4ZFFKOV5W2SBLCMM" +
                "7JFAGAA7VH6AW56COVRCXJ5OWACCUVQ7OBRZV5TG3QODO67J444B7MALRM2OV7KZ5RG7FJLXZXQNWKTG7ZRHSNNRMVOMLI37IEOSO4E5FN5YRZKGZMAJHWYIKNZ7TPR" +
                "IRHTTZ2ZJCAVWIIYP3O2WI5RQQ3QZT5YIN477RSEML6AX226MIGNWMLYAHJNC6IDLQQF2E5VAQCTQYCJI7CH3NOWYJDANMP5RA74LVYMRAX326BZ4S3MPU6SC6RRV7C" +
                "HKBAPKEU6YE464ZFRQ7IPACBBUMKZ22P6ZEP4D3AJOQU4P4EGRTNDNJ7QVIS4OFBKYWNLN4FE6L6ASYF2QMDRXD3AM2OJMW4ZVQ7LNFVRMEVKAQX7HYYBWXGCDKML57" +
                "64TEQITT3TGRWNJB7HDBEZYK3UCBVDXQ7BTWZT6PGS2COL2ZHKMK6O3LGKUB5KXRYSQYM76SAWOANBS7FAPNYE2O6SYOIAZRQQAAHK5EDDYR3XVMGDQHGTESGEDTVQZ" +
                "VSBANGDJBTYCHKC7TILXWXJP64DDSDVSNAAWE2AF4KXDJFUYJNVIMEEDMLCJXVVSH27QB4NT3U6YPEEAD62NKXCU2H3MY5T2DHHC2NHCR2AOZJFHNASEBB7OLZ32GLJ" +
                "APLH3XEINORMCAUJJL6H3X2ODOPPLDBPL5T6HPS7EENJJAKWSZV622J65FXMI2QZCWEGAAOEV6A56FSAHNWUS3MFPBMBB";

            Server = new OpcServer(
                serverName,
                noraNodes.Nodes);

            SampleCounterNode.AfterApplyChanges += SampleCounter_AfterApplyChanges;
            noraNodes.SampleNodes.ParametersNodes.FatValue.AfterApplyChanges += ResultNode_AfterApplyChanges;
            noraNodes.SampleNodes.ParametersNodes.ProteinValue.AfterApplyChanges += ResultNode_AfterApplyChanges;
            noraNodes.SampleNodes.ParametersNodes.LactoseValue.AfterApplyChanges += ResultNode_AfterApplyChanges;
            noraNodes.SampleNodes.ParametersNodes.SnfValue.AfterApplyChanges += ResultNode_AfterApplyChanges;
            noraNodes.SampleNodes.ParametersNodes.TsValue.AfterApplyChanges += ResultNode_AfterApplyChanges;
            noraNodes.SampleNodes.SampleNumber.AfterApplyChanges += ResultNode_AfterApplyChanges;

        }

        private void ResultNode_AfterApplyChanges(object sender, OpcNodeChangesEventArgs e)
        {
            var node = (OpcDataVariableNode)sender;
            var nodeTime = node.Timestamp ?? DateTime.Now;
            string name = node.DisplayName;
            var value = node.Value;

            logger.LogInfo($"{name} changed value: {value} at {nodeTime.ToString("O")}");
        }


        public void StartServer()
        {
            Server.Start();
        }

        public void StopServer()
        {
            Server.Stop();
        }

        public void StartMeasuring(string product)
        {
            SetNodeValue(noraNodes.ControllerNodes.ProductCode, product);
            SetNodeValue(noraNodes.ControllerNodes.ModeN, 1);
        }

        public void StopMeasuring()
        {
            SetNodeValue(noraNodes.ControllerNodes.ModeN, 0);
        }

        public void SetCip()
        {
            SetNodeValue(noraNodes.ControllerNodes.ModeN, 2);
        }

        public void ChangeProduct(string newProduct)
        {
            SetNodeValue<string>(noraNodes.ControllerNodes.ProductCode, newProduct);
        }

        public void EnqueueZero()
        {
            ToggleNode(noraNodes.ControllerNodes.ZeroToQueue, TimeSpan.FromMilliseconds(500));
        }

        public void EnqueueClean()
        {
            ToggleNode(noraNodes.ControllerNodes.CleanToQueue, TimeSpan.FromMilliseconds(500));
        }

        public void SetSampleRegistration(string registration)
        {
            SetNodeValue<string>(noraNodes.ControllerNodes.SampleRegistration, registration);
        }

        public void SetNoDelayedResults(bool state)
        {
            SetNodeValue(noraNodes.ControllerNodes.NoDelayedResults, state);
        }

        private void SetNodeValue<T>(OpcDataVariableNode<T> node, object value)
        {
            node.Value = (T)value;
            node.ApplyChanges(Server.SystemContext);
        }

        private void SampleCounter_AfterApplyChanges(object sender, Opc.UaFx.OpcNodeChangesEventArgs e)
        {
            ResultNode_AfterApplyChanges(sender, e);
            var node = (OpcDataVariableNode)sender;
            var opcServerDateTime = node.Timestamp ?? DateTime.Now;
            var sampleCounter = (uint)node.Value;
            var timeDif = TimeSpan.Zero;

            if (lastOpcServerDateTime > DateTime.MinValue)
                timeDif = opcServerDateTime.Subtract(lastOpcServerDateTime);
            
            var delay = opcServerDateTime.Subtract(SampleDateTime);

            csvHelper.WriteValues(opcServerDateTime, sampleCounter, SampleNumber, SampleRegistrationValue, FatValue, ProteinValue, LactoseValue,
                TsValue, SnfValue, timeDif, delay);

            lastOpcServerDateTime = opcServerDateTime;
        }

        private void ToggleNode(OpcDataVariableNode<bool> node, TimeSpan onTime)
        {
            SetNodeValue(node, true);
            Thread.Sleep(onTime);
            SetNodeValue(node, false);
        }
    }
}
