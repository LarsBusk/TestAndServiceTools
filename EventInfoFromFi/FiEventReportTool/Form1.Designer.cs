namespace FiEventReportTool
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
      this.readReportButton = new System.Windows.Forms.Button();
      this.addToDbButton = new System.Windows.Forms.Button();
      this.browseButton = new System.Windows.Forms.Button();
      this.detailsLabel = new System.Windows.Forms.Label();
      this.startTimeTextBox = new System.Windows.Forms.TextBox();
      this.endtimeTextBox = new System.Windows.Forms.TextBox();
      this.groupBox1 = new System.Windows.Forms.GroupBox();
      this.label2 = new System.Windows.Forms.Label();
      this.label1 = new System.Windows.Forms.Label();
      this.groupBox2 = new System.Windows.Forms.GroupBox();
      this.label3 = new System.Windows.Forms.Label();
      this.CountryLbl = new System.Windows.Forms.Label();
      this.companyComboBox = new System.Windows.Forms.ComboBox();
      this.countryComboBox = new System.Windows.Forms.ComboBox();
      this.groupBox1.SuspendLayout();
      this.groupBox2.SuspendLayout();
      this.SuspendLayout();
      // 
      // readReportButton
      // 
      this.readReportButton.Location = new System.Drawing.Point(487, 277);
      this.readReportButton.Margin = new System.Windows.Forms.Padding(2);
      this.readReportButton.Name = "readReportButton";
      this.readReportButton.Size = new System.Drawing.Size(85, 26);
      this.readReportButton.TabIndex = 0;
      this.readReportButton.Text = "Read Report";
      this.readReportButton.UseVisualStyleBackColor = true;
      this.readReportButton.Click += new System.EventHandler(this.readReportButton_Click);
      // 
      // addToDbButton
      // 
      this.addToDbButton.Location = new System.Drawing.Point(487, 316);
      this.addToDbButton.Margin = new System.Windows.Forms.Padding(2);
      this.addToDbButton.Name = "addToDbButton";
      this.addToDbButton.Size = new System.Drawing.Size(85, 25);
      this.addToDbButton.TabIndex = 1;
      this.addToDbButton.Text = "Add to db";
      this.addToDbButton.UseVisualStyleBackColor = true;
      this.addToDbButton.Click += new System.EventHandler(this.addToDbButton_Click);
      // 
      // browseButton
      // 
      this.browseButton.Location = new System.Drawing.Point(487, 238);
      this.browseButton.Margin = new System.Windows.Forms.Padding(2);
      this.browseButton.Name = "browseButton";
      this.browseButton.Size = new System.Drawing.Size(85, 27);
      this.browseButton.TabIndex = 2;
      this.browseButton.Text = "Browse";
      this.browseButton.UseVisualStyleBackColor = true;
      this.browseButton.Click += new System.EventHandler(this.BrowseButton_Click);
      // 
      // detailsLabel
      // 
      this.detailsLabel.AutoSize = true;
      this.detailsLabel.Location = new System.Drawing.Point(260, 33);
      this.detailsLabel.Name = "detailsLabel";
      this.detailsLabel.Size = new System.Drawing.Size(70, 13);
      this.detailsLabel.TabIndex = 4;
      this.detailsLabel.Text = "Report detals";
      // 
      // startTimeTextBox
      // 
      this.startTimeTextBox.Location = new System.Drawing.Point(6, 28);
      this.startTimeTextBox.Name = "startTimeTextBox";
      this.startTimeTextBox.Size = new System.Drawing.Size(188, 20);
      this.startTimeTextBox.TabIndex = 5;
      // 
      // endtimeTextBox
      // 
      this.endtimeTextBox.Location = new System.Drawing.Point(6, 64);
      this.endtimeTextBox.Name = "endtimeTextBox";
      this.endtimeTextBox.Size = new System.Drawing.Size(188, 20);
      this.endtimeTextBox.TabIndex = 6;
      // 
      // groupBox1
      // 
      this.groupBox1.Controls.Add(this.label2);
      this.groupBox1.Controls.Add(this.label1);
      this.groupBox1.Controls.Add(this.endtimeTextBox);
      this.groupBox1.Controls.Add(this.startTimeTextBox);
      this.groupBox1.Location = new System.Drawing.Point(12, 33);
      this.groupBox1.Name = "groupBox1";
      this.groupBox1.Size = new System.Drawing.Size(200, 100);
      this.groupBox1.TabIndex = 7;
      this.groupBox1.TabStop = false;
      this.groupBox1.Text = "Eventreport time";
      // 
      // label2
      // 
      this.label2.AutoSize = true;
      this.label2.Location = new System.Drawing.Point(6, 51);
      this.label2.Name = "label2";
      this.label2.Size = new System.Drawing.Size(25, 13);
      this.label2.TabIndex = 8;
      this.label2.Text = "end";
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.Location = new System.Drawing.Point(6, 12);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(27, 13);
      this.label1.TabIndex = 7;
      this.label1.Text = "start";
      // 
      // groupBox2
      // 
      this.groupBox2.Controls.Add(this.countryComboBox);
      this.groupBox2.Controls.Add(this.companyComboBox);
      this.groupBox2.Controls.Add(this.CountryLbl);
      this.groupBox2.Controls.Add(this.label3);
      this.groupBox2.Location = new System.Drawing.Point(12, 174);
      this.groupBox2.Name = "groupBox2";
      this.groupBox2.Size = new System.Drawing.Size(260, 129);
      this.groupBox2.TabIndex = 9;
      this.groupBox2.TabStop = false;
      this.groupBox2.Text = "Customer info";
      // 
      // label3
      // 
      this.label3.AutoSize = true;
      this.label3.Location = new System.Drawing.Point(6, 28);
      this.label3.Name = "label3";
      this.label3.Size = new System.Drawing.Size(51, 13);
      this.label3.TabIndex = 9;
      this.label3.Text = "Company";
      // 
      // CountryLbl
      // 
      this.CountryLbl.AutoSize = true;
      this.CountryLbl.Location = new System.Drawing.Point(6, 74);
      this.CountryLbl.Name = "CountryLbl";
      this.CountryLbl.Size = new System.Drawing.Size(43, 13);
      this.CountryLbl.TabIndex = 11;
      this.CountryLbl.Text = "Country";
      // 
      // companyComboBox
      // 
      this.companyComboBox.FormattingEnabled = true;
      this.companyComboBox.Location = new System.Drawing.Point(9, 44);
      this.companyComboBox.Name = "companyComboBox";
      this.companyComboBox.Size = new System.Drawing.Size(236, 21);
      this.companyComboBox.TabIndex = 12;
      // 
      // countryComboBox
      // 
      this.countryComboBox.FormattingEnabled = true;
      this.countryComboBox.Location = new System.Drawing.Point(9, 90);
      this.countryComboBox.Name = "countryComboBox";
      this.countryComboBox.Size = new System.Drawing.Size(236, 21);
      this.countryComboBox.TabIndex = 13;
      // 
      // MainForm
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(600, 366);
      this.Controls.Add(this.groupBox2);
      this.Controls.Add(this.groupBox1);
      this.Controls.Add(this.detailsLabel);
      this.Controls.Add(this.browseButton);
      this.Controls.Add(this.addToDbButton);
      this.Controls.Add(this.readReportButton);
      this.Margin = new System.Windows.Forms.Padding(2);
      this.Name = "MainForm";
      this.Text = "Foss Integrator Event Report Tool";
      this.Load += new System.EventHandler(this.MainForm_Load);
      this.groupBox1.ResumeLayout(false);
      this.groupBox1.PerformLayout();
      this.groupBox2.ResumeLayout(false);
      this.groupBox2.PerformLayout();
      this.ResumeLayout(false);
      this.PerformLayout();

    }

        #endregion

        private System.Windows.Forms.Button readReportButton;
        private System.Windows.Forms.Button addToDbButton;
        private System.Windows.Forms.Button browseButton;
    private System.Windows.Forms.Label detailsLabel;
    private System.Windows.Forms.TextBox startTimeTextBox;
    private System.Windows.Forms.TextBox endtimeTextBox;
    private System.Windows.Forms.GroupBox groupBox1;
    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ComboBox countryComboBox;
        private System.Windows.Forms.ComboBox companyComboBox;
        private System.Windows.Forms.Label CountryLbl;
        private System.Windows.Forms.Label label3;
    }
}

