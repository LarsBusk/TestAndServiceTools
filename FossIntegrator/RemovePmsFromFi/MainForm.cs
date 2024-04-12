using System;
using System.Windows.Forms;

namespace RemovePmsFromFi
{
    public partial class MainForm : Form
    {
        private string basePath;
        private XmlHelper xmlHelper;
        ToolTip toolTip;

        private string[] usedProducts;

        public MainForm()
        {
            InitializeComponent();
        }

        private void buttonUnusedProducts_Click(object sender, EventArgs e)
        {
            xmlHelper.UsedProducts = usedProducts;
            xmlHelper.RemoveProductsFromSysXml();
        }

        private void buttonUnusedPms_Click(object sender, EventArgs e)
        {
            xmlHelper.RemovePmsFromSysXml();
            xmlHelper.RemoveUnusedComponentsFromCom();
        }


        private void MainForm_Load(object sender, EventArgs e)
        {
            comboBoxVersions.Items.AddRange(FiHelper.GetVersions());

            if (comboBoxVersions.Items.Count > 0)
                comboBoxVersions.SelectedIndex = 0;

            basePath = ((FiVersions)comboBoxVersions.SelectedItem)?.Version ??
                       @"C:\Users\lab\Projects\GitHub\Learing\RemovePmsFromFi";
            xmlHelper = new XmlHelper(basePath);
            toolTip = new ToolTip();
            toolTip.SetToolTip(buttonUsedroducts, "Finds the products that are used in current results.");
            toolTip.SetToolTip(buttonUnusedProducts, "Selects and removes unused products.");
            toolTip.SetToolTip(buttonUnusedPms, "Selects and removes unused prediction models.");
        }

        private void comboBoxVersions_SelectedIndexChanged(object sender, EventArgs e)
        {
            basePath = ((FiVersions)comboBoxVersions.SelectedItem).Version;
            FiHelper.SelectedVersion = basePath;
        }

        private void buttonUsedProducts_Click(object sender, EventArgs e)
        {
            var dataHelper = new DatabaseHelper();

            var form = new ProductsForm()
            {
                Products = dataHelper.UsedProducts(),
                Message = "These products are used in results, select the ones to keep.",
                ButtonText = "Ok"
            };

            if (form.ShowDialog().Equals(DialogResult.Cancel))
                return;

            usedProducts = form.Products.ToArray();
            buttonUnusedProducts.Enabled = true;
            buttonUnusedPms.Enabled = true;
        }
    }
}
