using CanteenApp.Controllers;
using CanteenApp.Models;
using CanteenApp.Pages;
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

namespace CanteenApp.Forms
{
    public partial class Product : Form
    {
        private readonly ProductForm _parent;
        public string id, name, price, stock, description, image;
        public string[] categoryId;

        private void imgProduct_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFile = new OpenFileDialog();
            openFile.Filter = "File gambar (*.jpg; *.jpeg; *.png) | *.jpg; *.jpeg; *.png";
            if (openFile.ShowDialog() == DialogResult.OK)
            {
                image = openFile.FileName;
                imgProduct.IconChar = FontAwesome.Sharp.IconChar.None;
                imgProduct.BackgroundImage = new Bitmap(openFile.FileName);
                imgProduct.ImageLocation = openFile.FileName;
                imgProduct.SizeMode = PictureBoxSizeMode.StretchImage;
            }
        }

        public Product(ProductForm parent)
        {
            InitializeComponent();
            _parent = parent;
            LoadCategory();
        }

        public void LoadCategory()
        {
            DBCategory dBCategory = new DBCategory();
            dBCategory.LoadCategory("SELECT * FROM categories", cbxCategory);
        }

        public void UpdateInfo()
        {
            labelHeader.Text = "Update Product";
            btnAdd.Text = "Update";
            foreach (var item in categoryId)
            {
                cbxCategory.Items.Add(item);
            }
            txtName.Text = name;
            txtStock.Text = stock;
            txtPrice.Text = price;
            txtDescription.Text = description;
        }

        public void Clear()
        {
            cbxCategory.Refresh();
            txtName.Text = string.Empty;
            txtPrice.Text = string.Empty;
            txtStock.Text = string.Empty;
            txtDescription.Text= string.Empty;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            //if (txtName.Text.Trim().Length == 0)
            //{
            //    MessageBox.Show("Nama harus diisi");
            //    return;
            //}
            //if (txtPrice.Text.Trim().Length == 0)
            //{
            //    MessageBox.Show("Harga harus diisi");
            //    return;
            //}
            //if (txtStock.Text.Trim().Length == 0)
            //{
            //    MessageBox.Show("Stok harus diisi");
            //    return;
            //}
            //if (txtDescription.Text.Trim().Length == 0)
            //{
            //    MessageBox.Show("Deskripsi harus diisi");
            //    return;
            //}
            //if (cbxCategory.Text.Trim().Length == 0)
            //{
            //    MessageBox.Show("Kategori harus diisi");
            //    return;
            //}
            if (btnAdd.Text == "Add")
            {
                DBProducts dBProducts = new DBProducts();
                int categoryId = dBProducts.GetCategoryId(cbxCategory.Text);
                ProductModel product = new ProductModel(categoryId.ToString(), txtName.Text.Trim(), Int32.Parse(txtPrice.Text.Trim()), Int32.Parse(txtStock.Text.Trim()), txtDescription.Text.Trim(), Path.GetFileName(imgProduct.ImageLocation));
                dBProducts.AddProduct(product);
                string assemblyLocation = Assembly.GetExecutingAssembly().Location;
                File.Copy(image, Directory.GetParent(assemblyLocation).Parent.Parent.FullName + @"\Images\" + Path.GetFileName(imgProduct.ImageLocation));
            }
            if (btnAdd.Text == "Update")
            {
                CategoryModel categoryModel = new CategoryModel(txtName.Text.Trim());
                DBCategory category = new DBCategory();
                category.UpdateCategory(categoryModel, id);
            }
            Clear();
            _parent.Display();
        }
    }
}
