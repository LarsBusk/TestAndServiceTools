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
      this.btnCip = new System.Windows.Forms.Button();
      this.btnWaterReference = new System.Windows.Forms.Button();
      this.btnCalibration = new System.Windows.Forms.Button();
      this.btnStartStop = new System.Windows.Forms.Button();

      this.groupBox3 = new System.Windows.Forms.GroupBox();
      this.simLbl = new System.Windows.Forms.Label();
      this.label6 = new System.Windows.Forms.Label();
      this.label5 = new System.Windows.Forms.Label();
      this.label4 = new System.Windows.Forms.Label();
      this.tbCipTime = new System.Windows.Forms.TextBox();
      this.tbWaterRefTime = new System.Windows.Forms.TextBox();
      this.tbMeasureTime = new System.Windows.Forms.TextBox();
      this.btnStartSimulation = new System.Windows.Forms.Button();
      this.groupBox4 = new System.Windows.Forms.GroupBox();
      this.SimCtrLbl = new System.Windows.Forms.Label();
      this.lblCip = new System.Windows.Forms.Label();
      this.lblSampleCounter = new System.Windows.Forms.Label();
      this.lblCalibrationSample = new System.Windows.Forms.Label();
      this.lblWatchdog = new System.Windows.Forms.Label();

      this.btnStartStop = new System.Windows.Forms.Button();
      this.btnCalibration = new System.Windows.Forms.Button();
      this.btnWaterReference = new System.Windows.Forms.Button();
      this.btnCip = new System.Windows.Forms.Button();
      this.tbProductCode = new System.Windows.Forms.TextBox();
      this.label7 = new System.Windows.Forms.Label();
      this.groupBox2 = new System.Windows.Forms.GroupBox();

      this.groupBox1.SuspendLayout();
      this.groupBox3.SuspendLayout();
      this.groupBox4.SuspendLayout();
      this.groupBox2.SuspendLayout();
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
      this.groupBox2.Controls.Add(this.btnCip);
      this.groupBox2.Controls.Add(this.btnWaterReference);
      this.groupBox2.Controls.Add(this.btnCalibration);
      this.groupBox2.Controls.Add(this.btnStartStop);
      this.groupBox2.Location = new System.Drawing.Point(12, 12);
      this.groupBox2.Name = "groupBox2";
      this.groupBox2.Size = new System.Drawing.Size(284, 218);
      this.groupBox2.TabIndex = 1;
      this.groupBox2.TabStop = false;
      this.groupBox2.Text = "Control";
      // 
      // label3
      // 

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
      // btnCip
      // 
      this.btnCip.Location = new System.Drawing.Point(155, 126);
      this.btnCip.Name = "btnCip";
      this.btnCip.Size = new System.Drawing.Size(102, 23);
      this.btnCip.TabIndex = 3;
      this.btnCip.Text = "CIP";
      this.btnCip.UseVisualStyleBackColor = true;
      this.btnCip.Click += new System.EventHandler(this.btnCip_Click);
      // 
      // btnWaterReference
      // 
      this.btnWaterReference.Location = new System.Drawing.Point(155, 97);
      this.btnWaterReference.Name = "btnWaterReference";
      this.btnWaterReference.Size = new System.Drawing.Size(102, 23);
      this.btnWaterReference.TabIndex = 2;
      this.btnWaterReference.Text = "Water Reference";
      this.btnWaterReference.UseVisualStyleBackColor = true;
      this.btnWaterReference.Click += new System.EventHandler(this.btnWaterReference_Click);
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
      this.groupBox3.Controls.Add(this.simLbl);
      this.groupBox3.Controls.Add(this.label6);
      this.groupBox3.Controls.Add(this.label5);
      this.groupBox3.Controls.Add(this.label4);
      this.groupBox3.Controls.Add(this.tbCipTime);
      this.groupBox3.Controls.Add(this.tbWaterRefTime);
      this.groupBox3.Controls.Add(this.tbMeasureTime);
      this.groupBox3.Controls.Add(this.btnStartSimulation);
      this.groupBox3.Location = new System.Drawing.Point(321, 12);
      this.groupBox3.Name = "groupBox3";
      this.groupBox3.Size = new System.Drawing.Size(189, 218);
      this.groupBox3.TabIndex = 2;
      this.groupBox3.TabStop = false;
      this.groupBox3.Text = "Simulate";
      // 
      // simLbl
      // 
      this.simLbl.AutoSize = true;
      this.simLbl.Location = new System.Drawing.Point(21, 193);
      this.simLbl.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
      this.simLbl.Name = "simLbl";
      this.simLbl.Size = new System.Drawing.Size(55, 13);
      this.simLbl.TabIndex = 7;
      this.simLbl.Text = "Simulating";
      // 
      // label6
      // 
      this.label6.AutoSize = true;
      this.label6.Location = new System.Drawing.Point(17, 116);
      this.label6.Name = "label6";
      this.label6.Size = new System.Drawing.Size(46, 13);
      this.label6.TabIndex = 6;
      this.label6.Text = "CIP time";
      // 
      // label5
      // 
      this.label5.AutoSize = true;
      this.label5.Location = new System.Drawing.Point(21, 69);
      this.label5.Name = "label5";
      this.label5.Size = new System.Drawing.Size(84, 13);
      this.label5.TabIndex = 5;
      this.label5.Text = "Water reference";
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
      // tbCipTime
      // 
      this.tbCipTime.Location = new System.Drawing.Point(20, 132);
      this.tbCipTime.Name = "tbCipTime";
      this.tbCipTime.Size = new System.Drawing.Size(112, 20);
      this.tbCipTime.TabIndex = 3;
      this.tbCipTime.Text = "5";
      // 
      // tbWaterRefTime
      // 
      this.tbWaterRefTime.Location = new System.Drawing.Point(20, 85);
      this.tbWaterRefTime.Name = "tbWaterRefTime";
      this.tbWaterRefTime.Size = new System.Drawing.Size(112, 20);
      this.tbWaterRefTime.TabIndex = 2;
      this.tbWaterRefTime.Text = "15";
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
      this.btnStartSimulation.Location = new System.Drawing.Point(20, 160);
      this.btnStartSimulation.Name = "btnStartSimulation";
      this.btnStartSimulation.Size = new System.Drawing.Size(75, 23);
      this.btnStartSimulation.TabIndex = 0;
      this.btnStartSimulation.Text = "Start";
      this.btnStartSimulation.UseVisualStyleBackColor = true;
      this.btnStartSimulation.Click += new System.EventHandler(this.btnStartSimulation_Click);
      // 
      // groupBox4
      // 
      this.groupBox4.Controls.Add(this.SimCtrLbl);
      this.groupBox4.Controls.Add(this.lblCip);
      this.groupBox4.Controls.Add(this.lblSampleCounter);
      this.groupBox4.Controls.Add(this.lblCalibrationSample);
      this.groupBox4.Controls.Add(this.lblWatchdog);
      this.groupBox4.Location = new System.Drawing.Point(321, 249);
      this.groupBox4.Name = "groupBox4";
      this.groupBox4.Size = new System.Drawing.Size(189, 145);
      this.groupBox4.TabIndex = 3;
      this.groupBox4.TabStop = false;
      this.groupBox4.Text = "Status";
      // 
      // SimCtrLbl
      // 
      this.SimCtrLbl.AutoSize = true;
      this.SimCtrLbl.Location = new System.Drawing.Point(10, 112);
      this.SimCtrLbl.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
      this.SimCtrLbl.Name = "SimCtrLbl";
      this.SimCtrLbl.Size = new System.Drawing.Size(97, 13);
      this.SimCtrLbl.TabIndex = 4;
      this.SimCtrLbl.Text = "Simulation counter:";
      // 
      // lblCip
      // 
      this.lblCip.AutoSize = true;
      this.lblCip.Location = new System.Drawing.Point(10, 90);
      this.lblCip.Name = "lblCip";
      this.lblCip.Size = new System.Drawing.Size(22, 13);
      this.lblCip.TabIndex = 3;
      this.lblCip.Text = "Cip";
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
      // btnWaterReference
      // 
      this.btnWaterReference.Location = new System.Drawing.Point(155, 97);
      this.btnWaterReference.Name = "btnWaterReference";
      this.btnWaterReference.Size = new System.Drawing.Size(102, 23);
      this.btnWaterReference.TabIndex = 2;
      this.btnWaterReference.Text = "Water Reference";
      this.btnWaterReference.UseVisualStyleBackColor = true;
      this.btnWaterReference.Click += new System.EventHandler(this.btnWaterReference_Click);
      // 
      // btnCip
      // 
      this.btnCip.Location = new System.Drawing.Point(155, 126);
      this.btnCip.Name = "btnCip";
      this.btnCip.Size = new System.Drawing.Size(102, 23);
      this.btnCip.TabIndex = 3;
      this.btnCip.Text = "CIP";
      this.btnCip.UseVisualStyleBackColor = true;
      this.btnCip.Click += new System.EventHandler(this.btnCip_Click);
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
      // label7
      // 
      this.label7.AutoSize = true;
      this.label7.Location = new System.Drawing.Point(21, 23);
      this.label7.Name = "label7";
      this.label7.Size = new System.Drawing.Size(77, 13);
      this.label7.TabIndex = 7;
      this.label7.Text = "ProductCodeN";
      // 
      // groupBox2
      // 
      this.groupBox2.Controls.Add(this.label7);
      this.groupBox2.Controls.Add(this.tbProductCode);
      this.groupBox2.Controls.Add(this.btnCip);
      this.groupBox2.Controls.Add(this.btnWaterReference);
      this.groupBox2.Controls.Add(this.btnCalibration);
      this.groupBox2.Controls.Add(this.btnStartStop);
      this.groupBox2.Location = new System.Drawing.Point(12, 12);
      this.groupBox2.Name = "groupBox2";
      this.groupBox2.Size = new System.Drawing.Size(284, 218);
      this.groupBox2.TabIndex = 1;
      this.groupBox2.TabStop = false;
      this.groupBox2.Text = "Control";
      // 

      // MainForm
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;

      this.ClientSize = new System.Drawing.Size(703, 408);

      this.Controls.Add(this.groupBox4);
      this.Controls.Add(this.groupBox3);
      this.Controls.Add(this.groupBox2);
      this.Controls.Add(this.groupBox1);




      this.Name = "MainForm";
      this.Text = "MilkoStream FT OPC test client";
      this.groupBox1.ResumeLayout(false);
      this.groupBox1.PerformLayout();
      this.groupBox3.ResumeLayout(false);
      this.groupBox3.PerformLayout();
      this.groupBox4.ResumeLayout(false);
      this.groupBox4.PerformLayout();
      this.groupBox2.ResumeLayout(false);
      this.groupBox2.PerformLayout();
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
    private System.Windows.Forms.GroupBox groupBox3;
    private System.Windows.Forms.Label label6;
    private System.Windows.Forms.Label label5;
    private System.Windows.Forms.Label label4;
    private System.Windows.Forms.TextBox tbCipTime;
    private System.Windows.Forms.TextBox tbWaterRefTime;
    private System.Windows.Forms.TextBox tbMeasureTime;
    private System.Windows.Forms.Button btnStartSimulation;
    private System.Windows.Forms.GroupBox groupBox4;
    private System.Windows.Forms.Label lblWatchdog;
    private System.Windows.Forms.Label lblCalibrationSample;
    private System.Windows.Forms.Label lblSampleCounter;
    private System.Windows.Forms.Label lblCip;
    private System.Windows.Forms.Label SimCtrLbl;
    private System.Windows.Forms.Label simLbl;

    private System.Windows.Forms.Button btnStartStop;
    private System.Windows.Forms.Button btnCalibration;
    private System.Windows.Forms.Button btnWaterReference;
    private System.Windows.Forms.Button btnCip;
    private System.Windows.Forms.TextBox tbProductCode;
    private System.Windows.Forms.Label label7;
    private System.Windows.Forms.GroupBox groupBox2;

  }
}

