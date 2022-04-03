using Gym.Utilities.Messages;
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
            Stamina += 10;

            if(Stamina > 100)
            {
                throw new ArgumentException(ExceptionMessages.InvalidStamina);
                Stamina = 100;
            }
        }
    }
}
