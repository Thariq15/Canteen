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
    public partial class CategoryForm : Form
    {
        Category form;
        public CategoryForm()
        {
            InitializeComponent();
            form = new Category(this);
        }

        public void Display()
        {
            DBCategory category = new DBCategory();
            category.DisplayAndSearch("SELECT * FROM categories ORDER BY id", dgvCategory);
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            form.Clear();
            Category category = new Category(this);
            category.ShowDialog();
        }

        private void CategoryForm_Shown(object sender, EventArgs e)
        {
            Display();
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            DBCategory dBCategory = new DBCategory();
            dBCategory.DisplayAndSearch("SELECT * FROM categories WHERE name ILIKE '%" + txtSearch.Text + "%' ORDER BY id",dgvCategory);
        }

        private void dgvCategory_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                form.id = dgvCategory.Rows[e.RowIndex].Cells[2].Value.ToString();
                form.name = dgvCategory.Rows[e.RowIndex].Cells[3].Value.ToString();
                form.UpdateInfo();
                form.ShowDialog();
                return;
            }
            else if (e.ColumnIndex == 1)
            {
                if (MessageBox.Show("Apakah anda yakin ingin menghapus kategori ini?","Hapus Kategori",MessageBoxButtons.YesNo,MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    DBCategory dBCategory = new DBCategory();
                    dBCategory.DeleteCategory(dgvCategory.Rows[e.RowIndex].Cells[2].Value.ToString());
                    Display();
                }
                return;
            }
        }
    }
}
