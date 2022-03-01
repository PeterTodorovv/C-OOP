using _04.WildFarm.Food;
using System;
using System.Collections.Generic;
using System.Text;

namespace _04.WildFarm.Animals
{
    internal class Mouse : Mammal
    {
        public Mouse(string name, double weight, string livingRegion) : base(name, weight,  livingRegion)
        {
        }

        public override double WeightToGain => 0.10;

        public override void AskForFood()
        {
            Console.WriteLine("Squeak");
        }

        public override bool CanEatThis(IFood food)
        {
            return food is Vegetable || food is Fruit;
        }

        public override string ToString()
        {
            return $"Mouse [{Name}, {Weight}, {LivingRegion}, {FoodEaten}]";
        }
    }
}
