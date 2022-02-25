using System;
using System.Collections.Generic;
using System.Text;

namespace _03.Raiding
{
    internal class Druid : BaseHero
    {
        private const int cPower = 80;

        public Druid(string name) : base(name)
        {
            Power = cPower;
        }

        public override string CastAbility()
        {
            return $"Druid - {Name} healed for {Power}";
        }
    }
}
