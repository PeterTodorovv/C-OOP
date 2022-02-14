using System;
using System.Collections.Generic;

namespace _04.BorderControl
{
    public class Program
    {
        public static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split(' ');
            List<ICitizen> citizens = new List<ICitizen>();

            while (input[0] != "End")
            {
                if (input.Length == 2)
                {
                    string model =  input[0];
                    string id = input[1];
                    citizens.Add(new Robot(model, id));
                }
                else if (input.Length == 3)
                {
                    string name = input[0];
                    int age = int.Parse(input[1]);
                    string id = input[2];
                    citizens.Add(new Human(name, age, id));
                }

                input = Console.ReadLine().Split(' ');
            }


            string invalidIds = Console.ReadLine();

            foreach (var cirizen in citizens)
            {
                if (cirizen.Id.Substring(cirizen.Id.Length - invalidIds.Length) == invalidIds)
                {
                    Console.WriteLine(cirizen.Id);
                }
            }
        }
    }
}
