namespace FindInFIles
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
      this.FolderButton = new System.Windows.Forms.Button();
      this.label1 = new System.Windows.Forms.Label();
      this.findButton = new System.Windows.Forms.Button();
      this.richTextBoxRes = new System.Windows.Forms.RichTextBox();
      this.statusLabel = new System.Windows.Forms.Label();
      this.searchComboBox = new System.Windows.Forms.ComboBox();
      this.groupBox1 = new System.Windows.Forms.GroupBox();
      this.groupBox2 = new System.Windows.Forms.GroupBox();
      this.findTimeSpanButton = new System.Windows.Forms.Button();
      this.progressBar1 = new System.Windows.Forms.ProgressBar();
      this.groupBox1.SuspendLayout();
      this.groupBox2.SuspendLayout();
      this.SuspendLayout();
      // 
      // FolderButton
      // 
      this.FolderButton.Location = new System.Drawing.Point(702, 403);
      this.FolderButton.Name = "FolderButton";
      this.FolderButton.Size = new System.Drawing.Size(75, 23);
      this.FolderButton.TabIndex = 0;
      this.FolderButton.Text = "Browse";
      this.FolderButton.UseVisualStyleBackColor = true;
      this.FolderButton.Click += new System.EventHandler(this.FolderButton_Click);
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.Location = new System.Drawing.Point(6, 16);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(28, 13);
      this.label1.TabIndex = 2;
      this.label1.Text = "Text";
      // 
      // findButton
      // 
      this.findButton.Location = new System.Drawing.Point(138, 71);
      this.findButton.Name = "findButton";
      this.findButton.Size = new System.Drawing.Size(75, 23);
      this.findButton.TabIndex = 3;
      this.findButton.Text = "Find";
      this.findButton.UseVisualStyleBackColor = true;
      this.findButton.Click += new System.EventHandler(this.findButton_Click);
      // 
      // richTextBoxRes
      // 
      this.richTextBoxRes.Location = new System.Drawing.Point(20, 18);
      this.richTextBoxRes.Name = "richTextBoxRes";
      this.richTextBoxRes.Size = new System.Drawing.Size(502, 407);
      this.richTextBoxRes.TabIndex = 4;
      this.richTextBoxRes.Text = "";
      // 
      // statusLabel
      // 
      this.statusLabel.AutoSize = true;
      this.statusLabel.Location = new System.Drawing.Point(544, 338);
      this.statusLabel.Name = "statusLabel";
      this.statusLabel.Size = new System.Drawing.Size(166, 13);
      this.statusLabel.TabIndex = 5;
      this.statusLabel.Text = "Browse or drop a folder to search.";
      // 
      // searchComboBox
      // 
      this.searchComboBox.FormattingEnabled = true;
      this.searchComboBox.Items.AddRange(new object[] {
            "ERROR",
            "FATAL",
            "build",
            "Exception",
            "Event.EventCode: xx"});
      this.searchComboBox.Location = new System.Drawing.Point(9, 32);
      this.searchComboBox.Name = "searchComboBox";
      this.searchComboBox.Size = new System.Drawing.Size(204, 21);
      this.searchComboBox.TabIndex = 6;
      // 
      // groupBox1
      // 
      this.groupBox1.Controls.Add(this.label1);
      this.groupBox1.Controls.Add(this.searchComboBox);
      this.groupBox1.Controls.Add(this.findButton);
      this.groupBox1.Location = new System.Drawing.Point(547, 18);
      this.groupBox1.Name = "groupBox1";
      this.groupBox1.Size = new System.Drawing.Size(230, 100);
      this.groupBox1.TabIndex = 7;
      this.groupBox1.TabStop = false;
      this.groupBox1.Text = "Find text in files";
      // 
      // groupBox2
      // 
      this.groupBox2.Controls.Add(this.findTimeSpanButton);
      this.groupBox2.Location = new System.Drawing.Point(547, 134);
      this.groupBox2.Name = "groupBox2";
      this.groupBox2.Size = new System.Drawing.Size(230, 76);
      this.groupBox2.TabIndex = 8;
      this.groupBox2.TabStop = false;
      this.groupBox2.Text = "Find timespan";
      // 
      // findTimeSpanButton
      // 
      this.findTimeSpanButton.Location = new System.Drawing.Point(138, 34);
      this.findTimeSpanButton.Name = "findTimeSpanButton";
      this.findTimeSpanButton.Size = new System.Drawing.Size(75, 23);
      this.findTimeSpanButton.TabIndex = 0;
      this.findTimeSpanButton.Text = "FindGreatets";
      this.findTimeSpanButton.UseVisualStyleBackColor = true;
      this.findTimeSpanButton.Click += new System.EventHandler(this.findTimeSpanButton_Click);
      // 
      // progressBar1
      // 
      this.progressBar1.Location = new System.Drawing.Point(547, 364);
      this.progressBar1.Name = "progressBar1";
      this.progressBar1.Size = new System.Drawing.Size(230, 18);
      this.progressBar1.TabIndex = 9;
      // 
      // Form1
      // 
      this.AllowDrop = true;
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(800, 450);
      this.Controls.Add(this.progressBar1);
      this.Controls.Add(this.groupBox2);
      this.Controls.Add(this.groupBox1);
      this.Controls.Add(this.statusLabel);
      this.Controls.Add(this.richTextBoxRes);
      this.Controls.Add(this.FolderButton);
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
      this.MaximizeBox = false;
      this.Name = "Form1";
      this.Text = "FindInLogFiles";
      this.DragDrop += new System.Windows.Forms.DragEventHandler(this.Form1_DragDrop);
      this.DragEnter += new System.Windows.Forms.DragEventHandler(this.Form1_DragEnter);
      this.groupBox1.ResumeLayout(false);
      this.groupBox1.PerformLayout();
      this.groupBox2.ResumeLayout(false);
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.Button FolderButton;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.Button findButton;
    private System.Windows.Forms.RichTextBox richTextBoxRes;
    private System.Windows.Forms.Label statusLabel;
    private System.Windows.Forms.ComboBox searchComboBox;
    private System.Windows.Forms.GroupBox groupBox1;
    private System.Windows.Forms.GroupBox groupBox2;
    private System.Windows.Forms.Button findTimeSpanButton;
    private System.Windows.Forms.ProgressBar progressBar1;
  }
}

