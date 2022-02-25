using System;
using System.Collections.Generic;
using System.Text;

namespace _03.Raiding
{
    internal class Paladin : BaseHero
    {
        private const int cPower = 100;
        public Paladin(string name) : base(name)
        {
            Power = cPower;
        }

        public override string CastAbility()
        {
            return $"Paladin - {Name} healed for {Power}";
        }
    }
}
