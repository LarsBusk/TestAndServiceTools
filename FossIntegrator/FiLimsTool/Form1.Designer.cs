namespace FiLimsTool
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
            this.zerosButton = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.sampleIndexTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.sysFilesButton = new System.Windows.Forms.Button();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // zerosButton
            // 
            this.zerosButton.Location = new System.Drawing.Point(128, 75);
            this.zerosButton.Name = "zerosButton";
            this.zerosButton.Size = new System.Drawing.Size(75, 23);
            this.zerosButton.TabIndex = 0;
            this.zerosButton.Text = "Zeros";
            this.zerosButton.UseVisualStyleBackColor = true;
            this.zerosButton.Click += new System.EventHandler(this.zerosButton_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(128, 117);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "AquiredData";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.aquiredDataButton_Click);
            // 
            // sampleIndexTextBox
            // 
            this.sampleIndexTextBox.Location = new System.Drawing.Point(220, 120);
            this.sampleIndexTextBox.Name = "sampleIndexTextBox";
            this.sampleIndexTextBox.Size = new System.Drawing.Size(100, 20);
            this.sampleIndexTextBox.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(217, 104);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "SampleIndex";
            // 
            // sysFilesButton
            // 
            this.sysFilesButton.Location = new System.Drawing.Point(128, 162);
            this.sysFilesButton.Name = "sysFilesButton";
            this.sysFilesButton.Size = new System.Drawing.Size(75, 23);
            this.sysFilesButton.TabIndex = 4;
            this.sysFilesButton.Text = "SysFiles";
            this.sysFilesButton.UseVisualStyleBackColor = true;
            this.sysFilesButton.Click += new System.EventHandler(this.sysFilesButton_Click);
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(391, 52);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(307, 375);
            this.richTextBox1.TabIndex = 5;
            this.richTextBox1.Text = "";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.sysFilesButton);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.sampleIndexTextBox);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.zerosButton);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button zerosButton;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox sampleIndexTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button sysFilesButton;
        private System.Windows.Forms.RichTextBox richTextBox1;
    }
}

