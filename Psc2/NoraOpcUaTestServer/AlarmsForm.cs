﻿using Opc.UaFx;
using System;
using System.Drawing;
using System.Windows.Forms;
using NiceLittleLogger;

namespace NoraOpcUaTestServer
{
    public partial class AlarmsForm : Form
    {
        private OpcUaHelper helper;
        private Logger logger;
        private delegate void UpdateLabelTextCallback(Label label, Color colour);

        public AlarmsForm(OpcUaHelper helper)
        {
            InitializeComponent();
            logger = new Logger("Logs","Alarm.log");
            this.helper = helper;
            GetCurrentAlarms();

            helper.Nodes.AlarmNodes.UninterruptibleMode.AfterApplyChanges += AlarmHasChanged;
            helper.Nodes.AlarmNodes.ZeroSettingIncomplete.AfterApplyChanges += AlarmHasChanged;
            helper.Nodes.AlarmNodes.SystemAlarms.AfterApplyChanges += AlarmHasChanged;
            helper.Nodes.AlarmNodes.CabinetDoorOpen.AfterApplyChanges += AlarmHasChanged;
        }

        private void GetCurrentAlarms()
        {
            UpdateLabelColour(UninterruptibleModeLabel, helper.Nodes.AlarmNodes.UninterruptibleMode.Value ? Color.Red : Color.Black);
            UpdateLabelColour(ZeroSettingIncompleteLabel, helper.Nodes.AlarmNodes.ZeroSettingIncomplete.Value ? Color.Red : Color.Black);
            UpdateLabelColour(SystemAlarmsLabel, helper.Nodes.AlarmNodes.SystemAlarms.Value ? Color.Red : Color.Black);
            UpdateLabelColour(cabinetDoorOpenLabel, helper.Nodes.AlarmNodes.CabinetDoorOpen.Value ? Color.Red : Color.Black);
        }

        private void AlarmHasChanged(object sender, OpcNodeChangesEventArgs e)
        {
            var alarm = (OpcDataVariableNode<bool>)sender;
            var colour = alarm.Value ? Color.Red : Color.Black;
            var nodeName = alarm.DisplayName.ToString();
            Label label = UninterruptibleModeLabel;

            switch (nodeName)
            {
                case "UninterruptibleMode":
                    label = UninterruptibleModeLabel;
                    break;
                case "SystemAlarms":
                    label = SystemAlarmsLabel;
                    break;
                case "ZeroSettingIncomplete":
                    label = ZeroSettingIncompleteLabel;
                    break;
                case "CabinetDoorOpen":
                    label = cabinetDoorOpenLabel;
                    break;
            }

            logger.LogInfo($"{nodeName}: {alarm.Value}, {alarm.Timestamp}");
            UpdateLabelColour(label, colour);
        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void UpdateLabelColour(Label label, Color colour)
        {
            if (label.InvokeRequired)
            {
                UpdateLabelTextCallback d = new UpdateLabelTextCallback(UpdateLabelColour);
                this.Invoke(d, new object[] { label, colour });
                return;
            }

            label.ForeColor = colour;
        }
    }
}
