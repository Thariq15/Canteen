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
    public partial class Quantity : Form
    {
        private readonly ShopForm _shopForm;
        public string transactionCode, customerName, productName;
        public DateTime transactionDate;
        public int adminId, totalPrice, totalPayment, change, productId, price, quantity, subTotal;
        public Quantity(ShopForm shopForm)
        {
            InitializeComponent();
            _shopForm = shopForm;
        }

        public void Clear()
        {
            txtQty.Text = string.Empty;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            quantity = Convert.ToInt32(txtQty.Text);
            subTotal = price * quantity;
            CartModel cart = new CartModel(productId, productName, price, quantity, subTotal);
            _shopForm.AddCart(cart);
            _shopForm.UpdateTotalPrice(subTotal);
            Clear();
        }


    }
}
