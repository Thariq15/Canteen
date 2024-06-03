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
    public partial class Receipt : Form
    {
        private readonly ShopForm _shopForm;

        public Receipt(ShopForm shopForm)
        {
            InitializeComponent();
            _shopForm = shopForm;
        }

        public void CreateReceipt(string name, string date, string code, int price, int payment, int change, DataTable dataTable)
        {
            labelName.Text = ": " + name;
            labelDate.Text = ": " + date;
            labelCode.Text = ": " + code;
            txtTotalPrice.Text = price.ToString();
            txtTotalPayment.Text = payment.ToString();
            txtChange.Text = change.ToString();
            dgvCart.DataSource = dataTable;
        }

        public void DetailReceipt(string code)
        {
            DBTransaction dBTransaction = new DBTransaction();
            TransactionModel transaction = dBTransaction.GetTransaction(code);
            labelName.Text = ": " + transaction.CustomerName;
            labelDate.Text = ": " + transaction.TransactionDate;
            labelCode.Text = ": " + transaction.TransactionCode;
            txtTotalPrice.Text = transaction.TotalPrice.ToString();
            txtTotalPayment.Text = transaction.TotalPayment.ToString();
            txtChange.Text = transaction.Change.ToString();
            DBTransactionItem dBTransactionItem = new DBTransactionItem();
            dBTransactionItem.FillReceipt(code, dgvCart);
        }
    }
}
