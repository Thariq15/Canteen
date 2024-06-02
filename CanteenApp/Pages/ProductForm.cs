using CanteenApp.Controllers;
using CanteenApp.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Interop;

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
            dBProducts.DisplayAndSearch("SELECT a.id, a.name, a.price, a.stock, a.description, a.image, b.name AS category FROM products a JOIN categories b ON a.category_id = b.id", dgvProduct);
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

        private void dgvProduct_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                form.id = dgvProduct.Rows[e.RowIndex].Cells[2].Value.ToString();
                form.name = dgvProduct.Rows[e.RowIndex].Cells[3].Value.ToString();
                form.price = dgvProduct.Rows[e.RowIndex].Cells[4].Value.ToString();
                form.stock = dgvProduct.Rows[e.RowIndex].Cells[5].Value.ToString();
                form.description = dgvProduct.Rows[e.RowIndex].Cells[6].Value.ToString();
                form.category = dgvProduct.Rows[e.RowIndex].Cells[8].Value.ToString();
                form.image = dgvProduct.Rows[e.RowIndex].Cells[7].Value.ToString();
                form.UpdateInfo();
                form.ShowDialog();
                return;
            }
            else if (e.ColumnIndex == 1)
            {
                if (MessageBox.Show("Apakah anda yakin ingin menghapus kategori ini?", "Hapus Kategori", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    DBProducts dBProducts = new DBProducts();
                    dBProducts.DeleteProduct(dgvProduct.Rows[e.RowIndex].Cells[2].Value.ToString());
                    string assemblyLocation = Assembly.GetExecutingAssembly().Location;
                    File.Delete(Directory.GetParent(assemblyLocation).Parent.Parent.FullName + @"\Images\" + dgvProduct.Rows[e.RowIndex].Cells[7].Value.ToString());
                    Display();
                }
                return;
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            DBProducts dBProducts = new DBProducts();
            dBProducts.DisplayAndSearch("SELECT a.id, a.name, a.price, a.stock, a.description, a.image, b.name AS category FROM products a JOIN categories b ON a.category_id = b.id WHERE a.name ILIKE '%" + txtSearch.Text + "%'", dgvProduct);
        }
    }
}
