using System;
using System.Collections.Generic;
using System.Text;

namespace SpaceStation.Models.Astronauts.Contracts
{
    public class Biologist : Astronaut
    {
        public Biologist(string name) : base(name, 70)
        {
        }

        public override void Breath()
        {
            Oxygen -= 5;
            if (Oxygen - 5 < 0)
            {
                Oxygen = 0;
            }
        }

        public override bool CanBreath => Oxygen >= 5;
    }
}
