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
            HiLoTb.Text = Converters.MosaicToFiChassisID(mosaicTb.Text);
        }

        private void convertToMosaicBtn_Click(object sender, EventArgs e)
        {
            mosaicTb.Text = Converters.FiToMosaicChassisID(HiLoTb.Text);
        }


        private void Form1_Load(object sender, EventArgs e)
        {
            mosaicTb.Focus();
            mosaicTb.Text = "";
        }

        private void convertFromFiCidBtn_Click(object sender, EventArgs e)
        {
            var elements = fiCidTb.Text.Split('-');
            string hexString = string.Empty;
            foreach (var element in elements)
            {
                hexString += Converters.DecimalToHex(element, 2);
            }

            hexCidTb.Text = hexString;
            decimalCidTb.Text = Converters.HexToDecimal(hexString);
        }

        private void convertFromHexCidBtn_Click(object sender, EventArgs e)
        {
            decimalCidTb.Text = Converters.HexToDecimal(hexCidTb.Text);
            fiCidTb.Text = Converters.HexToFiCid(hexCidTb.Text);
        }

        private void convertFromDecCidBtn_Click(object sender, EventArgs e)
        {
            hexCidTb.Text = Converters.DecimalToHex(decimalCidTb.Text, 8);
            fiCidTb.Text = Converters.HexToFiCid(hexCidTb.Text);
        }
    }
}
