using System;

using WarCroft.Constants;
using WarCroft.Entities.Inventory;

namespace WarCroft.Entities.Characters.Contracts
{
    public abstract class Character
    {
		// TODO: Implement the rest of the class.

		public bool IsAlive { get; set; } = true;

		public Character(string name, double health, double armor, double abilityPoints, IBag bag)
        {

        }
		protected void EnsureAlive()
		{
			if (!this.IsAlive)
			{
				throw new InvalidOperationException(ExceptionMessages.AffectedCharacterDead);
			}
		}

		public string Name { get; set; }
		public double BaseHealth { get; set; }
		public double Health { get; set; }
		public double BaseArmor { get; set; }
		public double Armor { get; set; }
		public double AbilityPoints { get; set; }
		IBag bag;
	}
}