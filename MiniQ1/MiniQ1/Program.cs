using MiniQ1;
using System;
using System.Linq;

namespace MiniQ1
{
    class Program
    {
        static void Main(string[] args)
        {
            Product[] products =
            {
                new Product("Laptop",60000,Category.Electronics),
                new Product("Mobile",30000,Category.Electronics),
                new Product("Rice",1200,Category.Grocery),
                new Product("Shirt",1500,Category.Clothing),
                new Product("Jeans",2500,Category.Clothing)
            };

            var groupedProducts = products.GroupBy(p => p.Category);

            foreach (var group in groupedProducts)
            {
                Console.WriteLine($"Category : {group.Key}");

                foreach (var product in group)
                {
                    Console.WriteLine($"{product.Name} - ₹{product.Price}");
                }

                Console.WriteLine();
            }
        }
    }
}