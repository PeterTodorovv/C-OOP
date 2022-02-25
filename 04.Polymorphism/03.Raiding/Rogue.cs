using System;
using System.Collections.Generic;
using System.Text;

namespace _03.Raiding
{
    internal class Rogue : BaseHero
    {
        private const int cPower = 80;
        public Rogue(string name) : base(name)
        {
            Power = cPower;
        }

        public override string CastAbility()
        {
            return $"Rouge - {Name} hit for {Power} damage";
        }
    }
}
