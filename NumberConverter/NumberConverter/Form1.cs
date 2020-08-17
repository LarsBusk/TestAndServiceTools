using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
//using NumberConverter.Converters;

namespace NumberConverter
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonConvert_Click(object sender, EventArgs e)
        {
            if (convertToFI.Checked)
            {                
                labelResult.Text = Converters.MosaicToFiChassisID(textBoxInput.Text); 
            }
            if (convertMosaic.Checked) 
            {
                labelResult.Text = Converters.FiToMosaicChassisID(textBoxInput.Text);   
            }
            textBoxInput.Text = "";
            textBoxInput.Focus();
        }

        
        

        private void Form1_Load(object sender, EventArgs e)
        {
            textBoxInput.Focus();
            textBoxInput.Text = "";
        }

        private void convertMosaic_CheckedChanged(object sender, EventArgs e)
        {
            inputStyleLabel.Text = "Foss Integrator Instrument ID to convert (low, high)";
            textBoxInput.Text = "0,0";
            textBoxInput.Focus();
        }

        private void convertToFI_CheckedChanged(object sender, EventArgs e)
        {
            inputStyleLabel.Text = "Mosaic instrument ID to convert";
            textBoxInput.Text = "0";
            textBoxInput.Focus();
        }

      
    }
}
