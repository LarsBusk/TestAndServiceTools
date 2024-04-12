using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
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
        public Form1()
        {
            InitializeComponent();
            helper = new SqlServerHelper(@".\SQL2019");
        }

        private void zerosButton_Click(object sender, EventArgs e)
        {
            var zeroIds = helper.GetZeroIds();
            List<int> firstTen = new List<int>();

            for (int i = 0; i < 10; i++)
            {
                firstTen.Add(zeroIds[i]); 
            }
        }
    }
}
