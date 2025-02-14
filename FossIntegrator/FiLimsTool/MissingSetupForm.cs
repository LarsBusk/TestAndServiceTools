using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FiLimsTool
{
    public partial class MissingSetupForm : Form
    {
        public IEnumerable<SetupContainer> Container;
        public MissingSetupForm()
        {
            InitializeComponent();
        }

        private void MissingSetupForm_Load(object sender, EventArgs e)
        {
            dataGridView1.ColumnCount = 3;
            dataGridView1.Columns[0].Name = "SetupType";
            dataGridView1.Columns[1].Name = "SetupIndex";
            dataGridView1.Columns[2].Name = "Filename";

            foreach (var setupContainer in Container)
            {
                dataGridView1.Rows.Add(setupContainer.ToArray());
            }
        }
    }
}
