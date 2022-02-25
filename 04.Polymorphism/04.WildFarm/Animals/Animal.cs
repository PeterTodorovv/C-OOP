using System;
using System.Collections.Generic;
using System.Text;

namespace _04.WildFarm.Animals
{
    internal abstract class Animal : IAnimal
    {
        public Animal(string name, double weight)
        {
            Name = name;
            Weight = weight;
            AskForFood();
        }

        public string Name { get; set; }
        public double Weight { get; set; }
        public int FoodEaten { get; set; }
        public abstract double WeightToGain { get; }

        public abstract void AskForFood();


        public abstract bool CanEatThis(IFood food);

        public void Eat(IFood food)
        {
            Weight += food.Quontity * WeightToGain;
            FoodEaten += food.Quontity;
        }
    }
}
