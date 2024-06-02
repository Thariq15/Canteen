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
        public string id, name, price, stock, description, image, oldImage, category;

        private void imgProduct_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFile = new OpenFileDialog();
            openFile.Filter = "File gambar (*.jpg; *.jpeg; *.png) | *.jpg; *.jpeg; *.png";
            if (openFile.ShowDialog() == DialogResult.OK)
            {
                oldImage = image;
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
            txtName.Text = name;
            txtStock.Text = stock;
            txtPrice.Text = price;
            txtDescription.Text = description;
            cbxCategory.SelectedItem = category;
            string assemblyLocation = Assembly.GetExecutingAssembly().Location;
            string currentImg = Directory.GetParent(assemblyLocation).Parent.Parent.FullName + @"\Images\" + image;
            imgProduct.BackgroundImage = new Bitmap(currentImg);
            imgProduct.ImageLocation = currentImg;
            imgProduct.SizeMode = PictureBoxSizeMode.StretchImage;
        }

        public void Clear()
        {
            cbxCategory.ResetText();
            txtName.Text = string.Empty;
            txtPrice.Text = string.Empty;
            txtStock.Text = string.Empty;
            txtDescription.Text= string.Empty;
            imgProduct.BackgroundImage = null;
            imgProduct.ImageLocation = null;
            imgProduct.IconChar = FontAwesome.Sharp.IconChar.Image;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (imgProduct.Image == null)
            {
                MessageBox.Show("Gambar harus diisi");
                return;
            }
            if (cbxCategory.SelectedIndex == -1)
            {
                MessageBox.Show("Kategori harus dipilih");
                return;
            }
            if (txtName.Text.Trim().Length == 0)
            {
                MessageBox.Show("Nama harus diisi");
                return;
            }
            if (txtStock.Text.Trim().Length == 0)
            {
                MessageBox.Show("Stok harus diisi");
                return;
            }
            if (txtPrice.Text.Trim().Length == 0)
            {
                MessageBox.Show("Harga harus diisi");
                return;
            }
            if (txtDescription.Text.Trim().Length == 0)
            {
                MessageBox.Show("Deskripsi harus diisi");
                return;
            }
            if (btnAdd.Text == "Add")
            {
                DateTime now = DateTime.Now;
                DateTimeOffset dateTimeOffset = new DateTimeOffset(now);
                long unixTimestamp = dateTimeOffset.ToUnixTimeSeconds();

                DBProducts dBProducts = new DBProducts();
                int categoryId = dBProducts.GetCategoryId(cbxCategory.Text);
                ProductModel product = new ProductModel(categoryId.ToString(), txtName.Text.Trim(), Int32.Parse(txtPrice.Text.Trim()), Int32.Parse(txtStock.Text.Trim()), txtDescription.Text.Trim(), unixTimestamp + Path.GetExtension(imgProduct.ImageLocation));

                string assemblyLocation = Assembly.GetExecutingAssembly().Location;
                File.Copy(image, Directory.GetParent(assemblyLocation).Parent.Parent.FullName + @"\Images\" + unixTimestamp + Path.GetExtension(imgProduct.ImageLocation));
                dBProducts.AddProduct(product);
            }
            if (btnAdd.Text == "Update")
            {
                image = imgProduct.ImageLocation;
                DateTime now = DateTime.Now;
                DateTimeOffset dateTimeOffset = new DateTimeOffset(now);
                long unixTimestamp = dateTimeOffset.ToUnixTimeSeconds();

                DBProducts dBProducts = new DBProducts();
                int categoryId = dBProducts.GetCategoryId(cbxCategory.Text);
                ProductModel product = new ProductModel(categoryId.ToString(), txtName.Text.Trim(), Int32.Parse(txtPrice.Text.Trim()), Int32.Parse(txtStock.Text.Trim()), txtDescription.Text.Trim(), unixTimestamp + Path.GetExtension(imgProduct.ImageLocation));

                string assemblyLocation = Assembly.GetExecutingAssembly().Location;
                File.Copy(image, Directory.GetParent(assemblyLocation).Parent.Parent.FullName + @"\Images\" + unixTimestamp + Path.GetExtension(imgProduct.ImageLocation));
                dBProducts.UpdateProduct(product, id);
                //dBProducts.DeleteImage(oldImage);
            }
            Clear();
            _parent.Display();
        }
    }
}
