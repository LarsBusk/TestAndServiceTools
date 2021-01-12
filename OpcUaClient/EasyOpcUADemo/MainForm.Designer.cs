// $Header: $ 
// Copyright (c) CODE Consulting and Development, s.r.o., Plzen. All rights reserved.

using JetBrains.Annotations;

namespace OpcUaTestClient
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
      this.groupBox2 = new System.Windows.Forms.GroupBox();
      this.modeLabel = new System.Windows.Forms.Label();
      this.startStopButton = new System.Windows.Forms.Button();
      this.setProductButton = new System.Windows.Forms.Button();
      this.label9 = new System.Windows.Forms.Label();
      this.productCodeTextbox = new System.Windows.Forms.TextBox();
      this.groupBox3 = new System.Windows.Forms.GroupBox();
      this.label10 = new System.Windows.Forms.Label();
      this.samplerateTextbox = new System.Windows.Forms.TextBox();
      this.startButton = new System.Windows.Forms.Button();
      this.groupBox1.SuspendLayout();
      this.groupBox2.SuspendLayout();
      this.groupBox3.SuspendLayout();
      this.SuspendLayout();
      // 
      // valueTextBox
      // 
      this.valueTextBox.Location = new System.Drawing.Point(221, 61);
      this.valueTextBox.Margin = new System.Windows.Forms.Padding(4);
      this.valueTextBox.Name = "valueTextBox";
      this.valueTextBox.ReadOnly = true;
      this.valueTextBox.Size = new System.Drawing.Size(233, 22);
      this.valueTextBox.TabIndex = 0;
      // 
      // subscribeMonitoredItemButton
      // 
      this.subscribeMonitoredItemButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.subscribeMonitoredItemButton.Location = new System.Drawing.Point(313, 234);
      this.subscribeMonitoredItemButton.Margin = new System.Windows.Forms.Padding(4);
      this.subscribeMonitoredItemButton.Name = "subscribeMonitoredItemButton";
      this.subscribeMonitoredItemButton.Size = new System.Drawing.Size(143, 28);
      this.subscribeMonitoredItemButton.TabIndex = 1;
      this.subscribeMonitoredItemButton.Text = "Su&bscribe";
      this.subscribeMonitoredItemButton.UseVisualStyleBackColor = true;
      this.subscribeMonitoredItemButton.Click += new System.EventHandler(this.subscribeButton_Click);
      // 
      // statusTextBox
      // 
      this.statusTextBox.Location = new System.Drawing.Point(221, 95);
      this.statusTextBox.Margin = new System.Windows.Forms.Padding(4);
      this.statusTextBox.Name = "statusTextBox";
      this.statusTextBox.ReadOnly = true;
      this.statusTextBox.Size = new System.Drawing.Size(233, 22);
      this.statusTextBox.TabIndex = 2;
      // 
      // serverTimestampTextBox
      // 
      this.serverTimestampTextBox.Location = new System.Drawing.Point(221, 166);
      this.serverTimestampTextBox.Margin = new System.Windows.Forms.Padding(4);
      this.serverTimestampTextBox.Name = "serverTimestampTextBox";
      this.serverTimestampTextBox.ReadOnly = true;
      this.serverTimestampTextBox.Size = new System.Drawing.Size(233, 22);
      this.serverTimestampTextBox.TabIndex = 3;
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.Location = new System.Drawing.Point(164, 65);
      this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(48, 17);
      this.label1.TabIndex = 4;
      this.label1.Text = "Value:";
      // 
      // label2
      // 
      this.label2.AutoSize = true;
      this.label2.Location = new System.Drawing.Point(92, 170);
      this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
      this.label2.Name = "label2";
      this.label2.Size = new System.Drawing.Size(122, 17);
      this.label2.TabIndex = 5;
      this.label2.Text = "Server timestamp:";
      // 
      // label3
      // 
      this.label3.AutoSize = true;
      this.label3.Location = new System.Drawing.Point(160, 97);
      this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
      this.label3.Name = "label3";
      this.label3.Size = new System.Drawing.Size(52, 17);
      this.label3.TabIndex = 6;
      this.label3.Text = "Status:";
      // 
      // exceptionTextBox
      // 
      this.exceptionTextBox.Location = new System.Drawing.Point(5, 576);
      this.exceptionTextBox.Margin = new System.Windows.Forms.Padding(4);
      this.exceptionTextBox.Multiline = true;
      this.exceptionTextBox.Name = "exceptionTextBox";
      this.exceptionTextBox.ReadOnly = true;
      this.exceptionTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
      this.exceptionTextBox.Size = new System.Drawing.Size(1005, 163);
      this.exceptionTextBox.TabIndex = 7;
      // 
      // label4
      // 
      this.label4.AutoSize = true;
      this.label4.Location = new System.Drawing.Point(16, 544);
      this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
      this.label4.Name = "label4";
      this.label4.Size = new System.Drawing.Size(73, 17);
      this.label4.TabIndex = 8;
      this.label4.Text = "Exception:";
      // 
      // serverUriTextBox
      // 
      this.serverUriTextBox.Location = new System.Drawing.Point(98, 21);
      this.serverUriTextBox.Margin = new System.Windows.Forms.Padding(4);
      this.serverUriTextBox.Name = "serverUriTextBox";
      this.serverUriTextBox.Size = new System.Drawing.Size(351, 22);
      this.serverUriTextBox.TabIndex = 14;
      this.serverUriTextBox.Text = "opc.tcp://Angus-TestFest:49320";
      // 
      // label7
      // 
      this.label7.AutoSize = true;
      this.label7.Location = new System.Drawing.Point(14, 25);
      this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
      this.label7.Name = "label7";
      this.label7.Size = new System.Drawing.Size(76, 17);
      this.label7.TabIndex = 15;
      this.label7.Text = "Server &Uri:";
      // 
      // nodeIdTextBox
      // 
      this.nodeIdTextBox.Location = new System.Drawing.Point(103, 23);
      this.nodeIdTextBox.Margin = new System.Windows.Forms.Padding(4);
      this.nodeIdTextBox.Name = "nodeIdTextBox";
      this.nodeIdTextBox.Size = new System.Drawing.Size(351, 22);
      this.nodeIdTextBox.TabIndex = 17;
      this.nodeIdTextBox.Text = "ns=2;s=MMII.PDx.Instrument.WatchdogCounter";
      // 
      // label8
      // 
      this.label8.AutoSize = true;
      this.label8.Location = new System.Drawing.Point(22, 27);
      this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
      this.label8.Name = "label8";
      this.label8.Size = new System.Drawing.Size(61, 17);
      this.label8.TabIndex = 19;
      this.label8.Text = "Node &Id:";
      // 
      // readButton
      // 
      this.readButton.Location = new System.Drawing.Point(313, 198);
      this.readButton.Margin = new System.Windows.Forms.Padding(4);
      this.readButton.Name = "readButton";
      this.readButton.Size = new System.Drawing.Size(143, 28);
      this.readButton.TabIndex = 22;
      this.readButton.Text = "&Read";
      this.readButton.UseVisualStyleBackColor = true;
      this.readButton.Click += new System.EventHandler(this.readButton_Click);
      // 
      // closeButton
      // 
      this.closeButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
      this.closeButton.Location = new System.Drawing.Point(913, 86);
      this.closeButton.Margin = new System.Windows.Forms.Padding(4);
      this.closeButton.Name = "closeButton";
      this.closeButton.Size = new System.Drawing.Size(100, 28);
      this.closeButton.TabIndex = 35;
      this.closeButton.Text = "Close";
      this.closeButton.UseVisualStyleBackColor = true;
      this.closeButton.Click += new System.EventHandler(this.closeButton_Click);
      // 
      // panel1
      // 
      this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      this.panel1.Location = new System.Drawing.Point(7, 39);
      this.panel1.Margin = new System.Windows.Forms.Padding(4);
      this.panel1.Name = "panel1";
      this.panel1.Size = new System.Drawing.Size(1005, 1);
      this.panel1.TabIndex = 36;
      // 
      // sourceTimestampTextBox
      // 
      this.sourceTimestampTextBox.Location = new System.Drawing.Point(221, 129);
      this.sourceTimestampTextBox.Margin = new System.Windows.Forms.Padding(4);
      this.sourceTimestampTextBox.Name = "sourceTimestampTextBox";
      this.sourceTimestampTextBox.ReadOnly = true;
      this.sourceTimestampTextBox.Size = new System.Drawing.Size(233, 22);
      this.sourceTimestampTextBox.TabIndex = 3;
      // 
      // label5
      // 
      this.label5.AutoSize = true;
      this.label5.Location = new System.Drawing.Point(88, 133);
      this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
      this.label5.Name = "label5";
      this.label5.Size = new System.Drawing.Size(125, 17);
      this.label5.TabIndex = 5;
      this.label5.Text = "Source timestamp:";
      // 
      // valueToWriteTextBox
      // 
      this.valueToWriteTextBox.Location = new System.Drawing.Point(613, 142);
      this.valueToWriteTextBox.Margin = new System.Windows.Forms.Padding(4);
      this.valueToWriteTextBox.Name = "valueToWriteTextBox";
      this.valueToWriteTextBox.Size = new System.Drawing.Size(233, 22);
      this.valueToWriteTextBox.TabIndex = 0;
      // 
      // label6
      // 
      this.label6.AutoSize = true;
      this.label6.Location = new System.Drawing.Point(507, 144);
      this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
      this.label6.Name = "label6";
      this.label6.Size = new System.Drawing.Size(97, 17);
      this.label6.TabIndex = 4;
      this.label6.Text = "Value to write:";
      // 
      // writeValueButton
      // 
      this.writeValueButton.Location = new System.Drawing.Point(855, 139);
      this.writeValueButton.Margin = new System.Windows.Forms.Padding(4);
      this.writeValueButton.Name = "writeValueButton";
      this.writeValueButton.Size = new System.Drawing.Size(157, 28);
      this.writeValueButton.TabIndex = 22;
      this.writeValueButton.Text = "&Write value";
      this.writeValueButton.UseVisualStyleBackColor = true;
      this.writeValueButton.Click += new System.EventHandler(this.writeValueButton_Click);
      // 
      // connectButton
      // 
      this.connectButton.Location = new System.Drawing.Point(306, 50);
      this.connectButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
      this.connectButton.Name = "connectButton";
      this.connectButton.Size = new System.Drawing.Size(143, 25);
      this.connectButton.TabIndex = 39;
      this.connectButton.Text = "Connect";
      this.connectButton.UseVisualStyleBackColor = true;
      this.connectButton.Click += new System.EventHandler(this.connectButton_Click);
      // 
      // groupTextbox
      // 
      this.groupTextbox.Location = new System.Drawing.Point(101, 50);
      this.groupTextbox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
      this.groupTextbox.Name = "groupTextbox";
      this.groupTextbox.Size = new System.Drawing.Size(121, 22);
      this.groupTextbox.TabIndex = 41;
      this.groupTextbox.Text = "MMII.PDx";
      // 
      // label11
      // 
      this.label11.AutoSize = true;
      this.label11.Location = new System.Drawing.Point(17, 50);
      this.label11.Name = "label11";
      this.label11.Size = new System.Drawing.Size(48, 17);
      this.label11.TabIndex = 42;
      this.label11.Text = "Group";
      // 
      // subscribeResultsButton
      // 
      this.subscribeResultsButton.Location = new System.Drawing.Point(306, 82);
      this.subscribeResultsButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
      this.subscribeResultsButton.Name = "subscribeResultsButton";
      this.subscribeResultsButton.Size = new System.Drawing.Size(143, 25);
      this.subscribeResultsButton.TabIndex = 43;
      this.subscribeResultsButton.Text = "Subscribe Results";
      this.subscribeResultsButton.UseVisualStyleBackColor = true;
      this.subscribeResultsButton.Click += new System.EventHandler(this.subscribeResultsButton_Click);
      // 
      // unsubscribeButton
      // 
      this.unsubscribeButton.Location = new System.Drawing.Point(306, 120);
      this.unsubscribeButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
      this.unsubscribeButton.Name = "unsubscribeButton";
      this.unsubscribeButton.Size = new System.Drawing.Size(143, 27);
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
      this.groupBox1.Controls.Add(this.nodeIdTextBox);
      this.groupBox1.Controls.Add(this.label8);
      this.groupBox1.Controls.Add(this.label3);
      this.groupBox1.Controls.Add(this.subscribeMonitoredItemButton);
      this.groupBox1.Controls.Add(this.readButton);
      this.groupBox1.Location = new System.Drawing.Point(13, 241);
      this.groupBox1.Margin = new System.Windows.Forms.Padding(4);
      this.groupBox1.Name = "groupBox1";
      this.groupBox1.Padding = new System.Windows.Forms.Padding(4);
      this.groupBox1.Size = new System.Drawing.Size(473, 281);
      this.groupBox1.TabIndex = 45;
      this.groupBox1.TabStop = false;
      this.groupBox1.Text = "Single result";
      // 
      // groupBox2
      // 
      this.groupBox2.Controls.Add(this.modeLabel);
      this.groupBox2.Controls.Add(this.startStopButton);
      this.groupBox2.Controls.Add(this.setProductButton);
      this.groupBox2.Controls.Add(this.label9);
      this.groupBox2.Controls.Add(this.productCodeTextbox);
      this.groupBox2.Location = new System.Drawing.Point(510, 275);
      this.groupBox2.Margin = new System.Windows.Forms.Padding(4);
      this.groupBox2.Name = "groupBox2";
      this.groupBox2.Padding = new System.Windows.Forms.Padding(4);
      this.groupBox2.Size = new System.Drawing.Size(447, 247);
      this.groupBox2.TabIndex = 46;
      this.groupBox2.TabStop = false;
      this.groupBox2.Text = "Control";
      // 
      // modeLabel
      // 
      this.modeLabel.AutoSize = true;
      this.modeLabel.Location = new System.Drawing.Point(72, 122);
      this.modeLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
      this.modeLabel.Name = "modeLabel";
      this.modeLabel.Size = new System.Drawing.Size(51, 17);
      this.modeLabel.TabIndex = 4;
      this.modeLabel.Text = "Mode: ";
      // 
      // startStopButton
      // 
      this.startStopButton.Location = new System.Drawing.Point(304, 82);
      this.startStopButton.Margin = new System.Windows.Forms.Padding(4);
      this.startStopButton.Name = "startStopButton";
      this.startStopButton.Size = new System.Drawing.Size(100, 28);
      this.startStopButton.TabIndex = 3;
      this.startStopButton.Text = "Start";
      this.startStopButton.UseVisualStyleBackColor = true;
      this.startStopButton.Click += new System.EventHandler(this.startStopButton_Click);
      // 
      // setProductButton
      // 
      this.setProductButton.Location = new System.Drawing.Point(304, 39);
      this.setProductButton.Margin = new System.Windows.Forms.Padding(4);
      this.setProductButton.Name = "setProductButton";
      this.setProductButton.Size = new System.Drawing.Size(100, 28);
      this.setProductButton.TabIndex = 2;
      this.setProductButton.Text = "Set";
      this.setProductButton.UseVisualStyleBackColor = true;
      // 
      // label9
      // 
      this.label9.AutoSize = true;
      this.label9.Location = new System.Drawing.Point(68, 20);
      this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
      this.label9.Name = "label9";
      this.label9.Size = new System.Drawing.Size(98, 17);
      this.label9.TabIndex = 1;
      this.label9.Text = "ProductcodeN";
      // 
      // productCodeTextbox
      // 
      this.productCodeTextbox.Location = new System.Drawing.Point(72, 39);
      this.productCodeTextbox.Margin = new System.Windows.Forms.Padding(4);
      this.productCodeTextbox.Name = "productCodeTextbox";
      this.productCodeTextbox.Size = new System.Drawing.Size(204, 22);
      this.productCodeTextbox.TabIndex = 0;
      // 
      // groupBox3
      // 
      this.groupBox3.Controls.Add(this.startButton);
      this.groupBox3.Controls.Add(this.samplerateTextbox);
      this.groupBox3.Controls.Add(this.label10);
      this.groupBox3.Controls.Add(this.groupTextbox);
      this.groupBox3.Controls.Add(this.unsubscribeButton);
      this.groupBox3.Controls.Add(this.serverUriTextBox);
      this.groupBox3.Controls.Add(this.subscribeResultsButton);
      this.groupBox3.Controls.Add(this.label7);
      this.groupBox3.Controls.Add(this.connectButton);
      this.groupBox3.Controls.Add(this.label11);
      this.groupBox3.Location = new System.Drawing.Point(18, 47);
      this.groupBox3.Name = "groupBox3";
      this.groupBox3.Size = new System.Drawing.Size(468, 178);
      this.groupBox3.TabIndex = 47;
      this.groupBox3.TabStop = false;
      this.groupBox3.Text = "Server";
      // 
      // label10
      // 
      this.label10.AutoSize = true;
      this.label10.Location = new System.Drawing.Point(11, 86);
      this.label10.Name = "label10";
      this.label10.Size = new System.Drawing.Size(84, 17);
      this.label10.TabIndex = 43;
      this.label10.Text = "Samplerate:";
      // 
      // samplerateTextbox
      // 
      this.samplerateTextbox.Location = new System.Drawing.Point(104, 84);
      this.samplerateTextbox.Name = "samplerateTextbox";
      this.samplerateTextbox.Size = new System.Drawing.Size(100, 22);
      this.samplerateTextbox.TabIndex = 44;
      this.samplerateTextbox.Text = "100";
      // 
      // startButton
      // 
      this.startButton.Location = new System.Drawing.Point(68, 124);
      this.startButton.Name = "startButton";
      this.startButton.Size = new System.Drawing.Size(124, 23);
      this.startButton.TabIndex = 45;
      this.startButton.Text = "Start timer";
      this.startButton.UseVisualStyleBackColor = true;
      this.startButton.Click += new System.EventHandler(this.startButton_Click);
      // 
      // MainForm
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.CancelButton = this.closeButton;
      this.ClientSize = new System.Drawing.Size(1027, 785);
      this.Controls.Add(this.groupBox3);
      this.Controls.Add(this.groupBox2);
      this.Controls.Add(this.groupBox1);
      this.Controls.Add(this.panel1);
      this.Controls.Add(this.closeButton);
      this.Controls.Add(this.writeValueButton);
      this.Controls.Add(this.label4);
      this.Controls.Add(this.exceptionTextBox);
      this.Controls.Add(this.label6);
      this.Controls.Add(this.valueToWriteTextBox);
      this.Margin = new System.Windows.Forms.Padding(4);
      this.MaximizeBox = false;
      this.Name = "MainForm";
      this.Text = "MeatMasterII OPC-UA Test client";
      this.groupBox1.ResumeLayout(false);
      this.groupBox1.PerformLayout();
      this.groupBox2.ResumeLayout(false);
      this.groupBox2.PerformLayout();
      this.groupBox3.ResumeLayout(false);
      this.groupBox3.PerformLayout();
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
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label modeLabel;
        private System.Windows.Forms.Button startStopButton;
        private System.Windows.Forms.Button setProductButton;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox productCodeTextbox;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button startButton;
        private System.Windows.Forms.TextBox samplerateTextbox;
    }
}

