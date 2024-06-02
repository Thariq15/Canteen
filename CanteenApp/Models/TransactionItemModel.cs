using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CanteenApp.Models
{
    internal class TransactionItemModel
    {
        public string TransactionCode { get; set; }

        public int ProductId { get; set; }

        public int Quantity { get; set; }

        public int SubTotal { get; set; }

        public TransactionItemModel(string transactionCode, int productId, int quantity, int subTotal)
        {
            TransactionCode = transactionCode;
            ProductId = productId;
            Quantity = quantity;
            SubTotal = subTotal;
        }
    }
}
