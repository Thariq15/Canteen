using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CanteenApp.Models
{
    public class CartModel
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; } = string.Empty;
        public int Price { get; set; }
        public int Quantity { get; set; }
        public int SubTotal { get; set; }

        public CartModel(int productId, string productName, int price, int quantity, int subTotal)
        {
            ProductId = productId;
            ProductName = productName;
            Price = price;
            Quantity = quantity;
            SubTotal = subTotal;
        }
    }
}
