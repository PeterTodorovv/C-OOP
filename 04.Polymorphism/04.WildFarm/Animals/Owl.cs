using _04.WildFarm.Food;
using System;
using System.Collections.Generic;
using System.Text;

namespace _04.WildFarm.Animals
{
    internal class Owl : Bird
    {
        public Owl(string name, double weight,  double wingSize) : base(name, weight, wingSize)
        {
        }

        public override double WeightToGain => 0.25;

        public override void AskForFood()
        {
            Console.WriteLine("Hoot Hoot");
        }

        public override bool CanEatThis(IFood food)
        {
            return food is Meat;
        }

        public override string ToString()
        {
            return $"Owl [{Name}, {WingSize}, {Weight}, {FoodEaten}]";
        }
    }
}
