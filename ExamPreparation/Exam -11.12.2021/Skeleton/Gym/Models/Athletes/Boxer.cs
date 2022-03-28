using System;
using System.Collections.Generic;
using System.Text;

namespace Gym.Models.Athletes
{
    internal class Boxer : Athlete
    {
        public Boxer(string fullName, string motivation, int numberOfMedals) : base(fullName, motivation, numberOfMedals, 60)
        {
        }

        public override void Exercise()
        {
            Stamina += 15;
            base.Exercise();
        }
    }
}
