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
      this.searchTextBox = new System.Windows.Forms.TextBox();
      this.label1 = new System.Windows.Forms.Label();
      this.findButton = new System.Windows.Forms.Button();
      this.richTextBoxRes = new System.Windows.Forms.RichTextBox();
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
      // searchTextBox
      // 
      this.searchTextBox.Location = new System.Drawing.Point(563, 98);
      this.searchTextBox.Name = "searchTextBox";
      this.searchTextBox.Size = new System.Drawing.Size(214, 20);
      this.searchTextBox.TabIndex = 1;
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.Location = new System.Drawing.Point(560, 82);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(28, 13);
      this.label1.TabIndex = 2;
      this.label1.Text = "FInd";
      // 
      // findButton
      // 
      this.findButton.Enabled = false;
      this.findButton.Location = new System.Drawing.Point(702, 374);
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
      // Form1
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(800, 450);
      this.Controls.Add(this.richTextBoxRes);
      this.Controls.Add(this.findButton);
      this.Controls.Add(this.label1);
      this.Controls.Add(this.searchTextBox);
      this.Controls.Add(this.FolderButton);
      this.Name = "Form1";
      this.Text = "Form1";
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.Button FolderButton;
    private System.Windows.Forms.TextBox searchTextBox;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.Button findButton;
    private System.Windows.Forms.RichTextBox richTextBoxRes;
  }
}

