using System;
using System.Collections.Generic;
using System.Text;

namespace _04.PizzaCalories
{
    class Dough
    {
        private const double BaseCaloriesPerGram = 2;

        private Dictionary<string, double> DoughTypes = new Dictionary<string, double>() 
        {
            { "white", 1.5}, {"wholegrain", 1 }
        };

        private Dictionary<string, double> CookingTechniques = new Dictionary<string, double>()
        {
            { "crispy", 0.9}, {"chewy", 1.1 }, {"homemade", 1}
        };

        private string doughType;
        private string cookingTechnique;
        private double weight;

        public Dough(string doughType, string cookingTechnique, double weight)
        {
            DoughType = doughType;
            CookingTechnique = cookingTechnique;
            Weight = weight;
        }

        private string DoughType { get => doughType; set 
            {
                if(DoughTypes.ContainsKey(value.ToLower()))
                {
                    doughType = value;
                }
                else
                {
                    throw new ArgumentException("Invalid type of dough.");
                }
            } 
        }
        private string CookingTechnique { get => cookingTechnique; set
            {
                if (CookingTechniques.ContainsKey(value.ToLower()))
                {
                    cookingTechnique = value;
                }
                else
                {
                    throw new ArgumentException("Invalid type of dough.");
                }
            }
        }
        private double Weight { get => weight; set 
            {
                if(value >= 1 && value <= 200)
                {
                    weight = value;
                }
                else
                {
                    throw new ArgumentException("Dough weight should be in the range [1..200].");
                }
            }
        }
        public double Calories { get {
                var calories = BaseCaloriesPerGram * Weight * DoughTypes[DoughType.ToLower()] * CookingTechniques[CookingTechnique.ToLower()];
                return calories;
            }
        }
    }
}
