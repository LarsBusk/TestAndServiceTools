namespace GetSI4FI
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
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
      this.loadSysXmlButton = new System.Windows.Forms.Button();
      this.loadCompXmlButton = new System.Windows.Forms.Button();
      this.saveButton = new System.Windows.Forms.Button();
      this.SuspendLayout();
      // 
      // loadSysXmlButton
      // 
      this.loadSysXmlButton.Location = new System.Drawing.Point(36, 28);
      this.loadSysXmlButton.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
      this.loadSysXmlButton.Name = "loadSysXmlButton";
      this.loadSysXmlButton.Size = new System.Drawing.Size(129, 19);
      this.loadSysXmlButton.TabIndex = 0;
      this.loadSysXmlButton.Text = "Load system.xml";
      this.loadSysXmlButton.UseVisualStyleBackColor = true;
      this.loadSysXmlButton.Click += new System.EventHandler(this.loadSysXmlButton_Click);
      // 
      // loadCompXmlButton
      // 
      this.loadCompXmlButton.Location = new System.Drawing.Point(36, 60);
      this.loadCompXmlButton.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
      this.loadCompXmlButton.Name = "loadCompXmlButton";
      this.loadCompXmlButton.Size = new System.Drawing.Size(129, 19);
      this.loadCompXmlButton.TabIndex = 1;
      this.loadCompXmlButton.Text = "Load Component.xml";
      this.loadCompXmlButton.UseVisualStyleBackColor = true;
      this.loadCompXmlButton.Click += new System.EventHandler(this.loadCompXmlButton_Click);
      // 
      // saveButton
      // 
      this.saveButton.Location = new System.Drawing.Point(36, 93);
      this.saveButton.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
      this.saveButton.Name = "saveButton";
      this.saveButton.Size = new System.Drawing.Size(129, 19);
      this.saveButton.TabIndex = 2;
      this.saveButton.Text = "Save S/I to csv";
      this.saveButton.UseVisualStyleBackColor = true;
      this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
      // 
      // Form1
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(250, 177);
      this.Controls.Add(this.saveButton);
      this.Controls.Add(this.loadCompXmlButton);
      this.Controls.Add(this.loadSysXmlButton);
      this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
      this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
      this.Name = "Form1";
      this.Text = "S/I for FI";
      this.ResumeLayout(false);

    }

        #endregion

        private System.Windows.Forms.Button loadSysXmlButton;
        private System.Windows.Forms.Button loadCompXmlButton;
        private System.Windows.Forms.Button saveButton;
    }
}

