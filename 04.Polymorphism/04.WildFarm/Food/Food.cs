using System;
using System.Collections.Generic;
using System.Text;

namespace _04.WildFarm.Food
{
    internal class Food : IFood
    {
        public Food(int quontity)
        {
            Quontity = quontity;
        }

        public int Quontity { get; set; }
    }
}
