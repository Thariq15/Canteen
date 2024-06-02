using CanteenApp.Controllers;
using CanteenApp.Forms;
using CanteenApp.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TextBox;

namespace CanteenApp.Pages
{
    public partial class ShopForm : Form
    {
        Quantity quantity;
        Receipt receipt;
        public string transactionCode, customerName;
        public DateTime transactionDate;
        public int adminId, totalPrice, totalPayment, change;

        public ShopForm()
        {
            InitializeComponent();
            quantity = new Quantity(this);
            receipt = new Receipt(this);
        }

        public void Display()
        {
            DBProducts dBProducts = new DBProducts();
            dBProducts.DisplayAndSearch("SELECT a.id, a.name, a.price, a.stock, a.description, a.image, b.name AS category FROM products a JOIN categories b ON a.category_id = b.id WHERE a.stock > 0", dgvProduct);
        }

        public void Clear()
        {
            txtCustName.Text = string.Empty;
            txtTotalPayment.Text = string.Empty;
            txtTotalPrice.Text = string.Empty;
            totalPrice = 0;
            dgvCart.Rows.Clear();
        }

        public void UpdateTotalPrice(int subTotal)
        {
            totalPrice += subTotal;
            txtTotalPrice.Text = totalPrice.ToString();
        }
        private void ShopForm_Shown(object sender, EventArgs e)
        {
            Display();
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            DBProducts dBProducts = new DBProducts();
            dBProducts.DisplayAndSearch("SELECT a.id, a.name, a.price, a.stock, a.description, a.image, b.name AS category FROM products a JOIN categories b ON a.category_id = b.id WHERE a.name ILIKE '%" + txtSearch.Text + "%'", dgvProduct);
        }

        private void dgvProduct_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                quantity.productId = Convert.ToInt32(dgvProduct.Rows[e.RowIndex].Cells[1].Value);
                quantity.productName = dgvProduct.Rows[e.RowIndex].Cells[2].Value.ToString();
                quantity.price = Convert.ToInt32(dgvProduct.Rows[e.RowIndex].Cells[3].Value);
                quantity.ShowDialog();
                return;
            }
        }

        public void AddCart(CartModel cart)
        {
            dgvCart.Rows.Add(cart.ProductId.ToString(), cart.ProductName.ToString(), cart.Price.ToString(), cart.Quantity.ToString(), cart.SubTotal.ToString());
        }

        public void ShowReceipt()
        {
            var dataTable = new DataTable();
            foreach (DataGridViewColumn column in dgvCart.Columns)
            {
                if (column.Name != "id" || column.Name != "delete")
                {
                    Type valueType = column.ValueType ?? typeof(string);
                    dataTable.Columns.Add(column.Name, valueType);
                }
            }

            foreach (DataGridViewRow row in dgvCart.Rows)
            {
                if (row.IsNewRow) continue;
                var dataRow = dataTable.NewRow();
                foreach (DataGridViewCell cell in row.Cells)
                {
                    if (cell.OwningColumn.Name != "id" || cell.OwningColumn.Name != "delete")
                    {
                        dataRow[cell.OwningColumn.Name] = cell.Value ?? DBNull.Value;
                    }
                }
                dataTable.Rows.Add(dataRow);
            }

            receipt.CreateReceipt(customerName, transactionDate.ToString(), transactionCode, totalPrice, totalPayment, change, dataTable);
        }

        private void UpdateStock()
        {
            Dictionary<int, int> productQuantities = new Dictionary<int, int>();

            foreach (DataGridViewRow row in dgvCart.Rows)
            {
                if (row.Cells["id"].Value != null && row.Cells["qty"].Value != null)
                {
                    int productId = Convert.ToInt32(row.Cells["id"].Value);
                    int quantity = Convert.ToInt32(row.Cells["qty"].Value);

                    productQuantities[productId] = quantity;
                }
            }
            DBProducts dBProducts = new DBProducts();
            foreach (var item in productQuantities)
            {
                dBProducts.UpdateStock(item.Key, item.Value);
            }
        }

        private void checkoutButton_Click(object sender, EventArgs e)
        {
            DateTime now = DateTime.Now;
            DateTimeOffset dateTimeOffset = new DateTimeOffset(now);
            long unixTimestamp = dateTimeOffset.ToUnixTimeSeconds();
            totalPrice = 0;
            foreach (DataGridViewRow row in dgvCart.Rows)
            {
                totalPrice += Convert.ToInt32(row.Cells["subtotal"].Value);
            }

            transactionDate = now;
            transactionCode = "T-"+unixTimestamp.ToString();
            customerName = txtCustName.Text;
            totalPayment = Convert.ToInt32(txtTotalPayment.Text);
            change = totalPayment - totalPrice;

            TransactionModel transaction = new TransactionModel(transactionCode, Convert.ToInt32(UserSession.Id), customerName, totalPrice, totalPayment, change, transactionDate);
            DBTransaction dBTransaction = new DBTransaction();
            dBTransaction.AddTransaction(transaction);
            foreach (DataGridViewRow row in dgvCart.Rows)
            {
                TransactionItemModel transactionItem = new TransactionItemModel(transactionCode, Convert.ToInt32(row.Cells["id"].Value), Convert.ToInt32(row.Cells["qty"].Value), Convert.ToInt32(row.Cells["subtotal"].Value));
                DBTransactionItem dBTransactionItem = new DBTransactionItem();
                dBTransactionItem.AddItem(transactionItem);
            }

            UpdateStock();
            ShowReceipt();
            receipt.ShowDialog();
            Clear();
            Display();
        }

        private void dgvCart_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dgvCart.Columns["delete"].Index && e.RowIndex >= 0)
            {
                if (MessageBox.Show("Apakah anda yakin ingin menghapus data ini?", "Hapus Data", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    totalPrice -= Convert.ToInt32(dgvCart.Rows[e.RowIndex].Cells[4].Value);
                    txtTotalPrice.Text = totalPrice.ToString();
                    dgvCart.Rows.RemoveAt(e.RowIndex);
                }
                return;
            }
        }
    }
}
