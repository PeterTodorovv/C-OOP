using System;
using System.Collections.Generic;

namespace _03.ShoppingSpree
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Person> people = new Dictionary<string, Person>();
            Dictionary<string, Product> products = new Dictionary<string, Product>();
            string[] inputPeople = Console.ReadLine().Split(";", StringSplitOptions.RemoveEmptyEntries);
            string[] inputProducts = Console.ReadLine().Split(";", StringSplitOptions.RemoveEmptyEntries);

            foreach (var person in inputPeople)
            {
                string[] values = person.Split("=", StringSplitOptions.RemoveEmptyEntries);
                try
                {
                    people.Add(values[0], new Person(values[0], decimal.Parse(values[1])));
                }
                catch(ArgumentException ae)
                {
                    Console.WriteLine(ae.Message);
                    return;
                }
            }

            foreach (var product in inputProducts)
            {
                string[] values = product.Split("=", StringSplitOptions.RemoveEmptyEntries);
                try
                {
                    products.Add(values[0], new Product(values[0], decimal.Parse(values[1])));
                }
                catch(ArgumentException ae)
                {
                    Console.WriteLine(ae.Message);
                    return;
                }
            }

            string[] input = Console.ReadLine().Split();
            
            while(input[0] != "END")
            {
                Person person = people[input[0]];
                Product product = products[input[1]];
                person.BuyProduct(product);

                input = Console.ReadLine().Split();
            }

            foreach(var person in people.Values)
            {
                Console.WriteLine(person.ToString());
            }
        }
    }
}
