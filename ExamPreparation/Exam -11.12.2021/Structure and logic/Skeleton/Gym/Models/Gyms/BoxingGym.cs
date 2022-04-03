using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Gym.Models.Gyms
{
    internal class BoxingGym : Gym
    {
        public BoxingGym(string name) : base(name, 15)
        {
        }

        public override void Exercise()
        {
            foreach(var athlete in Athletes.Where(a => a.GetType().Name == "Boxer"))
            {
                athlete.Exercise();
            }
        }
    }
}
