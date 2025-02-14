namespace NumberConverter
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
            this.buttonConvert = new System.Windows.Forms.Button();
            this.inputStyleLabel = new System.Windows.Forms.Label();
            this.mosaicTb = new System.Windows.Forms.TextBox();
            this.buttonClose = new System.Windows.Forms.Button();
            this.HiLoTb = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.convertToMosaicBtn = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.convertFromDecCidBtn = new System.Windows.Forms.Button();
            this.convertFromHexCidBtn = new System.Windows.Forms.Button();
            this.convertFromFiCidBtn = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.decimalCidTb = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.hexCidTb = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.fiCidTb = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonConvert
            // 
            this.buttonConvert.Location = new System.Drawing.Point(232, 39);
            this.buttonConvert.Name = "buttonConvert";
            this.buttonConvert.Size = new System.Drawing.Size(75, 23);
            this.buttonConvert.TabIndex = 0;
            this.buttonConvert.Text = "&Convert";
            this.buttonConvert.UseVisualStyleBackColor = true;
            this.buttonConvert.Click += new System.EventHandler(this.buttonConvert_Click);
            // 
            // inputStyleLabel
            // 
            this.inputStyleLabel.AutoSize = true;
            this.inputStyleLabel.Location = new System.Drawing.Point(2, 26);
            this.inputStyleLabel.Name = "inputStyleLabel";
            this.inputStyleLabel.Size = new System.Drawing.Size(196, 13);
            this.inputStyleLabel.TabIndex = 1;
            this.inputStyleLabel.Text = "Mosaic Instrument ID number to convert";
            // 
            // mosaicTb
            // 
            this.mosaicTb.Location = new System.Drawing.Point(5, 42);
            this.mosaicTb.Name = "mosaicTb";
            this.mosaicTb.Size = new System.Drawing.Size(221, 20);
            this.mosaicTb.TabIndex = 1;
            this.mosaicTb.Text = "0";
            // 
            // buttonClose
            // 
            this.buttonClose.Location = new System.Drawing.Point(369, 340);
            this.buttonClose.Name = "buttonClose";
            this.buttonClose.Size = new System.Drawing.Size(75, 23);
            this.buttonClose.TabIndex = 4;
            this.buttonClose.Text = "C&lose";
            this.buttonClose.UseVisualStyleBackColor = true;
            this.buttonClose.Click += new System.EventHandler(this.buttonClose_Click);
            // 
            // HiLoTb
            // 
            this.HiLoTb.Location = new System.Drawing.Point(5, 83);
            this.HiLoTb.Margin = new System.Windows.Forms.Padding(2);
            this.HiLoTb.Name = "HiLoTb";
            this.HiLoTb.Size = new System.Drawing.Size(221, 20);
            this.HiLoTb.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(2, 65);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(131, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Hi, lo chassisid to convert.";
            // 
            // convertToMosaicBtn
            // 
            this.convertToMosaicBtn.Location = new System.Drawing.Point(232, 80);
            this.convertToMosaicBtn.Name = "convertToMosaicBtn";
            this.convertToMosaicBtn.Size = new System.Drawing.Size(75, 23);
            this.convertToMosaicBtn.TabIndex = 8;
            this.convertToMosaicBtn.Text = "Convert";
            this.convertToMosaicBtn.UseVisualStyleBackColor = true;
            this.convertToMosaicBtn.Click += new System.EventHandler(this.convertToMosaicBtn_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.HiLoTb);
            this.groupBox1.Controls.Add(this.convertToMosaicBtn);
            this.groupBox1.Controls.Add(this.buttonConvert);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.inputStyleLabel);
            this.groupBox1.Controls.Add(this.mosaicTb);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(342, 120);
            this.groupBox1.TabIndex = 9;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Chassis ID";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.convertFromDecCidBtn);
            this.groupBox2.Controls.Add(this.convertFromHexCidBtn);
            this.groupBox2.Controls.Add(this.convertFromFiCidBtn);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.decimalCidTb);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.hexCidTb);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.fiCidTb);
            this.groupBox2.Location = new System.Drawing.Point(15, 139);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(339, 195);
            this.groupBox2.TabIndex = 10;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "CID";
            // 
            // convertFromDecCidBtn
            // 
            this.convertFromDecCidBtn.Location = new System.Drawing.Point(229, 134);
            this.convertFromDecCidBtn.Name = "convertFromDecCidBtn";
            this.convertFromDecCidBtn.Size = new System.Drawing.Size(75, 23);
            this.convertFromDecCidBtn.TabIndex = 8;
            this.convertFromDecCidBtn.Text = "Convert";
            this.convertFromDecCidBtn.UseVisualStyleBackColor = true;
            this.convertFromDecCidBtn.Click += new System.EventHandler(this.convertFromDecCidBtn_Click);
            // 
            // convertFromHexCidBtn
            // 
            this.convertFromHexCidBtn.Location = new System.Drawing.Point(229, 84);
            this.convertFromHexCidBtn.Name = "convertFromHexCidBtn";
            this.convertFromHexCidBtn.Size = new System.Drawing.Size(75, 23);
            this.convertFromHexCidBtn.TabIndex = 7;
            this.convertFromHexCidBtn.Text = "Convert";
            this.convertFromHexCidBtn.UseVisualStyleBackColor = true;
            this.convertFromHexCidBtn.Click += new System.EventHandler(this.convertFromHexCidBtn_Click);
            // 
            // convertFromFiCidBtn
            // 
            this.convertFromFiCidBtn.Location = new System.Drawing.Point(229, 37);
            this.convertFromFiCidBtn.Name = "convertFromFiCidBtn";
            this.convertFromFiCidBtn.Size = new System.Drawing.Size(75, 23);
            this.convertFromFiCidBtn.TabIndex = 6;
            this.convertFromFiCidBtn.Text = "Convert";
            this.convertFromFiCidBtn.UseVisualStyleBackColor = true;
            this.convertFromFiCidBtn.Click += new System.EventHandler(this.convertFromFiCidBtn_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 120);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(45, 13);
            this.label4.TabIndex = 5;
            this.label4.Text = "Decimal";
            // 
            // decimalCidTb
            // 
            this.decimalCidTb.Location = new System.Drawing.Point(15, 136);
            this.decimalCidTb.Name = "decimalCidTb";
            this.decimalCidTb.Size = new System.Drawing.Size(208, 20);
            this.decimalCidTb.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 71);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "HEX";
            // 
            // hexCidTb
            // 
            this.hexCidTb.Location = new System.Drawing.Point(15, 87);
            this.hexCidTb.Name = "hexCidTb";
            this.hexCidTb.Size = new System.Drawing.Size(208, 20);
            this.hexCidTb.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 24);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Fi Style";
            // 
            // fiCidTb
            // 
            this.fiCidTb.Location = new System.Drawing.Point(15, 40);
            this.fiCidTb.Name = "fiCidTb";
            this.fiCidTb.Size = new System.Drawing.Size(208, 20);
            this.fiCidTb.TabIndex = 0;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(456, 375);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.buttonClose);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "Number Converter";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonConvert;
        private System.Windows.Forms.Label inputStyleLabel;
        private System.Windows.Forms.TextBox mosaicTb;
        private System.Windows.Forms.Button buttonClose;
        private System.Windows.Forms.TextBox HiLoTb;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button convertToMosaicBtn;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button convertFromDecCidBtn;
        private System.Windows.Forms.Button convertFromHexCidBtn;
        private System.Windows.Forms.Button convertFromFiCidBtn;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox decimalCidTb;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox hexCidTb;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox fiCidTb;
    }
}

