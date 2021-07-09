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
      this.addToDbButton = new System.Windows.Forms.Button();
      this.browseButton = new System.Windows.Forms.Button();
      this.detailsLabel = new System.Windows.Forms.Label();
      this.startTimeTextBox = new System.Windows.Forms.TextBox();
      this.endtimeTextBox = new System.Windows.Forms.TextBox();
      this.groupBox1 = new System.Windows.Forms.GroupBox();
      this.label2 = new System.Windows.Forms.Label();
      this.label1 = new System.Windows.Forms.Label();
      this.groupBox2 = new System.Windows.Forms.GroupBox();
      this.countryComboBox = new System.Windows.Forms.ComboBox();
      this.companyComboBox = new System.Windows.Forms.ComboBox();
      this.CountryLbl = new System.Windows.Forms.Label();
      this.label3 = new System.Windows.Forms.Label();
      this.groupBox1.SuspendLayout();
      this.groupBox2.SuspendLayout();
      this.SuspendLayout();
      // 
      // addToDbButton
      // 
      this.addToDbButton.Location = new System.Drawing.Point(649, 342);
      this.addToDbButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
      this.addToDbButton.Name = "addToDbButton";
      this.addToDbButton.Size = new System.Drawing.Size(113, 31);
      this.addToDbButton.TabIndex = 1;
      this.addToDbButton.Text = "Add to db";
      this.addToDbButton.UseVisualStyleBackColor = true;
      this.addToDbButton.Click += new System.EventHandler(this.addToDbButton_Click);
      // 
      // browseButton
      // 
      this.browseButton.Location = new System.Drawing.Point(649, 289);
      this.browseButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
      this.browseButton.Name = "browseButton";
      this.browseButton.Size = new System.Drawing.Size(113, 33);
      this.browseButton.TabIndex = 2;
      this.browseButton.Text = "Browse";
      this.browseButton.UseVisualStyleBackColor = true;
      this.browseButton.Click += new System.EventHandler(this.BrowseButton_Click);
      // 
      // detailsLabel
      // 
      this.detailsLabel.AutoSize = true;
      this.detailsLabel.Location = new System.Drawing.Point(347, 41);
      this.detailsLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
      this.detailsLabel.Name = "detailsLabel";
      this.detailsLabel.Size = new System.Drawing.Size(93, 17);
      this.detailsLabel.TabIndex = 4;
      this.detailsLabel.Text = "Report detals";
      // 
      // startTimeTextBox
      // 
      this.startTimeTextBox.Location = new System.Drawing.Point(8, 49);
      this.startTimeTextBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
      this.startTimeTextBox.Name = "startTimeTextBox";
      this.startTimeTextBox.Size = new System.Drawing.Size(249, 22);
      this.startTimeTextBox.TabIndex = 5;
      // 
      // endtimeTextBox
      // 
      this.endtimeTextBox.Location = new System.Drawing.Point(8, 93);
      this.endtimeTextBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
      this.endtimeTextBox.Name = "endtimeTextBox";
      this.endtimeTextBox.Size = new System.Drawing.Size(249, 22);
      this.endtimeTextBox.TabIndex = 6;
      // 
      // groupBox1
      // 
      this.groupBox1.Controls.Add(this.label2);
      this.groupBox1.Controls.Add(this.label1);
      this.groupBox1.Controls.Add(this.endtimeTextBox);
      this.groupBox1.Controls.Add(this.startTimeTextBox);
      this.groupBox1.Location = new System.Drawing.Point(16, 29);
      this.groupBox1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
      this.groupBox1.Name = "groupBox1";
      this.groupBox1.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
      this.groupBox1.Size = new System.Drawing.Size(267, 135);
      this.groupBox1.TabIndex = 7;
      this.groupBox1.TabStop = false;
      this.groupBox1.Text = "Eventreport time";
      // 
      // label2
      // 
      this.label2.AutoSize = true;
      this.label2.Location = new System.Drawing.Point(8, 76);
      this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
      this.label2.Name = "label2";
      this.label2.Size = new System.Drawing.Size(32, 17);
      this.label2.TabIndex = 8;
      this.label2.Text = "end";
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.Location = new System.Drawing.Point(8, 30);
      this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(36, 17);
      this.label1.TabIndex = 7;
      this.label1.Text = "start";
      // 
      // groupBox2
      // 
      this.groupBox2.Controls.Add(this.countryComboBox);
      this.groupBox2.Controls.Add(this.companyComboBox);
      this.groupBox2.Controls.Add(this.CountryLbl);
      this.groupBox2.Controls.Add(this.label3);
      this.groupBox2.Location = new System.Drawing.Point(16, 214);
      this.groupBox2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
      this.groupBox2.Name = "groupBox2";
      this.groupBox2.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
      this.groupBox2.Size = new System.Drawing.Size(347, 159);
      this.groupBox2.TabIndex = 9;
      this.groupBox2.TabStop = false;
      this.groupBox2.Text = "Customer info";
      // 
      // countryComboBox
      // 
      this.countryComboBox.FormattingEnabled = true;
      this.countryComboBox.Location = new System.Drawing.Point(12, 111);
      this.countryComboBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
      this.countryComboBox.Name = "countryComboBox";
      this.countryComboBox.Size = new System.Drawing.Size(313, 24);
      this.countryComboBox.TabIndex = 13;
      // 
      // companyComboBox
      // 
      this.companyComboBox.FormattingEnabled = true;
      this.companyComboBox.Location = new System.Drawing.Point(12, 54);
      this.companyComboBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
      this.companyComboBox.Name = "companyComboBox";
      this.companyComboBox.Size = new System.Drawing.Size(313, 24);
      this.companyComboBox.TabIndex = 12;
      // 
      // CountryLbl
      // 
      this.CountryLbl.AutoSize = true;
      this.CountryLbl.Location = new System.Drawing.Point(8, 91);
      this.CountryLbl.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
      this.CountryLbl.Name = "CountryLbl";
      this.CountryLbl.Size = new System.Drawing.Size(57, 17);
      this.CountryLbl.TabIndex = 11;
      this.CountryLbl.Text = "Country";
      // 
      // label3
      // 
      this.label3.AutoSize = true;
      this.label3.Location = new System.Drawing.Point(8, 34);
      this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
      this.label3.Name = "label3";
      this.label3.Size = new System.Drawing.Size(67, 17);
      this.label3.TabIndex = 9;
      this.label3.Text = "Company";
      // 
      // MainForm
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(787, 402);
      this.Controls.Add(this.groupBox2);
      this.Controls.Add(this.groupBox1);
      this.Controls.Add(this.detailsLabel);
      this.Controls.Add(this.browseButton);
      this.Controls.Add(this.addToDbButton);
      this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
      this.MaximizeBox = false;
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

