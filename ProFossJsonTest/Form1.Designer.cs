namespace ProFossJsonTest
{
  partial class Form1
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
      this.startBtn = new System.Windows.Forms.Button();
      this.stopBtn = new System.Windows.Forms.Button();
      this.groupBox1 = new System.Windows.Forms.GroupBox();
      this.calibrationButton = new System.Windows.Forms.Button();
      this.resetInstrumentBtn = new System.Windows.Forms.Button();
      this.getInstrumentsBtn = new System.Windows.Forms.Button();
      this.label1 = new System.Windows.Forms.Label();
      this.productsCb = new System.Windows.Forms.ComboBox();
      this.getProductsBtn = new System.Windows.Forms.Button();
      this.groupBox2 = new System.Windows.Forms.GroupBox();
      this.startStopBtn = new System.Windows.Forms.Button();
      this.label3 = new System.Windows.Forms.Label();
      this.pauseTb = new System.Windows.Forms.TextBox();
      this.label2 = new System.Windows.Forms.Label();
      this.measureTb = new System.Windows.Forms.TextBox();
      this.textBox2 = new System.Windows.Forms.TextBox();
      this.ipTb = new System.Windows.Forms.TextBox();
      this.label4 = new System.Windows.Forms.Label();
      this.respondTb = new System.Windows.Forms.TextBox();
      this.instrumentListBox = new System.Windows.Forms.ListBox();
      this.label5 = new System.Windows.Forms.Label();
      this.groupBox1.SuspendLayout();
      this.groupBox2.SuspendLayout();
      this.SuspendLayout();
      // 
      // startBtn
      // 
      this.startBtn.Location = new System.Drawing.Point(6, 24);
      this.startBtn.Name = "startBtn";
      this.startBtn.Size = new System.Drawing.Size(75, 23);
      this.startBtn.TabIndex = 0;
      this.startBtn.Text = "Start";
      this.startBtn.UseVisualStyleBackColor = true;
      this.startBtn.Click += new System.EventHandler(this.startBtn_Click);
      // 
      // stopBtn
      // 
      this.stopBtn.Location = new System.Drawing.Point(6, 53);
      this.stopBtn.Name = "stopBtn";
      this.stopBtn.Size = new System.Drawing.Size(75, 23);
      this.stopBtn.TabIndex = 1;
      this.stopBtn.Text = "Stop";
      this.stopBtn.UseVisualStyleBackColor = true;
      this.stopBtn.Click += new System.EventHandler(this.stopBtn_Click);
      // 
      // groupBox1
      // 
      this.groupBox1.Controls.Add(this.calibrationButton);
      this.groupBox1.Controls.Add(this.resetInstrumentBtn);
      this.groupBox1.Controls.Add(this.getInstrumentsBtn);
      this.groupBox1.Controls.Add(this.label1);
      this.groupBox1.Controls.Add(this.productsCb);
      this.groupBox1.Controls.Add(this.getProductsBtn);
      this.groupBox1.Controls.Add(this.stopBtn);
      this.groupBox1.Controls.Add(this.startBtn);
      this.groupBox1.Location = new System.Drawing.Point(12, 28);
      this.groupBox1.Name = "groupBox1";
      this.groupBox1.Size = new System.Drawing.Size(229, 173);
      this.groupBox1.TabIndex = 3;
      this.groupBox1.TabStop = false;
      this.groupBox1.Text = "Control";
      // 
      // calibrationButton
      // 
      this.calibrationButton.Location = new System.Drawing.Point(87, 82);
      this.calibrationButton.Name = "calibrationButton";
      this.calibrationButton.Size = new System.Drawing.Size(101, 23);
      this.calibrationButton.TabIndex = 12;
      this.calibrationButton.Text = "Calibration";
      this.calibrationButton.UseVisualStyleBackColor = true;
      this.calibrationButton.Click += new System.EventHandler(this.calibrationButton_Click);
      // 
      // resetInstrumentBtn
      // 
      this.resetInstrumentBtn.Location = new System.Drawing.Point(87, 111);
      this.resetInstrumentBtn.Name = "resetInstrumentBtn";
      this.resetInstrumentBtn.Size = new System.Drawing.Size(101, 23);
      this.resetInstrumentBtn.TabIndex = 11;
      this.resetInstrumentBtn.Text = "Reset Instrument";
      this.resetInstrumentBtn.UseVisualStyleBackColor = true;
      this.resetInstrumentBtn.Click += new System.EventHandler(this.resetInstrumentBtn_Click);
      // 
      // getInstrumentsBtn
      // 
      this.getInstrumentsBtn.Location = new System.Drawing.Point(6, 111);
      this.getInstrumentsBtn.Name = "getInstrumentsBtn";
      this.getInstrumentsBtn.Size = new System.Drawing.Size(75, 23);
      this.getInstrumentsBtn.TabIndex = 8;
      this.getInstrumentsBtn.Text = "Instruments";
      this.getInstrumentsBtn.UseVisualStyleBackColor = true;
      this.getInstrumentsBtn.Click += new System.EventHandler(this.getInstrumentsBtn_Click);
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.Location = new System.Drawing.Point(87, 10);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(44, 13);
      this.label1.TabIndex = 7;
      this.label1.Text = "Product";
      // 
      // productsCb
      // 
      this.productsCb.FormattingEnabled = true;
      this.productsCb.Location = new System.Drawing.Point(87, 26);
      this.productsCb.Name = "productsCb";
      this.productsCb.Size = new System.Drawing.Size(121, 21);
      this.productsCb.TabIndex = 6;
      this.productsCb.SelectedIndexChanged += new System.EventHandler(this.productsCb_SelectedIndexChanged);
      // 
      // getProductsBtn
      // 
      this.getProductsBtn.Location = new System.Drawing.Point(6, 82);
      this.getProductsBtn.Name = "getProductsBtn";
      this.getProductsBtn.Size = new System.Drawing.Size(75, 23);
      this.getProductsBtn.TabIndex = 4;
      this.getProductsBtn.Text = "Products";
      this.getProductsBtn.UseVisualStyleBackColor = true;
      this.getProductsBtn.Click += new System.EventHandler(this.getProductsBtn_Click);
      // 
      // groupBox2
      // 
      this.groupBox2.Controls.Add(this.startStopBtn);
      this.groupBox2.Controls.Add(this.label3);
      this.groupBox2.Controls.Add(this.pauseTb);
      this.groupBox2.Controls.Add(this.label2);
      this.groupBox2.Controls.Add(this.measureTb);
      this.groupBox2.Location = new System.Drawing.Point(293, 30);
      this.groupBox2.Name = "groupBox2";
      this.groupBox2.Size = new System.Drawing.Size(200, 171);
      this.groupBox2.TabIndex = 4;
      this.groupBox2.TabStop = false;
      this.groupBox2.Text = "Simulate";
      // 
      // startStopBtn
      // 
      this.startStopBtn.Location = new System.Drawing.Point(66, 128);
      this.startStopBtn.Name = "startStopBtn";
      this.startStopBtn.Size = new System.Drawing.Size(75, 23);
      this.startStopBtn.TabIndex = 4;
      this.startStopBtn.Text = "Start";
      this.startStopBtn.UseVisualStyleBackColor = true;
      this.startStopBtn.Click += new System.EventHandler(this.startStopBtn_Click);
      // 
      // label3
      // 
      this.label3.AutoSize = true;
      this.label3.Location = new System.Drawing.Point(63, 75);
      this.label3.Name = "label3";
      this.label3.Size = new System.Drawing.Size(73, 13);
      this.label3.TabIndex = 3;
      this.label3.Text = "Pause time [s]";
      // 
      // pauseTb
      // 
      this.pauseTb.Location = new System.Drawing.Point(66, 91);
      this.pauseTb.Name = "pauseTb";
      this.pauseTb.Size = new System.Drawing.Size(100, 20);
      this.pauseTb.TabIndex = 2;
      // 
      // label2
      // 
      this.label2.AutoSize = true;
      this.label2.Location = new System.Drawing.Point(63, 32);
      this.label2.Name = "label2";
      this.label2.Size = new System.Drawing.Size(84, 13);
      this.label2.TabIndex = 1;
      this.label2.Text = "Measure time [s]";
      // 
      // measureTb
      // 
      this.measureTb.Location = new System.Drawing.Point(66, 48);
      this.measureTb.Name = "measureTb";
      this.measureTb.Size = new System.Drawing.Size(100, 20);
      this.measureTb.TabIndex = 0;
      // 
      // textBox2
      // 
      this.textBox2.Location = new System.Drawing.Point(66, 91);
      this.textBox2.Name = "textBox2";
      this.textBox2.Size = new System.Drawing.Size(100, 20);
      this.textBox2.TabIndex = 2;
      // 
      // ipTb
      // 
      this.ipTb.Location = new System.Drawing.Point(18, 230);
      this.ipTb.Name = "ipTb";
      this.ipTb.Size = new System.Drawing.Size(182, 20);
      this.ipTb.TabIndex = 5;
      this.ipTb.Text = "Lab-Pf-Win10";
      // 
      // label4
      // 
      this.label4.AutoSize = true;
      this.label4.Location = new System.Drawing.Point(17, 209);
      this.label4.Name = "label4";
      this.label4.Size = new System.Drawing.Size(87, 13);
      this.label4.TabIndex = 6;
      this.label4.Text = "Ip address/name";
      // 
      // respondTb
      // 
      this.respondTb.Location = new System.Drawing.Point(18, 369);
      this.respondTb.Multiline = true;
      this.respondTb.Name = "respondTb";
      this.respondTb.ReadOnly = true;
      this.respondTb.Size = new System.Drawing.Size(475, 115);
      this.respondTb.TabIndex = 9;
      this.respondTb.Text = "Hej\r\nMed\r\nDig";
      // 
      // instrumentListBox
      // 
      this.instrumentListBox.FormattingEnabled = true;
      this.instrumentListBox.Location = new System.Drawing.Point(293, 230);
      this.instrumentListBox.Name = "instrumentListBox";
      this.instrumentListBox.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
      this.instrumentListBox.Size = new System.Drawing.Size(200, 121);
      this.instrumentListBox.TabIndex = 12;
      // 
      // label5
      // 
      this.label5.AutoSize = true;
      this.label5.Location = new System.Drawing.Point(290, 209);
      this.label5.Name = "label5";
      this.label5.Size = new System.Drawing.Size(61, 13);
      this.label5.TabIndex = 13;
      this.label5.Text = "Instruments";
      // 
      // Form1
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(522, 507);
      this.Controls.Add(this.label5);
      this.Controls.Add(this.instrumentListBox);
      this.Controls.Add(this.respondTb);
      this.Controls.Add(this.label4);
      this.Controls.Add(this.ipTb);
      this.Controls.Add(this.groupBox2);
      this.Controls.Add(this.groupBox1);
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
      this.Name = "Form1";
      this.Text = "ProFoss web client";
      this.groupBox1.ResumeLayout(false);
      this.groupBox1.PerformLayout();
      this.groupBox2.ResumeLayout(false);
      this.groupBox2.PerformLayout();
      this.ResumeLayout(false);
      this.PerformLayout();

    }

        #endregion

        private System.Windows.Forms.Button startBtn;
        private System.Windows.Forms.Button stopBtn;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button startStopBtn;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox pauseTb;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox measureTb;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox ipTb;
        private System.Windows.Forms.Label label4;
    private System.Windows.Forms.TextBox respondTb;
    private System.Windows.Forms.Button getProductsBtn;
    private System.Windows.Forms.ComboBox productsCb;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.Button getInstrumentsBtn;
    private System.Windows.Forms.Button resetInstrumentBtn;
    private System.Windows.Forms.Button calibrationButton;
    private System.Windows.Forms.ListBox instrumentListBox;
    private System.Windows.Forms.Label label5;
  }
}

