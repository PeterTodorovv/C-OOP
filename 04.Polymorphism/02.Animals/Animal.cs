﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Animals
{
    public class Animal
    {
        public Animal(string name, string favoriteFood)
        {
            Name = name;
            FavoriteFood = favoriteFood;
        }

        public string Name { get; private set; }
        public string FavoriteFood { get; private set; }

        public virtual string ExplainSelf()
        {
            return $"I am {this.Name} and my fovourite food is {this.FavoriteFood}";
        }
    }
}
