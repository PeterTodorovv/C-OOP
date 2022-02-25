using System;
using System.Collections.Generic;
using System.Text;

namespace _03.Raiding
{
    internal interface IBaseHero
    {
        public string Name { get; set; }
        public int Power { get; set; }
        public string CastAbility();
    }
}
