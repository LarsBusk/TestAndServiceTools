// $Header: $ 
// Copyright (c) CODE Consulting and Development, s.r.o., Plzen. All rights reserved.

using JetBrains.Annotations;

namespace EasyOpcUADemo
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
      this.valueTextBox = new System.Windows.Forms.TextBox();
      this.subscribeMonitoredItemButton = new System.Windows.Forms.Button();
      this.statusTextBox = new System.Windows.Forms.TextBox();
      this.serverTimestampTextBox = new System.Windows.Forms.TextBox();
      this.label1 = new System.Windows.Forms.Label();
      this.label2 = new System.Windows.Forms.Label();
      this.label3 = new System.Windows.Forms.Label();
      this.exceptionTextBox = new System.Windows.Forms.TextBox();
      this.label4 = new System.Windows.Forms.Label();
      this.serverUriTextBox = new System.Windows.Forms.TextBox();
      this.label7 = new System.Windows.Forms.Label();
      this.nodeIdTextBox = new System.Windows.Forms.TextBox();
      this.label8 = new System.Windows.Forms.Label();
      this.readButton = new System.Windows.Forms.Button();
      this.closeButton = new System.Windows.Forms.Button();
      this.panel1 = new System.Windows.Forms.Panel();
      this.sourceTimestampTextBox = new System.Windows.Forms.TextBox();
      this.label5 = new System.Windows.Forms.Label();
      this.valueToWriteTextBox = new System.Windows.Forms.TextBox();
      this.label6 = new System.Windows.Forms.Label();
      this.writeValueButton = new System.Windows.Forms.Button();
      this.connectButton = new System.Windows.Forms.Button();
      this.groupTextbox = new System.Windows.Forms.TextBox();
      this.label11 = new System.Windows.Forms.Label();
      this.subscribeResultsButton = new System.Windows.Forms.Button();
      this.unsubscribeButton = new System.Windows.Forms.Button();
      this.groupBox1 = new System.Windows.Forms.GroupBox();
      this.groupBox1.SuspendLayout();
      this.SuspendLayout();
      // 
      // valueTextBox
      // 
      this.valueTextBox.Location = new System.Drawing.Point(109, 19);
      this.valueTextBox.Name = "valueTextBox";
      this.valueTextBox.ReadOnly = true;
      this.valueTextBox.Size = new System.Drawing.Size(176, 20);
      this.valueTextBox.TabIndex = 0;
      // 
      // subscribeMonitoredItemButton
      // 
      this.subscribeMonitoredItemButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.subscribeMonitoredItemButton.Location = new System.Drawing.Point(178, 159);
      this.subscribeMonitoredItemButton.Name = "subscribeMonitoredItemButton";
      this.subscribeMonitoredItemButton.Size = new System.Drawing.Size(107, 23);
      this.subscribeMonitoredItemButton.TabIndex = 1;
      this.subscribeMonitoredItemButton.Text = "Su&bscribe";
      this.subscribeMonitoredItemButton.UseVisualStyleBackColor = true;
      this.subscribeMonitoredItemButton.Click += new System.EventHandler(this.subscribeButton_Click);
      // 
      // statusTextBox
      // 
      this.statusTextBox.Location = new System.Drawing.Point(109, 46);
      this.statusTextBox.Name = "statusTextBox";
      this.statusTextBox.ReadOnly = true;
      this.statusTextBox.Size = new System.Drawing.Size(176, 20);
      this.statusTextBox.TabIndex = 2;
      // 
      // serverTimestampTextBox
      // 
      this.serverTimestampTextBox.Location = new System.Drawing.Point(109, 104);
      this.serverTimestampTextBox.Name = "serverTimestampTextBox";
      this.serverTimestampTextBox.ReadOnly = true;
      this.serverTimestampTextBox.Size = new System.Drawing.Size(176, 20);
      this.serverTimestampTextBox.TabIndex = 3;
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.Location = new System.Drawing.Point(66, 22);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(37, 13);
      this.label1.TabIndex = 4;
      this.label1.Text = "Value:";
      // 
      // label2
      // 
      this.label2.AutoSize = true;
      this.label2.Location = new System.Drawing.Point(12, 107);
      this.label2.Name = "label2";
      this.label2.Size = new System.Drawing.Size(91, 13);
      this.label2.TabIndex = 5;
      this.label2.Text = "Server timestamp:";
      // 
      // label3
      // 
      this.label3.AutoSize = true;
      this.label3.Location = new System.Drawing.Point(63, 48);
      this.label3.Name = "label3";
      this.label3.Size = new System.Drawing.Size(40, 13);
      this.label3.TabIndex = 6;
      this.label3.Text = "Status:";
      // 
      // exceptionTextBox
      // 
      this.exceptionTextBox.Location = new System.Drawing.Point(4, 468);
      this.exceptionTextBox.Multiline = true;
      this.exceptionTextBox.Name = "exceptionTextBox";
      this.exceptionTextBox.ReadOnly = true;
      this.exceptionTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
      this.exceptionTextBox.Size = new System.Drawing.Size(755, 133);
      this.exceptionTextBox.TabIndex = 7;
      // 
      // label4
      // 
      this.label4.AutoSize = true;
      this.label4.Location = new System.Drawing.Point(12, 442);
      this.label4.Name = "label4";
      this.label4.Size = new System.Drawing.Size(57, 13);
      this.label4.TabIndex = 8;
      this.label4.Text = "Exception:";
      // 
      // serverUriTextBox
      // 
      this.serverUriTextBox.Location = new System.Drawing.Point(72, 44);
      this.serverUriTextBox.Name = "serverUriTextBox";
      this.serverUriTextBox.Size = new System.Drawing.Size(264, 20);
      this.serverUriTextBox.TabIndex = 14;
      this.serverUriTextBox.Text = "opc.tcp://Angus-TestFest:49320";
      // 
      // label7
      // 
      this.label7.AutoSize = true;
      this.label7.Location = new System.Drawing.Point(9, 47);
      this.label7.Name = "label7";
      this.label7.Size = new System.Drawing.Size(57, 13);
      this.label7.TabIndex = 15;
      this.label7.Text = "Server &Uri:";
      // 
      // nodeIdTextBox
      // 
      this.nodeIdTextBox.Location = new System.Drawing.Point(72, 73);
      this.nodeIdTextBox.Name = "nodeIdTextBox";
      this.nodeIdTextBox.Size = new System.Drawing.Size(264, 20);
      this.nodeIdTextBox.TabIndex = 17;
      this.nodeIdTextBox.Text = "ns=2;s=MMII.PDx.Instrument.WatchdogCounter";
      // 
      // label8
      // 
      this.label8.AutoSize = true;
      this.label8.Location = new System.Drawing.Point(11, 76);
      this.label8.Name = "label8";
      this.label8.Size = new System.Drawing.Size(48, 13);
      this.label8.TabIndex = 19;
      this.label8.Text = "Node &Id:";
      // 
      // readButton
      // 
      this.readButton.Location = new System.Drawing.Point(178, 130);
      this.readButton.Name = "readButton";
      this.readButton.Size = new System.Drawing.Size(107, 23);
      this.readButton.TabIndex = 22;
      this.readButton.Text = "&Read";
      this.readButton.UseVisualStyleBackColor = true;
      this.readButton.Click += new System.EventHandler(this.readButton_Click);
      // 
      // closeButton
      // 
      this.closeButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
      this.closeButton.Location = new System.Drawing.Point(685, 70);
      this.closeButton.Name = "closeButton";
      this.closeButton.Size = new System.Drawing.Size(75, 23);
      this.closeButton.TabIndex = 35;
      this.closeButton.Text = "Close";
      this.closeButton.UseVisualStyleBackColor = true;
      this.closeButton.Click += new System.EventHandler(this.closeButton_Click);
      // 
      // panel1
      // 
      this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      this.panel1.Location = new System.Drawing.Point(5, 32);
      this.panel1.Name = "panel1";
      this.panel1.Size = new System.Drawing.Size(754, 1);
      this.panel1.TabIndex = 36;
      // 
      // sourceTimestampTextBox
      // 
      this.sourceTimestampTextBox.Location = new System.Drawing.Point(109, 74);
      this.sourceTimestampTextBox.Name = "sourceTimestampTextBox";
      this.sourceTimestampTextBox.ReadOnly = true;
      this.sourceTimestampTextBox.Size = new System.Drawing.Size(176, 20);
      this.sourceTimestampTextBox.TabIndex = 3;
      // 
      // label5
      // 
      this.label5.AutoSize = true;
      this.label5.Location = new System.Drawing.Point(9, 77);
      this.label5.Name = "label5";
      this.label5.Size = new System.Drawing.Size(94, 13);
      this.label5.TabIndex = 5;
      this.label5.Text = "Source timestamp:";
      // 
      // valueToWriteTextBox
      // 
      this.valueToWriteTextBox.Location = new System.Drawing.Point(460, 115);
      this.valueToWriteTextBox.Name = "valueToWriteTextBox";
      this.valueToWriteTextBox.Size = new System.Drawing.Size(176, 20);
      this.valueToWriteTextBox.TabIndex = 0;
      // 
      // label6
      // 
      this.label6.AutoSize = true;
      this.label6.Location = new System.Drawing.Point(380, 117);
      this.label6.Name = "label6";
      this.label6.Size = new System.Drawing.Size(74, 13);
      this.label6.TabIndex = 4;
      this.label6.Text = "Value to write:";
      // 
      // writeValueButton
      // 
      this.writeValueButton.Location = new System.Drawing.Point(641, 113);
      this.writeValueButton.Name = "writeValueButton";
      this.writeValueButton.Size = new System.Drawing.Size(118, 23);
      this.writeValueButton.TabIndex = 22;
      this.writeValueButton.Text = "&Write value";
      this.writeValueButton.UseVisualStyleBackColor = true;
      this.writeValueButton.Click += new System.EventHandler(this.writeValueButton_Click);
      // 
      // connectButton
      // 
      this.connectButton.Location = new System.Drawing.Point(347, 44);
      this.connectButton.Margin = new System.Windows.Forms.Padding(2);
      this.connectButton.Name = "connectButton";
      this.connectButton.Size = new System.Drawing.Size(107, 20);
      this.connectButton.TabIndex = 39;
      this.connectButton.Text = "Connect";
      this.connectButton.UseVisualStyleBackColor = true;
      this.connectButton.Click += new System.EventHandler(this.connectButton_Click);
      // 
      // groupTextbox
      // 
      this.groupTextbox.Location = new System.Drawing.Point(72, 97);
      this.groupTextbox.Margin = new System.Windows.Forms.Padding(2);
      this.groupTextbox.Name = "groupTextbox";
      this.groupTextbox.Size = new System.Drawing.Size(92, 20);
      this.groupTextbox.TabIndex = 41;
      this.groupTextbox.Text = "MMII.PDx";
      // 
      // label11
      // 
      this.label11.AutoSize = true;
      this.label11.Location = new System.Drawing.Point(9, 97);
      this.label11.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
      this.label11.Name = "label11";
      this.label11.Size = new System.Drawing.Size(36, 13);
      this.label11.TabIndex = 42;
      this.label11.Text = "Group";
      // 
      // subscribeResultsButton
      // 
      this.subscribeResultsButton.Location = new System.Drawing.Point(458, 47);
      this.subscribeResultsButton.Margin = new System.Windows.Forms.Padding(2);
      this.subscribeResultsButton.Name = "subscribeResultsButton";
      this.subscribeResultsButton.Size = new System.Drawing.Size(115, 26);
      this.subscribeResultsButton.TabIndex = 43;
      this.subscribeResultsButton.Text = "Subscribe Results";
      this.subscribeResultsButton.UseVisualStyleBackColor = true;
      this.subscribeResultsButton.Click += new System.EventHandler(this.subscribeResultsButton_Click);
      // 
      // unsubscribeButton
      // 
      this.unsubscribeButton.Location = new System.Drawing.Point(479, 77);
      this.unsubscribeButton.Margin = new System.Windows.Forms.Padding(2);
      this.unsubscribeButton.Name = "unsubscribeButton";
      this.unsubscribeButton.Size = new System.Drawing.Size(115, 22);
      this.unsubscribeButton.TabIndex = 44;
      this.unsubscribeButton.Text = "Unsubscribe";
      this.unsubscribeButton.UseVisualStyleBackColor = true;
      this.unsubscribeButton.Click += new System.EventHandler(this.unsubscribeButton_Click);
      // 
      // groupBox1
      // 
      this.groupBox1.Controls.Add(this.sourceTimestampTextBox);
      this.groupBox1.Controls.Add(this.valueTextBox);
      this.groupBox1.Controls.Add(this.statusTextBox);
      this.groupBox1.Controls.Add(this.serverTimestampTextBox);
      this.groupBox1.Controls.Add(this.label1);
      this.groupBox1.Controls.Add(this.label2);
      this.groupBox1.Controls.Add(this.label5);
      this.groupBox1.Controls.Add(this.label3);
      this.groupBox1.Controls.Add(this.subscribeMonitoredItemButton);
      this.groupBox1.Controls.Add(this.readButton);
      this.groupBox1.Location = new System.Drawing.Point(6, 147);
      this.groupBox1.Name = "groupBox1";
      this.groupBox1.Size = new System.Drawing.Size(309, 201);
      this.groupBox1.TabIndex = 45;
      this.groupBox1.TabStop = false;
      this.groupBox1.Text = "Single result";
      // 
      // MainForm
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.CancelButton = this.closeButton;
      this.ClientSize = new System.Drawing.Size(770, 638);
      this.Controls.Add(this.groupBox1);
      this.Controls.Add(this.unsubscribeButton);
      this.Controls.Add(this.subscribeResultsButton);
      this.Controls.Add(this.label11);
      this.Controls.Add(this.groupTextbox);
      this.Controls.Add(this.connectButton);
      this.Controls.Add(this.panel1);
      this.Controls.Add(this.closeButton);
      this.Controls.Add(this.writeValueButton);
      this.Controls.Add(this.label8);
      this.Controls.Add(this.nodeIdTextBox);
      this.Controls.Add(this.label7);
      this.Controls.Add(this.serverUriTextBox);
      this.Controls.Add(this.label4);
      this.Controls.Add(this.exceptionTextBox);
      this.Controls.Add(this.label6);
      this.Controls.Add(this.valueToWriteTextBox);
      this.MaximizeBox = false;
      this.Name = "MainForm";
      this.Text = "MeatMasterII OPC-UA Test client";
      this.groupBox1.ResumeLayout(false);
      this.groupBox1.PerformLayout();
      this.ResumeLayout(false);
      this.PerformLayout();

        }

        #endregion
        [NotNull]
        private System.Windows.Forms.TextBox valueTextBox;
        [NotNull]
        private System.Windows.Forms.Button subscribeMonitoredItemButton;
        [NotNull]
        private System.Windows.Forms.TextBox statusTextBox;
        [NotNull]
        private System.Windows.Forms.TextBox serverTimestampTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        [NotNull]
        private System.Windows.Forms.TextBox exceptionTextBox;
        private System.Windows.Forms.Label label4;
        [NotNull]
        private System.Windows.Forms.TextBox serverUriTextBox;
        private System.Windows.Forms.Label label7;
        [NotNull]
        private System.Windows.Forms.TextBox nodeIdTextBox;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button readButton;
        private System.Windows.Forms.Button closeButton;
        private System.Windows.Forms.Panel panel1;
        [NotNull]
        private System.Windows.Forms.TextBox sourceTimestampTextBox;
        private System.Windows.Forms.Label label5;
        [NotNull] private System.Windows.Forms.TextBox valueToWriteTextBox;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button writeValueButton;
    private System.Windows.Forms.Button connectButton;
    private System.Windows.Forms.TextBox groupTextbox;
    private System.Windows.Forms.Label label11;
    private System.Windows.Forms.Button subscribeResultsButton;
    private System.Windows.Forms.Button unsubscribeButton;
    private System.Windows.Forms.GroupBox groupBox1;
  }
}

