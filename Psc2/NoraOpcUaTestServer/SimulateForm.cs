﻿using System;
using System.Threading;
using System.Windows.Forms;

namespace NoraOpcUaTestServer
{
    public partial class SimulateForm : Form
    {
        private readonly MainForm mainForm;
        private bool simulate;
        private Thread simThread;

        public SimulateForm(MainForm mainForm)
        {
            InitializeComponent();
            this.mainForm = mainForm;
        }

        private void SimulateForm_Load(object sender, EventArgs e)
        {

        }

        private void StartSimulation()
        {
            var measureTime = TimeSpan.FromMinutes(int.Parse(MeasureTb.Text));
            var cipTime = TimeSpan.FromMinutes(int.Parse(CipTb.Text));
            var stopTime = TimeSpan.FromMinutes(int.Parse(StopTb.Text));

            while (simulate)
            {
                mainForm.CurrentState.StartStopMeasuring("");
                Thread.Sleep(measureTime);
                mainForm.CurrentState.SetCip();
                Thread.Sleep(cipTime);
                mainForm.CurrentState.StartStopMeasuring("");
                Thread.Sleep(stopTime);
            }
        }

        private void StartButton_Click(object sender, EventArgs e)
        {
            this.simulate = true;
            simThread = new Thread(StartSimulation);
            simThread.Start();
        }

        private void CloseButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void SimulateForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            OnClose();
        }

        private void OnClose()
        {
            simulate = false;
            simThread.Join();
        }
    }
}
