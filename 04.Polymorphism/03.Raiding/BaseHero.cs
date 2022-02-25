using System;
using System.Collections.Generic;
using System.Text;

namespace _03.Raiding
{
    internal abstract class BaseHero : IBaseHero
    {
        protected BaseHero(string name)
        {
            Name = name;
        }

        protected BaseHero()
        {
        }

        public string Name { get; set; }
        public int Power { get; set; }

        public virtual string CastAbility()
        {
            return "";
        }
    }
}
