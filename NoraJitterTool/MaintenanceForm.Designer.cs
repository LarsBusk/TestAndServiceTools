namespace NoraJitterTool
{
    partial class MaintenanceForm
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.RemoveButton = new System.Windows.Forms.Button();
            this.SetupCombo = new System.Windows.Forms.ComboBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.SetupCombo2 = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.DelayCombo = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.DelayIDTb = new System.Windows.Forms.TextBox();
            this.RemoveDelayButton = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.RemoveButton);
            this.groupBox1.Controls.Add(this.SetupCombo);
            this.groupBox1.Location = new System.Drawing.Point(12, 21);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(200, 100);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Remove testsetup";
            // 
            // RemoveButton
            // 
            this.RemoveButton.Location = new System.Drawing.Point(6, 71);
            this.RemoveButton.Name = "RemoveButton";
            this.RemoveButton.Size = new System.Drawing.Size(75, 23);
            this.RemoveButton.TabIndex = 1;
            this.RemoveButton.Text = "Remove";
            this.RemoveButton.UseVisualStyleBackColor = true;
            this.RemoveButton.Click += new System.EventHandler(this.RemoveButton_Click);
            // 
            // SetupCombo
            // 
            this.SetupCombo.FormattingEnabled = true;
            this.SetupCombo.Location = new System.Drawing.Point(6, 34);
            this.SetupCombo.Name = "SetupCombo";
            this.SetupCombo.Size = new System.Drawing.Size(121, 21);
            this.SetupCombo.TabIndex = 0;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.RemoveDelayButton);
            this.groupBox2.Controls.Add(this.DelayIDTb);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.DelayCombo);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.SetupCombo2);
            this.groupBox2.Location = new System.Drawing.Point(237, 21);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(200, 240);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Remove delay";
            // 
            // SetupCombo2
            // 
            this.SetupCombo2.FormattingEnabled = true;
            this.SetupCombo2.Location = new System.Drawing.Point(6, 34);
            this.SetupCombo2.Name = "SetupCombo2";
            this.SetupCombo2.Size = new System.Drawing.Size(167, 21);
            this.SetupCombo2.TabIndex = 0;
            this.SetupCombo2.SelectedIndexChanged += new System.EventHandler(this.SetupCombo2_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Test setup";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 18);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(57, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Test setup";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 71);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(82, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Sample Number";
            // 
            // DelayCombo
            // 
            this.DelayCombo.FormattingEnabled = true;
            this.DelayCombo.Location = new System.Drawing.Point(6, 87);
            this.DelayCombo.Name = "DelayCombo";
            this.DelayCombo.Size = new System.Drawing.Size(167, 21);
            this.DelayCombo.TabIndex = 4;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 125);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(45, 13);
            this.label4.TabIndex = 5;
            this.label4.Text = "DelayID";
            // 
            // DelayIDTb
            // 
            this.DelayIDTb.Location = new System.Drawing.Point(6, 141);
            this.DelayIDTb.Name = "DelayIDTb";
            this.DelayIDTb.Size = new System.Drawing.Size(167, 20);
            this.DelayIDTb.TabIndex = 6;
            // 
            // RemoveDelayButton
            // 
            this.RemoveDelayButton.Location = new System.Drawing.Point(6, 190);
            this.RemoveDelayButton.Name = "RemoveDelayButton";
            this.RemoveDelayButton.Size = new System.Drawing.Size(75, 23);
            this.RemoveDelayButton.TabIndex = 7;
            this.RemoveDelayButton.Text = "Remove";
            this.RemoveDelayButton.UseVisualStyleBackColor = true;
            this.RemoveDelayButton.Click += new System.EventHandler(this.RemoveDelayButton_Click);
            // 
            // MaintenanceForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(580, 394);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "MaintenanceForm";
            this.Text = "Maintenance";
            this.Load += new System.EventHandler(this.MaintenanceForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button RemoveButton;
        private System.Windows.Forms.ComboBox SetupCombo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button RemoveDelayButton;
        private System.Windows.Forms.TextBox DelayIDTb;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox DelayCombo;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox SetupCombo2;
    }
}