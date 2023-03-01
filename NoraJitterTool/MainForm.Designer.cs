namespace NoraJitterTool
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
            this.TestSystemCombo = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.NoraVersionCombo = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.PlatformVersionCombo = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.SelectCsvButton = new System.Windows.Forms.Button();
            this.AddDataButton = new System.Windows.Forms.Button();
            this.CommentTextBox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.AddTestSystemButton = new System.Windows.Forms.Button();
            this.CleanupButton = new System.Windows.Forms.Button();
            this.NoDelayedResultsCb = new System.Windows.Forms.CheckBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // TestSystemCombo
            // 
            this.TestSystemCombo.FormattingEnabled = true;
            this.TestSystemCombo.Location = new System.Drawing.Point(42, 35);
            this.TestSystemCombo.Name = "TestSystemCombo";
            this.TestSystemCombo.Size = new System.Drawing.Size(160, 21);
            this.TestSystemCombo.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(39, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Test system";
            // 
            // NoraVersionCombo
            // 
            this.NoraVersionCombo.FormattingEnabled = true;
            this.NoraVersionCombo.Location = new System.Drawing.Point(6, 34);
            this.NoraVersionCombo.Name = "NoraVersionCombo";
            this.NoraVersionCombo.Size = new System.Drawing.Size(121, 21);
            this.NoraVersionCombo.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 18);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(83, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Nora sw version";
            // 
            // PlatformVersionCombo
            // 
            this.PlatformVersionCombo.FormattingEnabled = true;
            this.PlatformVersionCombo.Location = new System.Drawing.Point(6, 74);
            this.PlatformVersionCombo.Name = "PlatformVersionCombo";
            this.PlatformVersionCombo.Size = new System.Drawing.Size(121, 21);
            this.PlatformVersionCombo.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 58);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(82, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Platform version";
            // 
            // SelectCsvButton
            // 
            this.SelectCsvButton.Location = new System.Drawing.Point(429, 180);
            this.SelectCsvButton.Name = "SelectCsvButton";
            this.SelectCsvButton.Size = new System.Drawing.Size(75, 23);
            this.SelectCsvButton.TabIndex = 6;
            this.SelectCsvButton.Text = "Select Csv";
            this.SelectCsvButton.UseVisualStyleBackColor = true;
            this.SelectCsvButton.Click += new System.EventHandler(this.SelectCsvButton_Click);
            // 
            // AddDataButton
            // 
            this.AddDataButton.Location = new System.Drawing.Point(429, 209);
            this.AddDataButton.Name = "AddDataButton";
            this.AddDataButton.Size = new System.Drawing.Size(75, 23);
            this.AddDataButton.TabIndex = 7;
            this.AddDataButton.Text = "Add data";
            this.AddDataButton.UseVisualStyleBackColor = true;
            this.AddDataButton.Click += new System.EventHandler(this.AddDataButton_Click);
            // 
            // CommentTextBox
            // 
            this.CommentTextBox.Location = new System.Drawing.Point(6, 121);
            this.CommentTextBox.Name = "CommentTextBox";
            this.CommentTextBox.Size = new System.Drawing.Size(324, 20);
            this.CommentTextBox.TabIndex = 8;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(3, 105);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(51, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "Comment";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.NoDelayedResultsCb);
            this.groupBox1.Controls.Add(this.NoraVersionCombo);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.CommentTextBox);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.PlatformVersionCombo);
            this.groupBox1.Location = new System.Drawing.Point(42, 75);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(347, 157);
            this.groupBox1.TabIndex = 10;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Test setup";
            // 
            // AddTestSystemButton
            // 
            this.AddTestSystemButton.Location = new System.Drawing.Point(420, 19);
            this.AddTestSystemButton.Name = "AddTestSystemButton";
            this.AddTestSystemButton.Size = new System.Drawing.Size(93, 23);
            this.AddTestSystemButton.TabIndex = 11;
            this.AddTestSystemButton.Text = "Add test system";
            this.AddTestSystemButton.UseVisualStyleBackColor = true;
            this.AddTestSystemButton.Click += new System.EventHandler(this.AddTestSystemButton_Click);
            // 
            // CleanupButton
            // 
            this.CleanupButton.Location = new System.Drawing.Point(420, 48);
            this.CleanupButton.Name = "CleanupButton";
            this.CleanupButton.Size = new System.Drawing.Size(93, 23);
            this.CleanupButton.TabIndex = 12;
            this.CleanupButton.Text = "Cleanup";
            this.CleanupButton.UseVisualStyleBackColor = true;
            this.CleanupButton.Click += new System.EventHandler(this.CleanupButton_Click);
            // 
            // NoDelayedResultsCb
            // 
            this.NoDelayedResultsCb.AutoSize = true;
            this.NoDelayedResultsCb.Location = new System.Drawing.Point(153, 34);
            this.NoDelayedResultsCb.Name = "NoDelayedResultsCb";
            this.NoDelayedResultsCb.Size = new System.Drawing.Size(113, 17);
            this.NoDelayedResultsCb.TabIndex = 10;
            this.NoDelayedResultsCb.Text = "No delayed results";
            this.NoDelayedResultsCb.UseVisualStyleBackColor = true;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(525, 256);
            this.Controls.Add(this.CleanupButton);
            this.Controls.Add(this.AddTestSystemButton);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.AddDataButton);
            this.Controls.Add(this.SelectCsvButton);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.TestSystemCombo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.Text = "Nora Jitter Tool";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox TestSystemCombo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox NoraVersionCombo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox PlatformVersionCombo;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button SelectCsvButton;
        private System.Windows.Forms.Button AddDataButton;
        private System.Windows.Forms.TextBox CommentTextBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button AddTestSystemButton;
        private System.Windows.Forms.Button CleanupButton;
        private System.Windows.Forms.CheckBox NoDelayedResultsCb;
    }
}

