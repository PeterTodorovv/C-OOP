using System;
using System.Collections.Generic;
using System.Text;

namespace Restaurant
{
    public class Cake : Dessert
    {
        public const decimal CakePrice = 5;
        public const double CakeGrams = 250;
        private const double CakeCalories = 1000;
        public Cake(string name) : base(name, CakePrice, CakeGrams, CakeCalories)
        {
        }

        
    }
}
