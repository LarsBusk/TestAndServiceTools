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
      this.newSampleButton = new System.Windows.Forms.Button();
      this.label7 = new System.Windows.Forms.Label();
      this.tbProductCode = new System.Windows.Forms.TextBox();
      this.lblState = new System.Windows.Forms.Label();
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
      this.button1 = new System.Windows.Forms.Button();
      this.button2 = new System.Windows.Forms.Button();
      this.intervalTextBox = new System.Windows.Forms.TextBox();
      this.label3 = new System.Windows.Forms.Label();
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
      this.groupBox1.Location = new System.Drawing.Point(16, 295);
      this.groupBox1.Margin = new System.Windows.Forms.Padding(4);
      this.groupBox1.Name = "groupBox1";
      this.groupBox1.Padding = new System.Windows.Forms.Padding(4);
      this.groupBox1.Size = new System.Drawing.Size(380, 190);
      this.groupBox1.TabIndex = 0;
      this.groupBox1.TabStop = false;
      this.groupBox1.Text = "KepServer";
      // 
      // lblConnected
      // 
      this.lblConnected.AutoSize = true;
      this.lblConnected.Location = new System.Drawing.Point(28, 153);
      this.lblConnected.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
      this.lblConnected.Name = "lblConnected";
      this.lblConnected.Size = new System.Drawing.Size(79, 17);
      this.lblConnected.TabIndex = 6;
      this.lblConnected.Text = "Connection";
      // 
      // btnDisconnect
      // 
      this.btnDisconnect.Location = new System.Drawing.Point(243, 110);
      this.btnDisconnect.Margin = new System.Windows.Forms.Padding(4);
      this.btnDisconnect.Name = "btnDisconnect";
      this.btnDisconnect.Size = new System.Drawing.Size(100, 28);
      this.btnDisconnect.TabIndex = 5;
      this.btnDisconnect.Text = "Disconnect";
      this.btnDisconnect.UseVisualStyleBackColor = true;
      this.btnDisconnect.Click += new System.EventHandler(this.btnDisconnect_Click);
      // 
      // btnConnect
      // 
      this.btnConnect.Location = new System.Drawing.Point(243, 47);
      this.btnConnect.Margin = new System.Windows.Forms.Padding(4);
      this.btnConnect.Name = "btnConnect";
      this.btnConnect.Size = new System.Drawing.Size(100, 28);
      this.btnConnect.TabIndex = 4;
      this.btnConnect.Text = "Connect";
      this.btnConnect.UseVisualStyleBackColor = true;
      this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
      // 
      // label2
      // 
      this.label2.AutoSize = true;
      this.label2.Location = new System.Drawing.Point(27, 90);
      this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
      this.label2.Name = "label2";
      this.label2.Size = new System.Drawing.Size(48, 17);
      this.label2.TabIndex = 3;
      this.label2.Text = "Group";
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.Location = new System.Drawing.Point(27, 27);
      this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(75, 17);
      this.label1.TabIndex = 2;
      this.label1.Text = "KepServer";
      // 
      // tbGroupName
      // 
      this.tbGroupName.Location = new System.Drawing.Point(31, 110);
      this.tbGroupName.Margin = new System.Windows.Forms.Padding(4);
      this.tbGroupName.Name = "tbGroupName";
      this.tbGroupName.Size = new System.Drawing.Size(160, 22);
      this.tbGroupName.TabIndex = 1;
      // 
      // cbOpcServer
      // 
      this.cbOpcServer.FormattingEnabled = true;
      this.cbOpcServer.Location = new System.Drawing.Point(31, 47);
      this.cbOpcServer.Margin = new System.Windows.Forms.Padding(4);
      this.cbOpcServer.Name = "cbOpcServer";
      this.cbOpcServer.Size = new System.Drawing.Size(160, 24);
      this.cbOpcServer.TabIndex = 0;
      // 
      // groupBox2
      // 
      this.groupBox2.Controls.Add(this.label3);
      this.groupBox2.Controls.Add(this.intervalTextBox);
      this.groupBox2.Controls.Add(this.button2);
      this.groupBox2.Controls.Add(this.button1);
      this.groupBox2.Controls.Add(this.newSampleButton);
      this.groupBox2.Controls.Add(this.label7);
      this.groupBox2.Controls.Add(this.tbProductCode);
      this.groupBox2.Controls.Add(this.lblState);
      this.groupBox2.Controls.Add(this.btnCip);
      this.groupBox2.Controls.Add(this.btnWaterReference);
      this.groupBox2.Controls.Add(this.btnCalibration);
      this.groupBox2.Controls.Add(this.btnStartStop);
      this.groupBox2.Location = new System.Drawing.Point(16, 15);
      this.groupBox2.Margin = new System.Windows.Forms.Padding(4);
      this.groupBox2.Name = "groupBox2";
      this.groupBox2.Padding = new System.Windows.Forms.Padding(4);
      this.groupBox2.Size = new System.Drawing.Size(379, 268);
      this.groupBox2.TabIndex = 1;
      this.groupBox2.TabStop = false;
      this.groupBox2.Text = "Control";
      // 
      // newSampleButton
      // 
      this.newSampleButton.Location = new System.Drawing.Point(207, 197);
      this.newSampleButton.Name = "newSampleButton";
      this.newSampleButton.Size = new System.Drawing.Size(136, 28);
      this.newSampleButton.TabIndex = 8;
      this.newSampleButton.Text = "NewSample";
      this.newSampleButton.UseVisualStyleBackColor = true;
      this.newSampleButton.Click += new System.EventHandler(this.newSampleButton_Click);
      // 
      // label7
      // 
      this.label7.AutoSize = true;
      this.label7.Location = new System.Drawing.Point(28, 28);
      this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
      this.label7.Name = "label7";
      this.label7.Size = new System.Drawing.Size(100, 17);
      this.label7.TabIndex = 7;
      this.label7.Text = "ProductCodeN";
      // 
      // tbProductCode
      // 
      this.tbProductCode.Enabled = false;
      this.tbProductCode.Location = new System.Drawing.Point(32, 48);
      this.tbProductCode.Margin = new System.Windows.Forms.Padding(4);
      this.tbProductCode.Name = "tbProductCode";
      this.tbProductCode.Size = new System.Drawing.Size(132, 22);
      this.tbProductCode.TabIndex = 6;
      this.tbProductCode.TextChanged += new System.EventHandler(this.tbProductCode_TextChanged);
      // 
      // lblState
      // 
      this.lblState.AutoSize = true;
      this.lblState.Location = new System.Drawing.Point(123, 208);
      this.lblState.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
      this.lblState.Name = "lblState";
      this.lblState.Size = new System.Drawing.Size(41, 17);
      this.lblState.TabIndex = 4;
      this.lblState.Text = "State";
      // 
      // btnCip
      // 
      this.btnCip.Location = new System.Drawing.Point(207, 155);
      this.btnCip.Margin = new System.Windows.Forms.Padding(4);
      this.btnCip.Name = "btnCip";
      this.btnCip.Size = new System.Drawing.Size(136, 28);
      this.btnCip.TabIndex = 3;
      this.btnCip.Text = "CIP";
      this.btnCip.UseVisualStyleBackColor = true;
      this.btnCip.Click += new System.EventHandler(this.btnCip_Click);
      // 
      // btnWaterReference
      // 
      this.btnWaterReference.Location = new System.Drawing.Point(207, 119);
      this.btnWaterReference.Margin = new System.Windows.Forms.Padding(4);
      this.btnWaterReference.Name = "btnWaterReference";
      this.btnWaterReference.Size = new System.Drawing.Size(136, 28);
      this.btnWaterReference.TabIndex = 2;
      this.btnWaterReference.Text = "Water Reference";
      this.btnWaterReference.UseVisualStyleBackColor = true;
      this.btnWaterReference.Click += new System.EventHandler(this.btnWaterReference_Click);
      // 
      // btnCalibration
      // 
      this.btnCalibration.Location = new System.Drawing.Point(207, 84);
      this.btnCalibration.Margin = new System.Windows.Forms.Padding(4);
      this.btnCalibration.Name = "btnCalibration";
      this.btnCalibration.Size = new System.Drawing.Size(136, 28);
      this.btnCalibration.TabIndex = 1;
      this.btnCalibration.Text = "Calibration Sample";
      this.btnCalibration.UseVisualStyleBackColor = true;
      this.btnCalibration.Click += new System.EventHandler(this.btnCalibration_Click);
      // 
      // btnStartStop
      // 
      this.btnStartStop.Location = new System.Drawing.Point(207, 48);
      this.btnStartStop.Margin = new System.Windows.Forms.Padding(4);
      this.btnStartStop.Name = "btnStartStop";
      this.btnStartStop.Size = new System.Drawing.Size(136, 28);
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
      this.groupBox3.Location = new System.Drawing.Point(428, 15);
      this.groupBox3.Margin = new System.Windows.Forms.Padding(4);
      this.groupBox3.Name = "groupBox3";
      this.groupBox3.Padding = new System.Windows.Forms.Padding(4);
      this.groupBox3.Size = new System.Drawing.Size(252, 268);
      this.groupBox3.TabIndex = 2;
      this.groupBox3.TabStop = false;
      this.groupBox3.Text = "Simulate";
      // 
      // simLbl
      // 
      this.simLbl.AutoSize = true;
      this.simLbl.Location = new System.Drawing.Point(28, 238);
      this.simLbl.Name = "simLbl";
      this.simLbl.Size = new System.Drawing.Size(73, 17);
      this.simLbl.TabIndex = 7;
      this.simLbl.Text = "Simulating";
      // 
      // label6
      // 
      this.label6.AutoSize = true;
      this.label6.Location = new System.Drawing.Point(23, 143);
      this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
      this.label6.Name = "label6";
      this.label6.Size = new System.Drawing.Size(59, 17);
      this.label6.TabIndex = 6;
      this.label6.Text = "CIP time";
      // 
      // label5
      // 
      this.label5.AutoSize = true;
      this.label5.Location = new System.Drawing.Point(28, 85);
      this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
      this.label5.Name = "label5";
      this.label5.Size = new System.Drawing.Size(111, 17);
      this.label5.TabIndex = 5;
      this.label5.Text = "Water reference";
      // 
      // label4
      // 
      this.label4.AutoSize = true;
      this.label4.Location = new System.Drawing.Point(23, 28);
      this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
      this.label4.Name = "label4";
      this.label4.Size = new System.Drawing.Size(93, 17);
      this.label4.TabIndex = 4;
      this.label4.Text = "Measure time";
      // 
      // tbCipTime
      // 
      this.tbCipTime.Location = new System.Drawing.Point(27, 162);
      this.tbCipTime.Margin = new System.Windows.Forms.Padding(4);
      this.tbCipTime.Name = "tbCipTime";
      this.tbCipTime.Size = new System.Drawing.Size(148, 22);
      this.tbCipTime.TabIndex = 3;
      this.tbCipTime.Text = "5";
      // 
      // tbWaterRefTime
      // 
      this.tbWaterRefTime.Location = new System.Drawing.Point(27, 105);
      this.tbWaterRefTime.Margin = new System.Windows.Forms.Padding(4);
      this.tbWaterRefTime.Name = "tbWaterRefTime";
      this.tbWaterRefTime.Size = new System.Drawing.Size(148, 22);
      this.tbWaterRefTime.TabIndex = 2;
      this.tbWaterRefTime.Text = "15";
      // 
      // tbMeasureTime
      // 
      this.tbMeasureTime.Location = new System.Drawing.Point(27, 48);
      this.tbMeasureTime.Margin = new System.Windows.Forms.Padding(4);
      this.tbMeasureTime.Name = "tbMeasureTime";
      this.tbMeasureTime.Size = new System.Drawing.Size(148, 22);
      this.tbMeasureTime.TabIndex = 1;
      this.tbMeasureTime.Text = "5";
      // 
      // btnStartSimulation
      // 
      this.btnStartSimulation.Location = new System.Drawing.Point(26, 197);
      this.btnStartSimulation.Margin = new System.Windows.Forms.Padding(4);
      this.btnStartSimulation.Name = "btnStartSimulation";
      this.btnStartSimulation.Size = new System.Drawing.Size(100, 28);
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
      this.groupBox4.Location = new System.Drawing.Point(428, 306);
      this.groupBox4.Margin = new System.Windows.Forms.Padding(4);
      this.groupBox4.Name = "groupBox4";
      this.groupBox4.Padding = new System.Windows.Forms.Padding(4);
      this.groupBox4.Size = new System.Drawing.Size(252, 178);
      this.groupBox4.TabIndex = 3;
      this.groupBox4.TabStop = false;
      this.groupBox4.Text = "Status";
      // 
      // SimCtrLbl
      // 
      this.SimCtrLbl.AutoSize = true;
      this.SimCtrLbl.Location = new System.Drawing.Point(13, 138);
      this.SimCtrLbl.Name = "SimCtrLbl";
      this.SimCtrLbl.Size = new System.Drawing.Size(129, 17);
      this.SimCtrLbl.TabIndex = 4;
      this.SimCtrLbl.Text = "Simulation counter:";
      // 
      // lblCip
      // 
      this.lblCip.AutoSize = true;
      this.lblCip.Location = new System.Drawing.Point(13, 111);
      this.lblCip.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
      this.lblCip.Name = "lblCip";
      this.lblCip.Size = new System.Drawing.Size(28, 17);
      this.lblCip.TabIndex = 3;
      this.lblCip.Text = "Cip";
      // 
      // lblSampleCounter
      // 
      this.lblSampleCounter.AutoSize = true;
      this.lblSampleCounter.Location = new System.Drawing.Point(13, 79);
      this.lblSampleCounter.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
      this.lblSampleCounter.Name = "lblSampleCounter";
      this.lblSampleCounter.Size = new System.Drawing.Size(107, 17);
      this.lblSampleCounter.TabIndex = 2;
      this.lblSampleCounter.Text = "Sample counter";
      // 
      // lblCalibrationSample
      // 
      this.lblCalibrationSample.AutoSize = true;
      this.lblCalibrationSample.Location = new System.Drawing.Point(13, 48);
      this.lblCalibrationSample.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
      this.lblCalibrationSample.Name = "lblCalibrationSample";
      this.lblCalibrationSample.Size = new System.Drawing.Size(122, 17);
      this.lblCalibrationSample.TabIndex = 1;
      this.lblCalibrationSample.Text = "CalibrationSample";
      // 
      // lblWatchdog
      // 
      this.lblWatchdog.AutoSize = true;
      this.lblWatchdog.Location = new System.Drawing.Point(13, 22);
      this.lblWatchdog.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
      this.lblWatchdog.Name = "lblWatchdog";
      this.lblWatchdog.Size = new System.Drawing.Size(97, 17);
      this.lblWatchdog.TabIndex = 0;
      this.lblWatchdog.Text = "PDx watchdog";
      // 
      // button1
      // 
      this.button1.Location = new System.Drawing.Point(209, 231);
      this.button1.Name = "button1";
      this.button1.Size = new System.Drawing.Size(75, 30);
      this.button1.TabIndex = 9;
      this.button1.Text = "Stop";
      this.button1.UseVisualStyleBackColor = true;
      this.button1.Click += new System.EventHandler(this.button1_Click);
      // 
      // button2
      // 
      this.button2.Location = new System.Drawing.Point(116, 231);
      this.button2.Name = "button2";
      this.button2.Size = new System.Drawing.Size(75, 30);
      this.button2.TabIndex = 10;
      this.button2.Text = "Start";
      this.button2.UseVisualStyleBackColor = true;
      this.button2.Click += new System.EventHandler(this.button2_Click);
      // 
      // intervalTextBox
      // 
      this.intervalTextBox.Location = new System.Drawing.Point(22, 233);
      this.intervalTextBox.Name = "intervalTextBox";
      this.intervalTextBox.Size = new System.Drawing.Size(80, 22);
      this.intervalTextBox.TabIndex = 11;
      this.intervalTextBox.Text = "200";
      // 
      // label3
      // 
      this.label3.AutoSize = true;
      this.label3.Location = new System.Drawing.Point(19, 213);
      this.label3.Name = "label3";
      this.label3.Size = new System.Drawing.Size(54, 17);
      this.label3.TabIndex = 12;
      this.label3.Text = "Interval";
      // 
      // MainForm
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(937, 502);
      this.Controls.Add(this.groupBox4);
      this.Controls.Add(this.groupBox3);
      this.Controls.Add(this.groupBox2);
      this.Controls.Add(this.groupBox1);
      this.Margin = new System.Windows.Forms.Padding(4);
      this.Name = "MainForm";
      this.Text = "MilkoStream FT OPC test client";
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
    private System.Windows.Forms.Button btnCip;
    private System.Windows.Forms.Button btnWaterReference;
    private System.Windows.Forms.Button btnCalibration;
    private System.Windows.Forms.Button btnStartStop;
    private System.Windows.Forms.GroupBox groupBox3;
    private System.Windows.Forms.Label label6;
    private System.Windows.Forms.Label label5;
    private System.Windows.Forms.Label label4;
    private System.Windows.Forms.TextBox tbCipTime;
    private System.Windows.Forms.TextBox tbWaterRefTime;
    private System.Windows.Forms.TextBox tbMeasureTime;
    private System.Windows.Forms.Button btnStartSimulation;
    private System.Windows.Forms.Label label7;
    private System.Windows.Forms.TextBox tbProductCode;
    private System.Windows.Forms.GroupBox groupBox4;
    private System.Windows.Forms.Label lblWatchdog;
    private System.Windows.Forms.Label lblCalibrationSample;
    private System.Windows.Forms.Label lblSampleCounter;
    private System.Windows.Forms.Label lblCip;
    private System.Windows.Forms.Label SimCtrLbl;
    private System.Windows.Forms.Label simLbl;
    private System.Windows.Forms.Button newSampleButton;
    private System.Windows.Forms.Button button1;
    private System.Windows.Forms.Button button2;
    private System.Windows.Forms.TextBox intervalTextBox;
    private System.Windows.Forms.Label label3;
  }
}

