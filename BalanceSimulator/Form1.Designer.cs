
namespace BalanceSimulator
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
      this.serialsComboBox = new System.Windows.Forms.ComboBox();
      this.connectButton = new System.Windows.Forms.Button();
      this.disconnectButton = new System.Windows.Forms.Button();
      this.groupBox1 = new System.Windows.Forms.GroupBox();
      this.stateLabel = new System.Windows.Forms.Label();
      this.richTextBox1 = new System.Windows.Forms.RichTextBox();
      this.groupBox1.SuspendLayout();
      this.SuspendLayout();
      // 
      // serialsComboBox
      // 
      this.serialsComboBox.FormattingEnabled = true;
      this.serialsComboBox.Location = new System.Drawing.Point(6, 31);
      this.serialsComboBox.Name = "serialsComboBox";
      this.serialsComboBox.Size = new System.Drawing.Size(121, 21);
      this.serialsComboBox.TabIndex = 0;
      // 
      // connectButton
      // 
      this.connectButton.Location = new System.Drawing.Point(6, 58);
      this.connectButton.Name = "connectButton";
      this.connectButton.Size = new System.Drawing.Size(89, 23);
      this.connectButton.TabIndex = 2;
      this.connectButton.Text = "Connect";
      this.connectButton.UseVisualStyleBackColor = true;
      this.connectButton.Click += new System.EventHandler(this.connectButton_Click);
      // 
      // disconnectButton
      // 
      this.disconnectButton.Location = new System.Drawing.Point(6, 87);
      this.disconnectButton.Name = "disconnectButton";
      this.disconnectButton.Size = new System.Drawing.Size(89, 23);
      this.disconnectButton.TabIndex = 3;
      this.disconnectButton.Text = "Disconnect";
      this.disconnectButton.UseVisualStyleBackColor = true;
      this.disconnectButton.Click += new System.EventHandler(this.disconnectButton_Click);
      // 
      // groupBox1
      // 
      this.groupBox1.Controls.Add(this.stateLabel);
      this.groupBox1.Controls.Add(this.serialsComboBox);
      this.groupBox1.Controls.Add(this.disconnectButton);
      this.groupBox1.Controls.Add(this.connectButton);
      this.groupBox1.Location = new System.Drawing.Point(194, 21);
      this.groupBox1.Name = "groupBox1";
      this.groupBox1.Size = new System.Drawing.Size(153, 147);
      this.groupBox1.TabIndex = 4;
      this.groupBox1.TabStop = false;
      this.groupBox1.Text = "Serialport";
      // 
      // stateLabel
      // 
      this.stateLabel.AutoSize = true;
      this.stateLabel.Location = new System.Drawing.Point(6, 113);
      this.stateLabel.Name = "stateLabel";
      this.stateLabel.Size = new System.Drawing.Size(35, 13);
      this.stateLabel.TabIndex = 4;
      this.stateLabel.Text = "label1";
      // 
      // richTextBox1
      // 
      this.richTextBox1.Location = new System.Drawing.Point(401, 35);
      this.richTextBox1.Name = "richTextBox1";
      this.richTextBox1.Size = new System.Drawing.Size(232, 306);
      this.richTextBox1.TabIndex = 5;
      this.richTextBox1.Text = "";
      // 
      // Form1
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(660, 412);
      this.Controls.Add(this.richTextBox1);
      this.Controls.Add(this.groupBox1);
      this.Name = "Form1";
      this.Text = "Scale simulator";
      this.Load += new System.EventHandler(this.Form1_Load);
      this.groupBox1.ResumeLayout(false);
      this.groupBox1.PerformLayout();
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.ComboBox serialsComboBox;
    private System.Windows.Forms.Button connectButton;
    private System.Windows.Forms.Button disconnectButton;
    private System.Windows.Forms.GroupBox groupBox1;
    private System.Windows.Forms.Label stateLabel;
    private System.Windows.Forms.RichTextBox richTextBox1;
  }
}

