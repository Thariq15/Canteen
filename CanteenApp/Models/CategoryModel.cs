using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CanteenApp.Models
{
    internal class CategoryModel
    {
        public string Name { get; set; }

        public CategoryModel(string name)
        {
            Name = name;
        }
    }
}
