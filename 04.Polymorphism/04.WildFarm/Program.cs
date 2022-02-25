using _04.WildFarm.Animals;
using _04.WildFarm.Food;
using System;
using System.Collections.Generic;

namespace _04.WildFarm
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split(' ');
            List<IAnimal> animals = new List<IAnimal>();

            while(input[0] != "End")
            {
                string animalType = input[0];
                string name = input[1];
                double weight = double.Parse(input[2]);
                IAnimal animal;

                if(animalType == "Hen")
                {
                    double wingSize = double.Parse(input[3]);
                    animal = new Hen(name, weight, wingSize);
                }
                else if(animalType == "Owl")
                {
                    double wingSize = double.Parse(input[3]);
                    animal = new Owl(name, weight, wingSize);
                }
                else if (animalType == "Mouse")
                {
                    string livingRegion = input[3];
                    animal = new Mouse(name, weight, livingRegion);
                }
                else if(animalType == "Dog")
                {
                    string livingRegion = input[3];
                    animal = new Dog(name, weight, livingRegion);
                }
                else if(animalType == "Cat")
                {
                    string livingRegion = input[3];
                    string breed = input[4];
                    animal = new Cat(name, weight, livingRegion, breed);
                }
                else
                {
                    string livingRegion = input[3];
                    string breed = input[4];
                    animal = new Tiger(name, weight, livingRegion, breed);
                }
                animals.Add(animal);

                IFood food;
                string[] foodInput = Console.ReadLine().Split(' ');
                string foodType = foodInput[0];
                int foodQuontity = int.Parse(foodInput[1]);

                if (foodType == "Vegetable")
                {
                    food = new Vegetable(foodQuontity);
                }
                else if(foodType == "Fruit")
                {
                    food = new Fruit(foodQuontity);
                }
                else if (foodType == "Meat")
                {
                    food = new Meat(foodQuontity);
                }
                else
                {
                    food = new Seeds(foodQuontity);
                }

                if (animal.CanEatThis(food))
                {
                    animal.Eat(food);
                }
                else
                {
                    Console.WriteLine($"{animalType} does not eat {foodType}!");
                }

                input = Console.ReadLine().Split(' ');
            }

            foreach(var animal in animals)
            {
                Console.WriteLine(animal.ToString());
            }
        }
    }
}
