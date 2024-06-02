using CanteenApp.Controllers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CanteenApp.Pages
{
    public partial class HistoryForm : Form
    {
        public HistoryForm()
        {
            InitializeComponent();
        }

        public void Display()
        {
            DBTransaction dBTransaction = new DBTransaction();
            dBTransaction.DisplayAndSearch("SELECT * FROM transactions ORDER BY transaction_date DESC",dgvHistory);

        }

        private void HistoryForm_Shown(object sender, EventArgs e)
        {
            Display();
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            DBTransaction dBTransaction = new DBTransaction();
            dBTransaction.DisplayAndSearch("SELECT * FROM transactions WHERE transaction_code ILIKE '%" + txtSearch.Text + "%' OR customer_name ILIKE '%" + txtSearch.Text + "%' ORDER BY transaction_date DESC", dgvHistory);
        }
    }
}
