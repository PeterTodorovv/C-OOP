using System;
using System.Collections.Generic;
using System.Text;

namespace _04.PizzaCalories
{
    class Topping
    {

        private Dictionary<string, double> TypesOfToppings = new Dictionary<string, double>()
        {
            { "meat", 1.2 }, {"veggies", 0.8 }, {"cheese", 1.1}, {"sauce", 0.9}
        };

        private string type;
        private double weight;
        private double calories;

        public Topping(string type, double weight)
        {
            Type = type;
            Weight = weight;
        }
        private string Type { get => type; set 
            {
                if (TypesOfToppings.ContainsKey(value.ToLower()))
                {
                    type = value;
                }
                else
                {
                    throw new ArgumentException($"Cannot place {value} on top of your pizza.");
                }
            }
        }
        private double Weight
        {
            get => weight; set
            {
                if (value >= 1 && value <= 50)
                {
                    weight = value;
                }
                else
                {
                    throw new ArgumentException($"{type} weight should be in the range [1..50].");
                }
            }
        }

        public double Calories { get 
            {
                calories = 2 * Weight * TypesOfToppings[Type.ToLower()];
                return calories;
            }
        }
    }
}
