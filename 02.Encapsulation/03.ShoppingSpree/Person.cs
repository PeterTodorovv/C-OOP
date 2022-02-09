using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _03.ShoppingSpree
{
    class Person
    {
        private string name;
        private decimal money;
        private List<Product> BagOfProducts;

        public Person(string name, decimal money)
        {
            Name = name;
            Money = money;
            BagOfProducts = new List<Product>();
        }

        public string Name { get => name; private set 
            {
                if(string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Name cannot be empty");
                }
                else
                {
                    name = value;
                }
            }
        }
        public decimal Money { get => money;private set 
            {
                if(value < 0)
                {
                    throw new ArgumentException("Money cannot be negative");
                }
                else
                {
                    money = value;
                }
            }
        }


        public void BuyProduct(Product product)
        {
            if(product.Cost <= money)
            {
                money -= product.Cost;
                BagOfProducts.Add(product);
                Console.WriteLine($"{Name} bought {product.Name}");
            }
            else
            {
                Console.WriteLine($"{Name} can't afford {product.Name}");
            }
        }

        public override string ToString()
        {
            List<string> products = new List<string>();

            foreach(var product in BagOfProducts)
            {
                products.Add(product.Name);
            }

            if (BagOfProducts.Count != 0)
            {
                return $"{Name} - {string.Join(", ", products)}".Trim();
            }
            return $"{Name} - Nothing bought".Trim();
        }
    }
}
