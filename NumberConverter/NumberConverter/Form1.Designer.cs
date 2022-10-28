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
            this.textBoxInput = new System.Windows.Forms.TextBox();
            this.panelConvertTo = new System.Windows.Forms.Panel();
            this.convertToFI = new System.Windows.Forms.RadioButton();
            this.convertMosaic = new System.Windows.Forms.RadioButton();
            this.label2 = new System.Windows.Forms.Label();
            this.buttonClose = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.resultTb = new System.Windows.Forms.TextBox();
            this.panelConvertTo.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonConvert
            // 
            this.buttonConvert.Location = new System.Drawing.Point(435, 180);
            this.buttonConvert.Margin = new System.Windows.Forms.Padding(4);
            this.buttonConvert.Name = "buttonConvert";
            this.buttonConvert.Size = new System.Drawing.Size(100, 28);
            this.buttonConvert.TabIndex = 0;
            this.buttonConvert.Text = "&Convert";
            this.buttonConvert.UseVisualStyleBackColor = true;
            this.buttonConvert.Click += new System.EventHandler(this.buttonConvert_Click);
            // 
            // inputStyleLabel
            // 
            this.inputStyleLabel.AutoSize = true;
            this.inputStyleLabel.Location = new System.Drawing.Point(37, 22);
            this.inputStyleLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.inputStyleLabel.Name = "inputStyleLabel";
            this.inputStyleLabel.Size = new System.Drawing.Size(239, 16);
            this.inputStyleLabel.TabIndex = 1;
            this.inputStyleLabel.Text = "Mosaic Instrument ID number to convert";
            // 
            // textBoxInput
            // 
            this.textBoxInput.Location = new System.Drawing.Point(41, 42);
            this.textBoxInput.Margin = new System.Windows.Forms.Padding(4);
            this.textBoxInput.Name = "textBoxInput";
            this.textBoxInput.Size = new System.Drawing.Size(293, 22);
            this.textBoxInput.TabIndex = 1;
            this.textBoxInput.Text = "0";
            // 
            // panelConvertTo
            // 
            this.panelConvertTo.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panelConvertTo.Controls.Add(this.convertToFI);
            this.panelConvertTo.Controls.Add(this.convertMosaic);
            this.panelConvertTo.Location = new System.Drawing.Point(41, 90);
            this.panelConvertTo.Margin = new System.Windows.Forms.Padding(4);
            this.panelConvertTo.Name = "panelConvertTo";
            this.panelConvertTo.Size = new System.Drawing.Size(229, 82);
            this.panelConvertTo.TabIndex = 3;
            // 
            // convertToFI
            // 
            this.convertToFI.AutoSize = true;
            this.convertToFI.Checked = true;
            this.convertToFI.Location = new System.Drawing.Point(12, 44);
            this.convertToFI.Margin = new System.Windows.Forms.Padding(4);
            this.convertToFI.Name = "convertToFI";
            this.convertToFI.Size = new System.Drawing.Size(145, 20);
            this.convertToFI.TabIndex = 4;
            this.convertToFI.TabStop = true;
            this.convertToFI.Text = "&Foss Integrator style";
            this.convertToFI.UseVisualStyleBackColor = true;
            this.convertToFI.CheckedChanged += new System.EventHandler(this.convertToFI_CheckedChanged);
            // 
            // convertMosaic
            // 
            this.convertMosaic.AutoSize = true;
            this.convertMosaic.Location = new System.Drawing.Point(12, 15);
            this.convertMosaic.Margin = new System.Windows.Forms.Padding(4);
            this.convertMosaic.Name = "convertMosaic";
            this.convertMosaic.Size = new System.Drawing.Size(100, 20);
            this.convertMosaic.TabIndex = 3;
            this.convertMosaic.Text = "&Mosaic style";
            this.convertMosaic.UseVisualStyleBackColor = true;
            this.convertMosaic.CheckedChanged += new System.EventHandler(this.convertMosaic_CheckedChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(49, 70);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 16);
            this.label2.TabIndex = 0;
            this.label2.Text = "Convert to";
            // 
            // buttonClose
            // 
            this.buttonClose.Location = new System.Drawing.Point(435, 215);
            this.buttonClose.Margin = new System.Windows.Forms.Padding(4);
            this.buttonClose.Name = "buttonClose";
            this.buttonClose.Size = new System.Drawing.Size(100, 28);
            this.buttonClose.TabIndex = 4;
            this.buttonClose.Text = "C&lose";
            this.buttonClose.UseVisualStyleBackColor = true;
            this.buttonClose.Click += new System.EventHandler(this.buttonClose_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(41, 222);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(48, 16);
            this.label3.TabIndex = 5;
            this.label3.Text = "Result:";
            // 
            // resultTb
            // 
            this.resultTb.Location = new System.Drawing.Point(96, 219);
            this.resultTb.Name = "resultTb";
            this.resultTb.ReadOnly = true;
            this.resultTb.Size = new System.Drawing.Size(194, 22);
            this.resultTb.TabIndex = 6;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(551, 261);
            this.Controls.Add(this.resultTb);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.buttonClose);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.panelConvertTo);
            this.Controls.Add(this.textBoxInput);
            this.Controls.Add(this.inputStyleLabel);
            this.Controls.Add(this.buttonConvert);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "ChassisID Converter";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panelConvertTo.ResumeLayout(false);
            this.panelConvertTo.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonConvert;
        private System.Windows.Forms.Label inputStyleLabel;
        private System.Windows.Forms.TextBox textBoxInput;
        private System.Windows.Forms.Panel panelConvertTo;
        private System.Windows.Forms.RadioButton convertToFI;
        private System.Windows.Forms.RadioButton convertMosaic;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button buttonClose;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox resultTb;
    }
}

