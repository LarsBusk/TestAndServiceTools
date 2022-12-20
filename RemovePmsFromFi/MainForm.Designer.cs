namespace RemovePmsFromFi
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
            this.buttonUnusedProducts = new System.Windows.Forms.Button();
            this.buttonUnusedPms = new System.Windows.Forms.Button();
            this.comboBoxVersions = new System.Windows.Forms.ComboBox();
            this.buttonUsedroducts = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // buttonUnusedProducts
            // 
            this.buttonUnusedProducts.Enabled = false;
            this.buttonUnusedProducts.Location = new System.Drawing.Point(252, 90);
            this.buttonUnusedProducts.Name = "buttonUnusedProducts";
            this.buttonUnusedProducts.Size = new System.Drawing.Size(108, 23);
            this.buttonUnusedProducts.TabIndex = 0;
            this.buttonUnusedProducts.Text = "Unused Products";
            this.buttonUnusedProducts.UseVisualStyleBackColor = true;
            this.buttonUnusedProducts.Click += new System.EventHandler(this.buttonUnusedProducts_Click);
            // 
            // buttonUnusedPms
            // 
            this.buttonUnusedPms.Enabled = false;
            this.buttonUnusedPms.Location = new System.Drawing.Point(252, 138);
            this.buttonUnusedPms.Name = "buttonUnusedPms";
            this.buttonUnusedPms.Size = new System.Drawing.Size(108, 23);
            this.buttonUnusedPms.TabIndex = 1;
            this.buttonUnusedPms.Text = "Unused PMs";
            this.buttonUnusedPms.UseVisualStyleBackColor = true;
            this.buttonUnusedPms.Click += new System.EventHandler(this.buttonUnusedPms_Click);
            // 
            // comboBoxVersions
            // 
            this.comboBoxVersions.FormattingEnabled = true;
            this.comboBoxVersions.Location = new System.Drawing.Point(32, 45);
            this.comboBoxVersions.Name = "comboBoxVersions";
            this.comboBoxVersions.Size = new System.Drawing.Size(121, 21);
            this.comboBoxVersions.TabIndex = 3;
            this.comboBoxVersions.SelectedIndexChanged += new System.EventHandler(this.comboBoxVersions_SelectedIndexChanged);
            // 
            // buttonUsedroducts
            // 
            this.buttonUsedroducts.Location = new System.Drawing.Point(252, 45);
            this.buttonUsedroducts.Name = "buttonUsedroducts";
            this.buttonUsedroducts.Size = new System.Drawing.Size(108, 23);
            this.buttonUsedroducts.TabIndex = 4;
            this.buttonUsedroducts.Text = "Find used products";
            this.buttonUsedroducts.UseVisualStyleBackColor = true;
            this.buttonUsedroducts.Click += new System.EventHandler(this.buttonUsedProducts_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(29, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Select version";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(398, 207);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buttonUsedroducts);
            this.Controls.Add(this.comboBoxVersions);
            this.Controls.Add(this.buttonUnusedPms);
            this.Controls.Add(this.buttonUnusedProducts);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.Text = "FossIntegrator prediction model cleaner";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonUnusedProducts;
        private System.Windows.Forms.Button buttonUnusedPms;
        private System.Windows.Forms.ComboBox comboBoxVersions;
        private System.Windows.Forms.Button buttonUsedroducts;
        private System.Windows.Forms.Label label1;
    }
}

