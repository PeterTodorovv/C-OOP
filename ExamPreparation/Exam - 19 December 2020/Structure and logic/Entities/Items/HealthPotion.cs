using System;
using System.Collections.Generic;
using System.Text;
using WarCroft.Entities.Characters.Contracts;

namespace WarCroft.Entities.Items
{
    internal class HealthPotion : Item
    {
        public HealthPotion() : base(5)
        {
        }

        public void AffectCharacter(Character character)
        {
            if (character.IsAlive)
            {
            }
        }
    }
}
