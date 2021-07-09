namespace OPCCsvLoggerClient
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
      this.connectButton = new System.Windows.Forms.Button();
      this.disconnectButton = new System.Windows.Forms.Button();
      this.getSampleTimer = new System.Windows.Forms.Timer(this.components);
      this.opcClientTimeLabel = new System.Windows.Forms.Label();
      this.sampleIdLabel = new System.Windows.Forms.Label();
      this.sampleNumberLabel = new System.Windows.Forms.Label();
      this.sampleTimeLabel = new System.Windows.Forms.Label();
      this.elapsedTimeLabel = new System.Windows.Forms.Label();
      this.label1 = new System.Windows.Forms.Label();
      this.label2 = new System.Windows.Forms.Label();
      this.label3 = new System.Windows.Forms.Label();
      this.label4 = new System.Windows.Forms.Label();
      this.label5 = new System.Windows.Forms.Label();
      this.cbOpcServer = new System.Windows.Forms.ComboBox();
      this.tbGroupName = new System.Windows.Forms.TextBox();
      this.label6 = new System.Windows.Forms.Label();
      this.label7 = new System.Windows.Forms.Label();
      this.tbUpdateRate = new System.Windows.Forms.TextBox();
      this.label8 = new System.Windows.Forms.Label();
      this.SuspendLayout();
      // 
      // connectButton
      // 
      this.connectButton.Location = new System.Drawing.Point(12, 12);
      this.connectButton.Name = "connectButton";
      this.connectButton.Size = new System.Drawing.Size(75, 23);
      this.connectButton.TabIndex = 0;
      this.connectButton.Text = "Connect";
      this.connectButton.UseVisualStyleBackColor = true;
      this.connectButton.Click += new System.EventHandler(this.ConnectButtonClick);
      // 
      // disconnectButton
      // 
      this.disconnectButton.Location = new System.Drawing.Point(105, 12);
      this.disconnectButton.Name = "disconnectButton";
      this.disconnectButton.Size = new System.Drawing.Size(75, 23);
      this.disconnectButton.TabIndex = 1;
      this.disconnectButton.Text = "Disconnect";
      this.disconnectButton.UseVisualStyleBackColor = true;
      this.disconnectButton.Click += new System.EventHandler(this.DisconnectButtonClick);
      // 
      // getSampleTimer
      // 
      this.getSampleTimer.Enabled = true;
      this.getSampleTimer.Tick += new System.EventHandler(this.GetSampleTimerTick);
      // 
      // opcClientTimeLabel
      // 
      this.opcClientTimeLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      this.opcClientTimeLabel.Location = new System.Drawing.Point(111, 148);
      this.opcClientTimeLabel.Name = "opcClientTimeLabel";
      this.opcClientTimeLabel.Size = new System.Drawing.Size(431, 25);
      this.opcClientTimeLabel.TabIndex = 5;
      this.opcClientTimeLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
      // 
      // sampleIdLabel
      // 
      this.sampleIdLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      this.sampleIdLabel.Location = new System.Drawing.Point(111, 61);
      this.sampleIdLabel.Name = "sampleIdLabel";
      this.sampleIdLabel.Size = new System.Drawing.Size(431, 25);
      this.sampleIdLabel.TabIndex = 6;
      this.sampleIdLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
      // 
      // sampleNumberLabel
      // 
      this.sampleNumberLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      this.sampleNumberLabel.Location = new System.Drawing.Point(111, 90);
      this.sampleNumberLabel.Name = "sampleNumberLabel";
      this.sampleNumberLabel.Size = new System.Drawing.Size(431, 25);
      this.sampleNumberLabel.TabIndex = 7;
      this.sampleNumberLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
      // 
      // sampleTimeLabel
      // 
      this.sampleTimeLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      this.sampleTimeLabel.Location = new System.Drawing.Point(111, 119);
      this.sampleTimeLabel.Name = "sampleTimeLabel";
      this.sampleTimeLabel.Size = new System.Drawing.Size(431, 25);
      this.sampleTimeLabel.TabIndex = 8;
      this.sampleTimeLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
      // 
      // elapsedTimeLabel
      // 
      this.elapsedTimeLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      this.elapsedTimeLabel.Location = new System.Drawing.Point(111, 177);
      this.elapsedTimeLabel.Name = "elapsedTimeLabel";
      this.elapsedTimeLabel.Size = new System.Drawing.Size(431, 25);
      this.elapsedTimeLabel.TabIndex = 9;
      this.elapsedTimeLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.Location = new System.Drawing.Point(12, 67);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(54, 13);
      this.label1.TabIndex = 10;
      this.label1.Text = "Sample Id";
      // 
      // label2
      // 
      this.label2.AutoSize = true;
      this.label2.Location = new System.Drawing.Point(12, 96);
      this.label2.Name = "label2";
      this.label2.Size = new System.Drawing.Size(82, 13);
      this.label2.TabIndex = 11;
      this.label2.Text = "Sample Number";
      // 
      // label3
      // 
      this.label3.AutoSize = true;
      this.label3.Location = new System.Drawing.Point(12, 125);
      this.label3.Name = "label3";
      this.label3.Size = new System.Drawing.Size(68, 13);
      this.label3.TabIndex = 12;
      this.label3.Text = "Sample Time";
      // 
      // label4
      // 
      this.label4.AutoSize = true;
      this.label4.Location = new System.Drawing.Point(12, 154);
      this.label4.Name = "label4";
      this.label4.Size = new System.Drawing.Size(59, 13);
      this.label4.TabIndex = 13;
      this.label4.Text = "Client Time";
      // 
      // label5
      // 
      this.label5.AutoSize = true;
      this.label5.Location = new System.Drawing.Point(12, 183);
      this.label5.Name = "label5";
      this.label5.Size = new System.Drawing.Size(71, 13);
      this.label5.TabIndex = 14;
      this.label5.Text = "Elapsed Time";
      // 
      // cbOpcServer
      // 
      this.cbOpcServer.FormattingEnabled = true;
      this.cbOpcServer.Items.AddRange(new object[] {
            "FossOpcServer",
            "KepServer V6",
            "KepServer V5"});
      this.cbOpcServer.Location = new System.Drawing.Point(15, 226);
      this.cbOpcServer.Name = "cbOpcServer";
      this.cbOpcServer.Size = new System.Drawing.Size(121, 21);
      this.cbOpcServer.TabIndex = 15;
      this.cbOpcServer.Text = "KepServer V6";
      // 
      // tbGroupName
      // 
      this.tbGroupName.Location = new System.Drawing.Point(165, 227);
      this.tbGroupName.Name = "tbGroupName";
      this.tbGroupName.Size = new System.Drawing.Size(122, 20);
      this.tbGroupName.TabIndex = 1;
      this.tbGroupName.Text = "MMII.PDx";
      // 
      // label6
      // 
      this.label6.AutoSize = true;
      this.label6.Location = new System.Drawing.Point(162, 211);
      this.label6.Name = "label6";
      this.label6.Size = new System.Drawing.Size(36, 13);
      this.label6.TabIndex = 0;
      this.label6.Text = "Group";
      // 
      // label7
      // 
      this.label7.AutoSize = true;
      this.label7.Location = new System.Drawing.Point(17, 213);
      this.label7.Name = "label7";
      this.label7.Size = new System.Drawing.Size(58, 13);
      this.label7.TabIndex = 16;
      this.label7.Text = "OpcServer";
      // 
      // tbUpdateRate
      // 
      this.tbUpdateRate.Location = new System.Drawing.Point(330, 227);
      this.tbUpdateRate.Name = "tbUpdateRate";
      this.tbUpdateRate.Size = new System.Drawing.Size(100, 20);
      this.tbUpdateRate.TabIndex = 17;
      this.tbUpdateRate.Text = "100";
      this.tbUpdateRate.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
      // 
      // label8
      // 
      this.label8.AutoSize = true;
      this.label8.Location = new System.Drawing.Point(327, 211);
      this.label8.Name = "label8";
      this.label8.Size = new System.Drawing.Size(60, 13);
      this.label8.TabIndex = 18;
      this.label8.Text = "Updaterate";
      // 
      // MainForm
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(571, 275);
      this.Controls.Add(this.label8);
      this.Controls.Add(this.tbUpdateRate);
      this.Controls.Add(this.label7);
      this.Controls.Add(this.label6);
      this.Controls.Add(this.tbGroupName);
      this.Controls.Add(this.cbOpcServer);
      this.Controls.Add(this.label5);
      this.Controls.Add(this.label4);
      this.Controls.Add(this.label3);
      this.Controls.Add(this.label2);
      this.Controls.Add(this.label1);
      this.Controls.Add(this.elapsedTimeLabel);
      this.Controls.Add(this.sampleTimeLabel);
      this.Controls.Add(this.sampleNumberLabel);
      this.Controls.Add(this.sampleIdLabel);
      this.Controls.Add(this.opcClientTimeLabel);
      this.Controls.Add(this.disconnectButton);
      this.Controls.Add(this.connectButton);
      this.Name = "MainForm";
      this.Text = "OPC Csv Logger client";
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.Button connectButton;
    private System.Windows.Forms.Button disconnectButton;
    private System.Windows.Forms.Timer getSampleTimer;
    private System.Windows.Forms.Label opcClientTimeLabel;
    private System.Windows.Forms.Label sampleIdLabel;
    private System.Windows.Forms.Label sampleNumberLabel;
    private System.Windows.Forms.Label sampleTimeLabel;
    private System.Windows.Forms.Label elapsedTimeLabel;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.Label label3;
    private System.Windows.Forms.Label label4;
    private System.Windows.Forms.Label label5;
    private System.Windows.Forms.ComboBox cbOpcServer;
    private System.Windows.Forms.TextBox tbGroupName;
    private System.Windows.Forms.Label label6;
    private System.Windows.Forms.Label label7;
    private System.Windows.Forms.TextBox tbUpdateRate;
    private System.Windows.Forms.Label label8;
  }
}

