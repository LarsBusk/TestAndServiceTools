using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DataBaseServiceTool;

namespace FiLimsTool
{
    public partial class Form1 : Form
    {
        private SqlServerHelper helper;
        private FiHelpers fiHelpers;
        private CsvCreator _csvCreator = new CsvCreator();

        public Form1()
        {
            InitializeComponent();
            helper = new SqlServerHelper(@"lab-w10-cmt\foss_fi2");
            fiHelpers = new FiHelpers();
        }

        private void zerosButton_Click(object sender, EventArgs e)
        {
            var zeroIds = helper.GetZeroIds().ToList();
            List<int> firstTen = new List<int>();

            for (int i = 0; i < 10; i++)
            {
                firstTen.Add(zeroIds[i]);
            }
        }

        private void aquiredDataButton_Click(object sender, EventArgs e)
        {
            _csvCreator.CreateCsvForAcquiredData(
                helper.GetAcquiredDoubleData(58)); //int.Parse(sampleIndexTextBox.Text)));
        }

        private void sysFilesButton_Click(object sender, EventArgs e)
        {
            richTextBox1.Clear();
            var form = new MissingSetupForm();
            form.Container = fiHelpers.GetMissingSetups();
            form.ShowDialog();

            foreach (var setup in fiHelpers.GetMissingSetups())  
            {
                richTextBox1.AppendText($"{setup.SetupFileName}\n");
            }
        }
    }
}
