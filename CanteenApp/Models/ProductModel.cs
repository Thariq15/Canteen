using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CanteenApp.Models
{
    internal class ProductModel
    {
        public string CategoryId { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
        public int Stock { get; set; }
        public string Description { get; set; }

        public string Image { get; set; }

        public ProductModel(string categoryId, string name, int price, int stock, string description, string image)
        {
            CategoryId = categoryId;
            Name = name;
            Price = price;
            Stock = stock;
            Description = description;
            Image = image;
        }
    }
}
