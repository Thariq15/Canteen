using CanteenApp.Controllers;
using CanteenApp.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CanteenApp.Pages
{
    public partial class ProductForm : Form
    {
        Product form;
        public ProductForm()
        {
            InitializeComponent();
            form = new Product(this);
        }

        public void Display()
        {
            DBProducts dBProducts = new DBProducts();
            dBProducts.DisplayAndSearch("SELECT a.*, b.name AS category FROM products a JOIN categories b ON a.category_id = b.id", dgvProduct);
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            form.Clear();
            Product product = new Product(this);
            product.ShowDialog();
        }

        private void ProductForm_Shown(object sender, EventArgs e)
        {
            Display();
        }
    }
}
