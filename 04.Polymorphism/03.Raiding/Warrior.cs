using System;
using System.Collections.Generic;
using System.Text;

namespace _03.Raiding
{
    internal class Warrior : BaseHero
    {
        private const int cPower = 100;
        public Warrior(string name) : base(name)
        {
            Power = cPower;
        }

        public override string CastAbility()
        {
            return $"Warrior - {Name} hit for {Power} damage";
        }
    }
}
