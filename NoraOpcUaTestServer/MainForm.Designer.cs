﻿
namespace NoraOpcUaTestServer
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
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
      this.groupBox1 = new System.Windows.Forms.GroupBox();
      this.serverStateLabel = new System.Windows.Forms.Label();
      this.heartBeatLabel = new System.Windows.Forms.Label();
      this.label1 = new System.Windows.Forms.Label();
      this.stopButton = new System.Windows.Forms.Button();
      this.startButton = new System.Windows.Forms.Button();
      this.richTextBox1 = new System.Windows.Forms.RichTextBox();
      this.button1 = new System.Windows.Forms.Button();
      this.fatLabel = new System.Windows.Forms.Label();
      this.groupBox2 = new System.Windows.Forms.GroupBox();
      this.cleanButton = new System.Windows.Forms.Button();
      this.zeroButton = new System.Windows.Forms.Button();
      this.cipButton = new System.Windows.Forms.Button();
      this.startStopButton = new System.Windows.Forms.Button();
      this.productTextBox = new System.Windows.Forms.TextBox();
      this.productLabel = new System.Windows.Forms.Label();
      this.menuStrip1 = new System.Windows.Forms.MenuStrip();
      this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.settingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.settingsToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
      this.stateLabel = new System.Windows.Forms.Label();
      this.label2 = new System.Windows.Forms.Label();
      this.groupBox1.SuspendLayout();
      this.groupBox2.SuspendLayout();
      this.menuStrip1.SuspendLayout();
      this.SuspendLayout();
      // 
      // groupBox1
      // 
      this.groupBox1.Controls.Add(this.serverStateLabel);
      this.groupBox1.Controls.Add(this.heartBeatLabel);
      this.groupBox1.Controls.Add(this.label1);
      this.groupBox1.Controls.Add(this.stopButton);
      this.groupBox1.Controls.Add(this.startButton);
      this.groupBox1.Location = new System.Drawing.Point(43, 219);
      this.groupBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
      this.groupBox1.Name = "groupBox1";
      this.groupBox1.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
      this.groupBox1.Size = new System.Drawing.Size(141, 182);
      this.groupBox1.TabIndex = 0;
      this.groupBox1.TabStop = false;
      this.groupBox1.Text = "OPC Server";
      // 
      // serverStateLabel
      // 
      this.serverStateLabel.AutoSize = true;
      this.serverStateLabel.Location = new System.Drawing.Point(19, 22);
      this.serverStateLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
      this.serverStateLabel.Name = "serverStateLabel";
      this.serverStateLabel.Size = new System.Drawing.Size(61, 17);
      this.serverStateLabel.TabIndex = 5;
      this.serverStateLabel.Text = "Stopped";
      // 
      // heartBeatLabel
      // 
      this.heartBeatLabel.AutoSize = true;
      this.heartBeatLabel.Location = new System.Drawing.Point(17, 151);
      this.heartBeatLabel.Name = "heartBeatLabel";
      this.heartBeatLabel.Size = new System.Drawing.Size(0, 17);
      this.heartBeatLabel.TabIndex = 4;
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.Location = new System.Drawing.Point(17, 130);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(72, 17);
      this.label1.TabIndex = 3;
      this.label1.Text = "HeartBeat";
      // 
      // stopButton
      // 
      this.stopButton.Location = new System.Drawing.Point(20, 86);
      this.stopButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
      this.stopButton.Name = "stopButton";
      this.stopButton.Size = new System.Drawing.Size(85, 33);
      this.stopButton.TabIndex = 1;
      this.stopButton.Text = "Stop";
      this.stopButton.UseVisualStyleBackColor = true;
      this.stopButton.Click += new System.EventHandler(this.stopButton_Click);
      // 
      // startButton
      // 
      this.startButton.Location = new System.Drawing.Point(20, 48);
      this.startButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
      this.startButton.Name = "startButton";
      this.startButton.Size = new System.Drawing.Size(85, 33);
      this.startButton.TabIndex = 0;
      this.startButton.Text = "Start";
      this.startButton.UseVisualStyleBackColor = true;
      this.startButton.Click += new System.EventHandler(this.startButton_Click);
      // 
      // richTextBox1
      // 
      this.richTextBox1.Location = new System.Drawing.Point(397, 54);
      this.richTextBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
      this.richTextBox1.Name = "richTextBox1";
      this.richTextBox1.Size = new System.Drawing.Size(353, 283);
      this.richTextBox1.TabIndex = 1;
      this.richTextBox1.Text = "";
      // 
      // button1
      // 
      this.button1.Location = new System.Drawing.Point(657, 350);
      this.button1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
      this.button1.Name = "button1";
      this.button1.Size = new System.Drawing.Size(92, 37);
      this.button1.TabIndex = 2;
      this.button1.Text = "Get nodes";
      this.button1.UseVisualStyleBackColor = true;
      this.button1.Click += new System.EventHandler(this.button1_Click);
      // 
      // fatLabel
      // 
      this.fatLabel.AutoSize = true;
      this.fatLabel.Location = new System.Drawing.Point(59, 69);
      this.fatLabel.Name = "fatLabel";
      this.fatLabel.Size = new System.Drawing.Size(36, 17);
      this.fatLabel.TabIndex = 3;
      this.fatLabel.Text = "Fat: ";
      // 
      // groupBox2
      // 
      this.groupBox2.Controls.Add(this.label2);
      this.groupBox2.Controls.Add(this.cleanButton);
      this.groupBox2.Controls.Add(this.zeroButton);
      this.groupBox2.Controls.Add(this.cipButton);
      this.groupBox2.Controls.Add(this.startStopButton);
      this.groupBox2.Controls.Add(this.productTextBox);
      this.groupBox2.Location = new System.Drawing.Point(211, 147);
      this.groupBox2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
      this.groupBox2.Name = "groupBox2";
      this.groupBox2.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
      this.groupBox2.Size = new System.Drawing.Size(147, 254);
      this.groupBox2.TabIndex = 4;
      this.groupBox2.TabStop = false;
      this.groupBox2.Text = "Nora Control";
      // 
      // cleanButton
      // 
      this.cleanButton.Location = new System.Drawing.Point(5, 201);
      this.cleanButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
      this.cleanButton.Name = "cleanButton";
      this.cleanButton.Size = new System.Drawing.Size(85, 36);
      this.cleanButton.TabIndex = 4;
      this.cleanButton.Text = "Clean";
      this.cleanButton.UseVisualStyleBackColor = true;
      this.cleanButton.Click += new System.EventHandler(this.cleanButton_Click);
      // 
      // zeroButton
      // 
      this.zeroButton.Location = new System.Drawing.Point(5, 161);
      this.zeroButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
      this.zeroButton.Name = "zeroButton";
      this.zeroButton.Size = new System.Drawing.Size(85, 34);
      this.zeroButton.TabIndex = 3;
      this.zeroButton.Text = "Zero";
      this.zeroButton.UseVisualStyleBackColor = true;
      this.zeroButton.Click += new System.EventHandler(this.zeroButton_Click);
      // 
      // cipButton
      // 
      this.cipButton.Location = new System.Drawing.Point(5, 122);
      this.cipButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
      this.cipButton.Name = "cipButton";
      this.cipButton.Size = new System.Drawing.Size(85, 33);
      this.cipButton.TabIndex = 2;
      this.cipButton.Text = "CIP";
      this.cipButton.UseVisualStyleBackColor = true;
      this.cipButton.Click += new System.EventHandler(this.cipButton_Click);
      // 
      // startStopButton
      // 
      this.startStopButton.Location = new System.Drawing.Point(5, 83);
      this.startStopButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
      this.startStopButton.Name = "startStopButton";
      this.startStopButton.Size = new System.Drawing.Size(85, 33);
      this.startStopButton.TabIndex = 1;
      this.startStopButton.Text = "Start";
      this.startStopButton.UseVisualStyleBackColor = true;
      this.startStopButton.Click += new System.EventHandler(this.startStopButton_Click);
      // 
      // productTextBox
      // 
      this.productTextBox.Location = new System.Drawing.Point(5, 49);
      this.productTextBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
      this.productTextBox.Name = "productTextBox";
      this.productTextBox.Size = new System.Drawing.Size(97, 22);
      this.productTextBox.TabIndex = 0;
      this.productTextBox.TextChanged += new System.EventHandler(this.productTextBox_TextChanged);
      // 
      // productLabel
      // 
      this.productLabel.AutoSize = true;
      this.productLabel.Location = new System.Drawing.Point(59, 43);
      this.productLabel.Name = "productLabel";
      this.productLabel.Size = new System.Drawing.Size(61, 17);
      this.productLabel.TabIndex = 6;
      this.productLabel.Text = "Product:";
      // 
      // menuStrip1
      // 
      this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
      this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.settingsToolStripMenuItem});
      this.menuStrip1.Location = new System.Drawing.Point(0, 0);
      this.menuStrip1.Name = "menuStrip1";
      this.menuStrip1.Size = new System.Drawing.Size(800, 28);
      this.menuStrip1.TabIndex = 7;
      this.menuStrip1.Text = "menuStrip1";
      // 
      // fileToolStripMenuItem
      // 
      this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exitToolStripMenuItem});
      this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
      this.fileToolStripMenuItem.Size = new System.Drawing.Size(46, 24);
      this.fileToolStripMenuItem.Text = "File";
      // 
      // exitToolStripMenuItem
      // 
      this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
      this.exitToolStripMenuItem.Size = new System.Drawing.Size(116, 26);
      this.exitToolStripMenuItem.Text = "Exit";
      this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
      // 
      // settingsToolStripMenuItem
      // 
      this.settingsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.settingsToolStripMenuItem1});
      this.settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
      this.settingsToolStripMenuItem.Size = new System.Drawing.Size(93, 24);
      this.settingsToolStripMenuItem.Text = "Opc server";
      // 
      // settingsToolStripMenuItem1
      // 
      this.settingsToolStripMenuItem1.Name = "settingsToolStripMenuItem1";
      this.settingsToolStripMenuItem1.Size = new System.Drawing.Size(145, 26);
      this.settingsToolStripMenuItem1.Text = "Settings";
      this.settingsToolStripMenuItem1.Click += new System.EventHandler(this.settingsToolStripMenuItem1_Click);
      // 
      // stateLabel
      // 
      this.stateLabel.AutoSize = true;
      this.stateLabel.Location = new System.Drawing.Point(59, 100);
      this.stateLabel.Name = "stateLabel";
      this.stateLabel.Size = new System.Drawing.Size(45, 17);
      this.stateLabel.TabIndex = 8;
      this.stateLabel.Text = "State:";
      // 
      // label2
      // 
      this.label2.AutoSize = true;
      this.label2.Location = new System.Drawing.Point(2, 26);
      this.label2.Name = "label2";
      this.label2.Size = new System.Drawing.Size(57, 17);
      this.label2.TabIndex = 5;
      this.label2.Text = "Product";
      // 
      // MainForm
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(800, 450);
      this.Controls.Add(this.stateLabel);
      this.Controls.Add(this.productLabel);
      this.Controls.Add(this.groupBox2);
      this.Controls.Add(this.fatLabel);
      this.Controls.Add(this.button1);
      this.Controls.Add(this.richTextBox1);
      this.Controls.Add(this.groupBox1);
      this.Controls.Add(this.menuStrip1);
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
      this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
      this.MainMenuStrip = this.menuStrip1;
      this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
      this.MaximizeBox = false;
      this.Name = "MainForm";
      this.Text = "Nora Opc UA Client";
      this.groupBox1.ResumeLayout(false);
      this.groupBox1.PerformLayout();
      this.groupBox2.ResumeLayout(false);
      this.groupBox2.PerformLayout();
      this.menuStrip1.ResumeLayout(false);
      this.menuStrip1.PerformLayout();
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.GroupBox groupBox1;
    private System.Windows.Forms.Button stopButton;
    private System.Windows.Forms.Button startButton;
    private System.Windows.Forms.RichTextBox richTextBox1;
    private System.Windows.Forms.Button button1;
    private System.Windows.Forms.Label heartBeatLabel;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.Label fatLabel;
    private System.Windows.Forms.GroupBox groupBox2;
    private System.Windows.Forms.Button startStopButton;
    private System.Windows.Forms.TextBox productTextBox;
    private System.Windows.Forms.Label productLabel;
    private System.Windows.Forms.Button cipButton;
    private System.Windows.Forms.Button zeroButton;
    private System.Windows.Forms.Button cleanButton;
    private System.Windows.Forms.MenuStrip menuStrip1;
    private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem settingsToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem settingsToolStripMenuItem1;
    private System.Windows.Forms.Label serverStateLabel;
    private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
    private System.Windows.Forms.Label stateLabel;
    private System.Windows.Forms.Label label2;
  }
}
