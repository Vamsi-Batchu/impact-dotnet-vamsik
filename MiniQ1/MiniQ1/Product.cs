using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniQ1
{
    public class Product
    {
        public string Name { get; set; }
        public double Price { get; set; }
        public Category Category { get; set; }

        public Product(string name, double price, Category category)
        {
            Name = name;
            Price = price;
            Category = category;
        }
    }
}
