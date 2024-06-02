using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CanteenApp.Models
{
    internal class TransactionModel
    {
        public string TransactionCode { get; set; }

        public int AdminId { get; set; }

        public string CustomerName { get; set; }

        public int TotalPrice { get; set; }

        public int TotalPayment { get; set; }

        public int Change { get; set; }

        public DateTime TransactionDate { get; set; }

        public TransactionModel(string transactionCode, int adminId, string customerName, int totalPrice, int totalPayment, int change, DateTime transactionDate)
        {
            TransactionCode = transactionCode;
            AdminId = adminId;
            CustomerName = customerName;
            TotalPrice = totalPrice;
            TotalPayment = totalPayment;
            Change = change;
            TransactionDate = transactionDate;
        }
    }
}
