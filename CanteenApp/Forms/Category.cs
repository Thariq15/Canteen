using CanteenApp.Controllers;
using CanteenApp.Models;
using CanteenApp.Pages;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CanteenApp.Forms
{
    public partial class Category : Form
    {
        private readonly CategoryForm _parent;
        public string id, name;

        public Category(CategoryForm parent)
        {
            InitializeComponent();
            _parent = parent;
        }

        public void UpdateInfo()
        {
            labelHeader.Text = "Update Category";
            btnAdd.Text = "Update";
            txtName.Text = name;
        }

        public void Clear()
        {
            txtName.Text = string.Empty;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (txtName.Text.Trim().Length == 0)
            {
                MessageBox.Show("Nama harus diisi");
                return;
            }
            if (btnAdd.Text == "Add")
            {
                CategoryModel categoryModel = new CategoryModel(txtName.Text.Trim());
                DBCategory category = new DBCategory();
                category.AddCategory(categoryModel);
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
