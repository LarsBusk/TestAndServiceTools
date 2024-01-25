using NiceLittleLogger;
using DexterOpcUaTestServer.OpcNodes;
using Opc.UaFx;
using System;

namespace DexterOpcUaTestServer.Logging
{
    public class LogHelper
    {
        private readonly CsvWriter _csvWriter;
        private readonly CsvWriter _jitterCsvWriter;
        private readonly Logger _logger;
        private readonly Logger _simLogger;
        private OpcUaHelper _helper;
        private DateTime lastOpcServerDateTime = DateTime.MinValue;
        private int sampleCounter;

        public static bool IsSimulating;

        public LogHelper(OpcUaHelper helper)
        {
            _helper = helper;
            _csvWriter = new CsvWriter("Logs","MeasuredValues.csv",
                "Time;SampleCounter;SampleNumber;Fat;Weight;Bone;Metal\n");
            _jitterCsvWriter =
                new CsvWriter("Logs", "Jitter.csv",
                    "OpcServerTime;SampleTime;SampleCounter;SampleNumber;TimeBetweenSamples;Delay;\n");

            _logger = new Logger("Logs", "NodeValues.txt");
            _simLogger = new Logger("Logs", "SimulatorLog.txt");
            IsSimulating = false;

            _helper.Nodes.BatchNodes.ParameterNodes.BoneValue.AfterApplyChanges += SampleCounter_AfterApplyChanges;
            _helper.Nodes.InstrumentNodes.SampleCounter.BeforeApplyChanges += SampleCounter_BeforeApplyChanges;
            _helper.Nodes.BatchNodes.ParameterNodes.FatValue.AfterApplyChanges += ResultNode_AfterApplyChanges;
            _helper.Nodes.BatchNodes.ParameterNodes.WeightValue.AfterApplyChanges += ResultNode_AfterApplyChanges;
            _helper.Nodes.BatchNodes.ParameterNodes.BoneValue.AfterApplyChanges += ResultNode_AfterApplyChanges;
            _helper.Nodes.BatchNodes.ParameterNodes.MetalValue.AfterApplyChanges += ResultNode_AfterApplyChanges;
            _helper.Nodes.SampleNodes.SampleNumber.AfterApplyChanges += ResultNode_AfterApplyChanges;
            _helper.Nodes.InstrumentNodes.ModeN.AfterApplyChanges += LogSim;
        }

        private void SampleCounter_BeforeApplyChanges(object sender, OpcNodeChangesEventArgs e)
        {
            var node = (OpcDataVariableNode)sender;
            var nodeTime = node.Timestamp ?? DateTime.Now;
            string name = node.DisplayName;
            var value = node.Value;

            if (SettingsForm.LogOptions.LogStates)
            {
                _logger.LogInfo($"{name} before change value: {value} at {nodeTime.ToString("O")}");
            }
        }

        private void LogValues(NoraNodes nodes, DateTime opcServerDateTime)
        {
            var fatValue = nodes.BatchNodes.ParameterNodes.FatValue.Value;
            var weightValue = nodes.BatchNodes.ParameterNodes.WeightValue.Value;
            var boneValue = nodes.BatchNodes.ParameterNodes.BoneValue.Value;
            var metalValue = nodes.BatchNodes.ParameterNodes.MetalValue.Value;
            //var sampleCounter = nodes.InstrumentNodes.SampleCounter.Value;
            var sampleNumber = nodes.SampleNodes.SampleNumber.Value;
            //var sampleRegistrationValue = nodes.SampleNodes.SampleRegistrationValue.Value;

            _csvWriter.WriteValues(opcServerDateTime, sampleCounter, sampleNumber, fatValue,
                weightValue, boneValue,
                metalValue);
        }

        #region EventHandlers

        private void SampleCounter_AfterApplyChanges(object sender, OpcNodeChangesEventArgs e)
        {
            ResultNode_AfterApplyChanges(sender, e);
            var node = (OpcDataVariableNode)sender;
            var opcServerDateTime = node.Timestamp ?? DateTime.Now;
            sampleCounter ++;//= (uint)node.Value;
            var timeDif = 0;
            var sampleNumber = _helper.Nodes.SampleNodes.SampleNumber.Value;
            var sampleDateTime = _helper.Nodes.SampleNodes.TimeStampNodes.SampleDateTime.Value;

            if (lastOpcServerDateTime > DateTime.MinValue)
                timeDif = (int)opcServerDateTime.Subtract(lastOpcServerDateTime).TotalMilliseconds;

            var delay = (int)opcServerDateTime.Subtract(sampleDateTime).TotalMilliseconds;

            if (SettingsForm.LogOptions.LogJitter)
            {
                _jitterCsvWriter.WriteValues(opcServerDateTime, sampleDateTime.ToString("yyyy-MM-dd HH:mm:ss,fff"),
                    sampleCounter, sampleNumber, timeDif, delay);
            }

            if (SettingsForm.LogOptions.LogMeasuredValues)
            {
                LogValues(_helper.Nodes, opcServerDateTime);
            }

            lastOpcServerDateTime = opcServerDateTime;
        }

        private void ResultNode_AfterApplyChanges(object sender, OpcNodeChangesEventArgs e)
        {
            var node = (OpcDataVariableNode)sender;
            var nodeTime = node.Timestamp ?? DateTime.Now;
            string name = node.DisplayName;
            var value = node.Value;

            if (SettingsForm.LogOptions.LogStates)
            {
                _logger.LogInfo($"{name} changed value: {value} at {nodeTime.ToString("O")}");
            }
        }

        private void LogSim(object sender, OpcNodeChangesEventArgs e)
        {
            var node = (OpcDataVariableNode)sender;
            var nodeTime = node.Timestamp ?? DateTime.Now;
            var name = node.Name;
            var parrent = node.Parent.Name;
            var value = node.Value;

            if (IsSimulating)
            {
                _simLogger.LogInfo($"{parrent}.{name} changed value: {value} at {nodeTime.ToString("O")}");
            }
        }

        #endregion
    }
}
