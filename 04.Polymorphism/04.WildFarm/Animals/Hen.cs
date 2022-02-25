using System;
using System.Collections.Generic;
using System.Text;

namespace _04.WildFarm.Animals
{
    internal class Hen : Bird
    {

        public Hen(string name, double weight, double wingSize) : base(name, weight,  wingSize)
        {
        }

        public override double WeightToGain => 0.35;

        public override void AskForFood()
        {
            Console.WriteLine("Cluck");
        }

        public override bool CanEatThis(IFood food)
        {
            return true;
        }

        public override string ToString()
        {
            return $"Hen [{Name}, {WingSize}, {Weight}, {FoodEaten}]";
        }
    }
}
