using System;

namespace _04.PizzaCalories
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                string[] pizzaInput = Console.ReadLine().Split(" ");
                string pizzaName = pizzaInput[1];
                string[] doughInput = Console.ReadLine().Split(" ");
                Dough dough = new Dough(doughInput[1].ToLower(), doughInput[2].ToLower(), double.Parse(doughInput[3]));
                Pizza pizza = new Pizza(pizzaName, dough);
                string[] input = Console.ReadLine().Split(" ");

                while (input[0] != "END")
                {
                    Topping topping = new Topping(input[1], double.Parse(input[2]));
                    pizza.AddTopping(topping);
                    input = Console.ReadLine().Split();
                }

                Console.WriteLine($"{pizza.Name} - {pizza.Calories:f2} Calories.");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            
        }
    }
}
