using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Gym.Models.Gyms
{
    internal class WeightliftingGym : Gym
    {
        public WeightliftingGym(string name) : base(name, 20)
        {
        }

        public override void Exercise()
        {
            foreach (var athlete in Athletes.Where(a => a.GetType().Name == "Weightlifter"))
            {
                athlete.Exercise();
            }
        }
    }
}
