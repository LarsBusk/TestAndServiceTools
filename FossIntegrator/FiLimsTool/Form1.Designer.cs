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
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.zerosButton);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button zerosButton;
    }
}

