using System;
using System.Collections.Generic;
using System.Text;

namespace _04.WildFarm.Animals
{
    internal interface IAnimal
    {
        public string Name { get; set; }
        public double Weight { get; set; }
        public int FoodEaten { get; set; }
        public double WeightToGain { get; }

        public void AskForFood();
        public bool CanEatThis(IFood food);
        public void Eat(IFood food);
    }
}
