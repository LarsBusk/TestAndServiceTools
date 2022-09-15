using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Opc.UaFx;

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
            logger = new Logger("Alarm.log");
            this.helper = helper;
            GetCurrentAlarms();

            helper.UninterruptableMode.AfterApplyChanges += AlarmHasChanged;
            helper.Zeroincomplete.AfterApplyChanges += AlarmHasChanged;
            helper.CabinetDoorOpen.AfterApplyChanges += AlarmHasChanged;
        }

        private void GetCurrentAlarms()
        {
            UpdateLabelColour(UninterruptibleModeLabel, helper.UninterruptableMode.Value ? Color.Red : Color.Black);
            UpdateLabelColour(ZeroSettingIncompleteLabel, helper.Zeroincomplete.Value ? Color.Red : Color.Black);
            UpdateLabelColour(CabinetDoorOpenLabel, helper.CabinetDoorOpen.Value ? Color.Red : Color.Black);
        }

        private void AlarmHasChanged(object sender, Opc.UaFx.OpcNodeChangesEventArgs e)
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
                case "CabinetDoorOpen":
                    label = CabinetDoorOpenLabel;
                    break;
                case "ZeroSettingIncomplete":
                    label = ZeroSettingIncompleteLabel;
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
