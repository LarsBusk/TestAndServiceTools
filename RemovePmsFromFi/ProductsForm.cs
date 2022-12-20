using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace RemovePmsFromFi
{
    public partial class ProductsForm : Form
    {
        public List<string> Products;
        public string Message;
        public string ButtonText;

        public ProductsForm()
        {
            InitializeComponent();
        }

        private void ProductsForm_Load(object sender, EventArgs e)
        {
            listBoxProducts.Items.AddRange(Products.ToArray());
            label1.Text = Message;
            closeButton.Text = ButtonText;
        }

        private void ProductsForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Products = listBoxProducts.SelectedItems.Cast<string>().ToList();
        }

        private void SelectAll()
        {
            var noOfItems = listBoxProducts.Items.Count;

            for (int i = 0; i < noOfItems; i++)
            {
                listBoxProducts.SelectedItems.Add(listBoxProducts.Items[i]);
            }
        }

        private void DeSelectAll()
        {
            var noOfItems = listBoxProducts.Items.Count;

            for (int i = 0; i < noOfItems; i++)
            {
                listBoxProducts.SelectedItems.Remove(listBoxProducts.Items[i]);
            }
        }

        private void selectAllButton_Click(object sender, EventArgs e)
        {
            SelectAll();
        }

        private void deselectAllButton_Click(object sender, EventArgs e)
        {
            DeSelectAll();
        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
