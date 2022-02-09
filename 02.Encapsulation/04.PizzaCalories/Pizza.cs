using System;
using System.Collections.Generic;
using System.Text;

namespace _04.PizzaCalories
{
    class Pizza
    {
        private double calories;

        public Pizza(string name, Dough dough)
        {
            Name = name;
            this.Dough = dough;
            toppings = new List<Topping>();
        }

        public string Name { get => name; private set 
            {
                if (string.IsNullOrEmpty(value) || value.Length > 15)
                {
                    throw new ArgumentException("Pizza name should be between 1 and 15 symbols.");
                }
                else
                {
                    name = value;
                }
            }
        }
        private Dough Dough;
        private List<Topping> toppings;
        private string name;

        public int NumberOfToppings { get {

                return toppings.Count; }
        }
        public double Calories
        {
            get
            {
                calories = Dough.Calories;

                foreach (var topping in toppings)
                {
                    calories += topping.Calories;
                }
                return calories;
            }
        }

        public void AddTopping(Topping topping)
        {
            toppings.Add(topping);
            if (toppings.Count > 10)
            {
                throw new Exception("Number of toppings should be in range [0..10].");
            }
        }

    }
}
