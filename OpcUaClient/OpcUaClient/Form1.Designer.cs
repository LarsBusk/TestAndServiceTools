namespace OpcUaClient
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
      this.components = new System.ComponentModel.Container();
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
      this.uaConnectivity1 = new OpcLabs.EasyOpc.UA.Connectivity.UAConnectivity(this.components);
      this.pointBinder1 = new OpcLabs.BaseLib.LiveBinding.PointBinder(this.components);
      this.bindingExtender1 = new OpcLabs.BaseLib.LiveBinding.BindingExtender(this.components);
      this.textBox1 = new System.Windows.Forms.TextBox();
      ((System.ComponentModel.ISupportInitialize)(this.uaConnectivity1)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.bindingExtender1)).BeginInit();
      this.SuspendLayout();
      // 
      // uaConnectivity1
      // 
      this.uaConnectivity1.InstanceParameters.GdsEndpointDescriptor = ((OpcLabs.EasyOpc.UA.UAEndpointDescriptor)(resources.GetObject("resource.GdsEndpointDescriptor")));
      // 
      // pointBinder1
      // 
      this.pointBinder1.BindingExtender = this.bindingExtender1;
      this.pointBinder1.Connectivity = this.uaConnectivity1;
      // 
      // bindingExtender1
      // 
      this.bindingExtender1.OfflineEventSource.SourceComponent = this;
      this.bindingExtender1.OfflineEventSource.SourcePath = "FormClosing";
      this.bindingExtender1.OnlineEventSource.SourceComponent = this;
      this.bindingExtender1.OnlineEventSource.SourcePath = "Shown";
      // 
      // textBox1
      // 
      this.textBox1.Location = new System.Drawing.Point(64, 37);
      this.textBox1.Name = "textBox1";
      this.textBox1.Size = new System.Drawing.Size(194, 22);
      this.textBox1.TabIndex = 0;
      // 
      // Form1
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(800, 450);
      this.Controls.Add(this.textBox1);
      this.Name = "Form1";
      this.Text = "Form1";
      ((System.ComponentModel.ISupportInitialize)(this.uaConnectivity1)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.bindingExtender1)).EndInit();
      this.ResumeLayout(false);
      this.PerformLayout();

    }

        #endregion

        private OpcLabs.EasyOpc.UA.Connectivity.UAConnectivity uaConnectivity1;
        private OpcLabs.BaseLib.LiveBinding.PointBinder pointBinder1;
        private OpcLabs.BaseLib.LiveBinding.BindingExtender bindingExtender1;
        private System.Windows.Forms.TextBox textBox1;
    }
}

