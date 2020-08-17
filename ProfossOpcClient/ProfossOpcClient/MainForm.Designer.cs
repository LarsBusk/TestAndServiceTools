namespace MstOpcClient
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
      this.groupBox1 = new System.Windows.Forms.GroupBox();
      this.lblConnected = new System.Windows.Forms.Label();
      this.btnDisconnect = new System.Windows.Forms.Button();
      this.btnConnect = new System.Windows.Forms.Button();
      this.label2 = new System.Windows.Forms.Label();
      this.label1 = new System.Windows.Forms.Label();
      this.tbGroupName = new System.Windows.Forms.TextBox();
      this.cbOpcServer = new System.Windows.Forms.ComboBox();
      this.groupBox2 = new System.Windows.Forms.GroupBox();
      this.label7 = new System.Windows.Forms.Label();
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
      this.groupBox1.SuspendLayout();
      this.groupBox2.SuspendLayout();
      this.groupBox3.SuspendLayout();
      this.groupBox4.SuspendLayout();
      this.SuspendLayout();
      // 
      // groupBox1
      // 
      this.groupBox1.Controls.Add(this.lblConnected);
      this.groupBox1.Controls.Add(this.btnDisconnect);
      this.groupBox1.Controls.Add(this.btnConnect);
      this.groupBox1.Controls.Add(this.label2);
      this.groupBox1.Controls.Add(this.label1);
      this.groupBox1.Controls.Add(this.tbGroupName);
      this.groupBox1.Controls.Add(this.cbOpcServer);
      this.groupBox1.Location = new System.Drawing.Point(12, 240);
      this.groupBox1.Name = "groupBox1";
      this.groupBox1.Size = new System.Drawing.Size(285, 154);
      this.groupBox1.TabIndex = 0;
      this.groupBox1.TabStop = false;
      this.groupBox1.Text = "KepServer";
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
      this.groupBox2.Controls.Add(this.label7);
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
      // label7
      // 
      this.label7.AutoSize = true;
      this.label7.Location = new System.Drawing.Point(21, 23);
      this.label7.Name = "label7";
      this.label7.Size = new System.Drawing.Size(77, 13);
      this.label7.TabIndex = 7;
      this.label7.Text = "ProductCodeN";
      // 
      // tbProductCode
      // 
      this.tbProductCode.Enabled = false;
      this.tbProductCode.Location = new System.Drawing.Point(24, 39);
      this.tbProductCode.Name = "tbProductCode";
      this.tbProductCode.Size = new System.Drawing.Size(100, 20);
      this.tbProductCode.TabIndex = 6;
      this.tbProductCode.TextChanged += new System.EventHandler(this.tbProductCode_TextChanged);
      // 
      // lblState
      // 
      this.lblState.AutoSize = true;
      this.lblState.Location = new System.Drawing.Point(92, 169);
      this.lblState.Name = "lblState";
      this.lblState.Size = new System.Drawing.Size(32, 13);
      this.lblState.TabIndex = 4;
      this.lblState.Text = "State";
      // 
      // btnCalibration
      // 
      this.btnCalibration.Location = new System.Drawing.Point(155, 68);
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
      // MainForm
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(525, 407);
      this.Controls.Add(this.groupBox4);
      this.Controls.Add(this.groupBox3);
      this.Controls.Add(this.groupBox2);
      this.Controls.Add(this.groupBox1);
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
      this.Name = "MainForm";
      this.Text = "ProFoss OPC test client";
      this.groupBox1.ResumeLayout(false);
      this.groupBox1.PerformLayout();
      this.groupBox2.ResumeLayout(false);
      this.groupBox2.PerformLayout();
      this.groupBox3.ResumeLayout(false);
      this.groupBox3.PerformLayout();
      this.groupBox4.ResumeLayout(false);
      this.groupBox4.PerformLayout();
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.GroupBox groupBox1;
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
    private System.Windows.Forms.Label label7;
    private System.Windows.Forms.TextBox tbProductCode;
    private System.Windows.Forms.GroupBox groupBox4;
    private System.Windows.Forms.Label lblWatchdog;
    private System.Windows.Forms.Label lblCalibrationSample;
    private System.Windows.Forms.Label lblSampleCounter;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbPauseTime;
        private System.Windows.Forms.Label lblSimCounter;
    }
}

