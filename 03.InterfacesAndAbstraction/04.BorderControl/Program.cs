using System;
using System.Collections.Generic;
using System.Linq;

namespace _04.BorderControl
{
    public class Program
    {
        public static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            List<IBuyer> buyers = new List<IBuyer>();

            for(int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split(' ');

                if(input.Length == 4)
                {
                    string name = input[0];
                    int age = int.Parse(input[1]);
                    string id = input[2];
                    string birthdate = input[3];
                    buyers.Add(new Citizen(name, age, id, birthdate));
                }
                else if(input.Length == 3)
                {
                    string name = input[0];
                    int age = int.Parse(input[1]);
                    string group = input[2];
                    buyers.Add(new Rebel(name, age, group));
                }
            }

            string buyerName = Console.ReadLine();

            while(buyerName != "End")
            {
                if (buyers.Any(b => b.Name == buyerName))
                {
                    buyers.First(b => b.Name == buyerName).BuyFood();
                }
                buyerName = Console.ReadLine();
            }

            Console.WriteLine(buyers.Sum(b => b.Food));
        }
    }
}
