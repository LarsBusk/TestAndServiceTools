﻿namespace MstOpcClient
{
  partial class MainForm
  {
    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    /// Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing)
    {
      if (disposing && (components != null))
      {
        components.Dispose();
      }
      base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
            this.components = new System.ComponentModel.Container();
            this.kepServerGroupBox = new System.Windows.Forms.GroupBox();
            this.UsePrdCpdeNChk = new System.Windows.Forms.CheckBox();
            this.lblConnected = new System.Windows.Forms.Label();
            this.btnDisconnect = new System.Windows.Forms.Button();
            this.btnConnect = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tbGroupName = new System.Windows.Forms.TextBox();
            this.cbOpcServer = new System.Windows.Forms.ComboBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label5 = new System.Windows.Forms.Label();
            this.loggingTimeTb = new System.Windows.Forms.TextBox();
            this.startLoggingBtn = new System.Windows.Forms.Button();
            this.ProductCodeLbl = new System.Windows.Forms.Label();
            this.tbProductCode = new System.Windows.Forms.TextBox();
            this.lblState = new System.Windows.Forms.Label();
            this.btnCalibration = new System.Windows.Forms.Button();
            this.btnStartStop = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tbPauseTime = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.tbMeasureTime = new System.Windows.Forms.TextBox();
            this.btnStartSimulation = new System.Windows.Forms.Button();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.lblSimCounter = new System.Windows.Forms.Label();
            this.lblSampleCounter = new System.Windows.Forms.Label();
            this.lblCalibrationSample = new System.Windows.Forms.Label();
            this.lblWatchdog = new System.Windows.Forms.Label();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.tbCalRegValue = new System.Windows.Forms.TextBox();
            this.cbAddReg = new System.Windows.Forms.CheckBox();
            this.kepServerGroupBox.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // kepServerGroupBox
            // 
            this.kepServerGroupBox.Controls.Add(this.UsePrdCpdeNChk);
            this.kepServerGroupBox.Controls.Add(this.lblConnected);
            this.kepServerGroupBox.Controls.Add(this.btnDisconnect);
            this.kepServerGroupBox.Controls.Add(this.btnConnect);
            this.kepServerGroupBox.Controls.Add(this.label2);
            this.kepServerGroupBox.Controls.Add(this.label1);
            this.kepServerGroupBox.Controls.Add(this.tbGroupName);
            this.kepServerGroupBox.Controls.Add(this.cbOpcServer);
            this.kepServerGroupBox.Location = new System.Drawing.Point(12, 240);
            this.kepServerGroupBox.Name = "kepServerGroupBox";
            this.kepServerGroupBox.Size = new System.Drawing.Size(285, 154);
            this.kepServerGroupBox.TabIndex = 0;
            this.kepServerGroupBox.TabStop = false;
            this.kepServerGroupBox.Text = "KepServer";
            this.toolTip1.SetToolTip(this.kepServerGroupBox, "Select the version of Kepserver and type the group name, then click connect.");
            // 
            // UsePrdCpdeNChk
            // 
            this.UsePrdCpdeNChk.AutoSize = true;
            this.UsePrdCpdeNChk.Checked = true;
            this.UsePrdCpdeNChk.CheckState = System.Windows.Forms.CheckState.Checked;
            this.UsePrdCpdeNChk.Location = new System.Drawing.Point(115, 124);
            this.UsePrdCpdeNChk.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.UsePrdCpdeNChk.Name = "UsePrdCpdeNChk";
            this.UsePrdCpdeNChk.Size = new System.Drawing.Size(118, 17);
            this.UsePrdCpdeNChk.TabIndex = 7;
            this.UsePrdCpdeNChk.Text = "Use ProductCodeN";
            this.UsePrdCpdeNChk.UseVisualStyleBackColor = true;
            // 
            // lblConnected
            // 
            this.lblConnected.AutoSize = true;
            this.lblConnected.Location = new System.Drawing.Point(21, 124);
            this.lblConnected.Name = "lblConnected";
            this.lblConnected.Size = new System.Drawing.Size(61, 13);
            this.lblConnected.TabIndex = 6;
            this.lblConnected.Text = "Connection";
            // 
            // btnDisconnect
            // 
            this.btnDisconnect.Location = new System.Drawing.Point(182, 89);
            this.btnDisconnect.Name = "btnDisconnect";
            this.btnDisconnect.Size = new System.Drawing.Size(75, 23);
            this.btnDisconnect.TabIndex = 5;
            this.btnDisconnect.Text = "Disconnect";
            this.btnDisconnect.UseVisualStyleBackColor = true;
            this.btnDisconnect.Click += new System.EventHandler(this.btnDisconnect_Click);
            // 
            // btnConnect
            // 
            this.btnConnect.Location = new System.Drawing.Point(182, 38);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(75, 23);
            this.btnConnect.TabIndex = 4;
            this.btnConnect.Text = "Connect";
            this.btnConnect.UseVisualStyleBackColor = true;
            this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(20, 73);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(36, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Group";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(20, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "KepServer";
            // 
            // tbGroupName
            // 
            this.tbGroupName.Location = new System.Drawing.Point(23, 89);
            this.tbGroupName.Name = "tbGroupName";
            this.tbGroupName.Size = new System.Drawing.Size(121, 20);
            this.tbGroupName.TabIndex = 1;
            // 
            // cbOpcServer
            // 
            this.cbOpcServer.FormattingEnabled = true;
            this.cbOpcServer.Location = new System.Drawing.Point(23, 38);
            this.cbOpcServer.Name = "cbOpcServer";
            this.cbOpcServer.Size = new System.Drawing.Size(121, 21);
            this.cbOpcServer.TabIndex = 0;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.cbAddReg);
            this.groupBox2.Controls.Add(this.tbCalRegValue);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.loggingTimeTb);
            this.groupBox2.Controls.Add(this.startLoggingBtn);
            this.groupBox2.Controls.Add(this.ProductCodeLbl);
            this.groupBox2.Controls.Add(this.tbProductCode);
            this.groupBox2.Controls.Add(this.lblState);
            this.groupBox2.Controls.Add(this.btnCalibration);
            this.groupBox2.Controls.Add(this.btnStartStop);
            this.groupBox2.Location = new System.Drawing.Point(12, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(284, 218);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Control";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(29, 149);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(89, 13);
            this.label5.TabIndex = 10;
            this.label5.Text = "Logging time (ms)";
            // 
            // loggingTimeTb
            // 
            this.loggingTimeTb.Location = new System.Drawing.Point(32, 165);
            this.loggingTimeTb.Name = "loggingTimeTb";
            this.loggingTimeTb.Size = new System.Drawing.Size(100, 20);
            this.loggingTimeTb.TabIndex = 9;
            this.loggingTimeTb.Text = "100";
            // 
            // startLoggingBtn
            // 
            this.startLoggingBtn.Location = new System.Drawing.Point(156, 164);
            this.startLoggingBtn.Name = "startLoggingBtn";
            this.startLoggingBtn.Size = new System.Drawing.Size(101, 23);
            this.startLoggingBtn.TabIndex = 8;
            this.startLoggingBtn.Text = "StartLogging";
            this.startLoggingBtn.UseVisualStyleBackColor = true;
            this.startLoggingBtn.Click += new System.EventHandler(this.startLoggingBtn_Click);
            // 
            // ProductCodeLbl
            // 
            this.ProductCodeLbl.AutoSize = true;
            this.ProductCodeLbl.Location = new System.Drawing.Point(21, 23);
            this.ProductCodeLbl.Name = "ProductCodeLbl";
            this.ProductCodeLbl.Size = new System.Drawing.Size(77, 13);
            this.ProductCodeLbl.TabIndex = 7;
            this.ProductCodeLbl.Text = "ProductCodeN";
            // 
            // tbProductCode
            // 
            this.tbProductCode.Enabled = false;
            this.tbProductCode.Location = new System.Drawing.Point(24, 39);
            this.tbProductCode.Name = "tbProductCode";
            this.tbProductCode.Size = new System.Drawing.Size(100, 20);
            this.tbProductCode.TabIndex = 6;
            this.toolTip1.SetToolTip(this.tbProductCode, "Select the productCode before start measuring.");
            this.tbProductCode.TextChanged += new System.EventHandler(this.tbProductCode_TextChanged);
            // 
            // lblState
            // 
            this.lblState.AutoSize = true;
            this.lblState.Location = new System.Drawing.Point(92, 195);
            this.lblState.Name = "lblState";
            this.lblState.Size = new System.Drawing.Size(32, 13);
            this.lblState.TabIndex = 4;
            this.lblState.Text = "State";
            // 
            // btnCalibration
            // 
            this.btnCalibration.Location = new System.Drawing.Point(156, 111);
            this.btnCalibration.Name = "btnCalibration";
            this.btnCalibration.Size = new System.Drawing.Size(102, 23);
            this.btnCalibration.TabIndex = 1;
            this.btnCalibration.Text = "Calibration Sample";
            this.btnCalibration.UseVisualStyleBackColor = true;
            this.btnCalibration.Click += new System.EventHandler(this.btnCalibration_Click);
            // 
            // btnStartStop
            // 
            this.btnStartStop.Location = new System.Drawing.Point(155, 39);
            this.btnStartStop.Name = "btnStartStop";
            this.btnStartStop.Size = new System.Drawing.Size(102, 23);
            this.btnStartStop.TabIndex = 0;
            this.btnStartStop.Text = "Start Measuring";
            this.btnStartStop.UseVisualStyleBackColor = true;
            this.btnStartStop.Click += new System.EventHandler(this.btnStartStop_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Controls.Add(this.tbPauseTime);
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Controls.Add(this.tbMeasureTime);
            this.groupBox3.Controls.Add(this.btnStartSimulation);
            this.groupBox3.Location = new System.Drawing.Point(321, 12);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(189, 218);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Simmulate";
            this.toolTip1.SetToolTip(this.groupBox3, "Type the measure and pause time in seconds.");
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(17, 71);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(60, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "PauseTime";
            // 
            // tbPauseTime
            // 
            this.tbPauseTime.Location = new System.Drawing.Point(20, 87);
            this.tbPauseTime.Name = "tbPauseTime";
            this.tbPauseTime.Size = new System.Drawing.Size(112, 20);
            this.tbPauseTime.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(17, 23);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(70, 13);
            this.label4.TabIndex = 4;
            this.label4.Text = "Measure time";
            // 
            // tbMeasureTime
            // 
            this.tbMeasureTime.Location = new System.Drawing.Point(20, 39);
            this.tbMeasureTime.Name = "tbMeasureTime";
            this.tbMeasureTime.Size = new System.Drawing.Size(112, 20);
            this.tbMeasureTime.TabIndex = 1;
            this.tbMeasureTime.Text = "5";
            // 
            // btnStartSimulation
            // 
            this.btnStartSimulation.Location = new System.Drawing.Point(20, 169);
            this.btnStartSimulation.Name = "btnStartSimulation";
            this.btnStartSimulation.Size = new System.Drawing.Size(75, 23);
            this.btnStartSimulation.TabIndex = 0;
            this.btnStartSimulation.Text = "Start";
            this.toolTip1.SetToolTip(this.btnStartSimulation, "Click to start and stop simulation.");
            this.btnStartSimulation.UseVisualStyleBackColor = true;
            this.btnStartSimulation.Click += new System.EventHandler(this.btnStartSimulation_Click);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.lblSimCounter);
            this.groupBox4.Controls.Add(this.lblSampleCounter);
            this.groupBox4.Controls.Add(this.lblCalibrationSample);
            this.groupBox4.Controls.Add(this.lblWatchdog);
            this.groupBox4.Location = new System.Drawing.Point(321, 240);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(189, 154);
            this.groupBox4.TabIndex = 3;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Status";
            // 
            // lblSimCounter
            // 
            this.lblSimCounter.AutoSize = true;
            this.lblSimCounter.Location = new System.Drawing.Point(7, 90);
            this.lblSimCounter.Name = "lblSimCounter";
            this.lblSimCounter.Size = new System.Drawing.Size(94, 13);
            this.lblSimCounter.TabIndex = 3;
            this.lblSimCounter.Text = "Simulation counter";
            // 
            // lblSampleCounter
            // 
            this.lblSampleCounter.AutoSize = true;
            this.lblSampleCounter.Location = new System.Drawing.Point(10, 64);
            this.lblSampleCounter.Name = "lblSampleCounter";
            this.lblSampleCounter.Size = new System.Drawing.Size(81, 13);
            this.lblSampleCounter.TabIndex = 2;
            this.lblSampleCounter.Text = "Sample counter";
            // 
            // lblCalibrationSample
            // 
            this.lblCalibrationSample.AutoSize = true;
            this.lblCalibrationSample.Location = new System.Drawing.Point(10, 39);
            this.lblCalibrationSample.Name = "lblCalibrationSample";
            this.lblCalibrationSample.Size = new System.Drawing.Size(91, 13);
            this.lblCalibrationSample.TabIndex = 1;
            this.lblCalibrationSample.Text = "CalibrationSample";
            // 
            // lblWatchdog
            // 
            this.lblWatchdog.AutoSize = true;
            this.lblWatchdog.Location = new System.Drawing.Point(10, 18);
            this.lblWatchdog.Name = "lblWatchdog";
            this.lblWatchdog.Size = new System.Drawing.Size(77, 13);
            this.lblWatchdog.TabIndex = 0;
            this.lblWatchdog.Text = "PDx watchdog";
            // 
            // tbCalRegValue
            // 
            this.tbCalRegValue.Location = new System.Drawing.Point(23, 114);
            this.tbCalRegValue.Name = "tbCalRegValue";
            this.tbCalRegValue.Size = new System.Drawing.Size(108, 20);
            this.tbCalRegValue.TabIndex = 11;
            // 
            // cbAddReg
            // 
            this.cbAddReg.AutoSize = true;
            this.cbAddReg.Location = new System.Drawing.Point(24, 93);
            this.cbAddReg.Name = "cbAddReg";
            this.cbAddReg.Size = new System.Drawing.Size(99, 17);
            this.cbAddReg.TabIndex = 12;
            this.cbAddReg.Text = "Add registration";
            this.cbAddReg.UseVisualStyleBackColor = true;
            this.cbAddReg.CheckedChanged += new System.EventHandler(this.cbAddReg_CheckedChanged);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(525, 407);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.kepServerGroupBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "MainForm";
            this.Text = "ProFoss OPC test client";
            this.kepServerGroupBox.ResumeLayout(false);
            this.kepServerGroupBox.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.GroupBox kepServerGroupBox;
    private System.Windows.Forms.TextBox tbGroupName;
    private System.Windows.Forms.ComboBox cbOpcServer;
    private System.Windows.Forms.Button btnDisconnect;
    private System.Windows.Forms.Button btnConnect;
    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.Label lblConnected;
    private System.Windows.Forms.GroupBox groupBox2;
    private System.Windows.Forms.Label lblState;
    private System.Windows.Forms.Button btnCalibration;
    private System.Windows.Forms.Button btnStartStop;
    private System.Windows.Forms.GroupBox groupBox3;
    private System.Windows.Forms.Label label4;
    private System.Windows.Forms.TextBox tbMeasureTime;
    private System.Windows.Forms.Button btnStartSimulation;
    private System.Windows.Forms.Label ProductCodeLbl;
    private System.Windows.Forms.TextBox tbProductCode;
    private System.Windows.Forms.GroupBox groupBox4;
    private System.Windows.Forms.Label lblWatchdog;
    private System.Windows.Forms.Label lblCalibrationSample;
    private System.Windows.Forms.Label lblSampleCounter;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbPauseTime;
        private System.Windows.Forms.Label lblSimCounter;
        private System.Windows.Forms.Button startLoggingBtn;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox loggingTimeTb;
        private System.Windows.Forms.ToolTip toolTip1;
    private System.Windows.Forms.CheckBox UsePrdCpdeNChk;
        private System.Windows.Forms.CheckBox cbAddReg;
        private System.Windows.Forms.TextBox tbCalRegValue;
    }
}

