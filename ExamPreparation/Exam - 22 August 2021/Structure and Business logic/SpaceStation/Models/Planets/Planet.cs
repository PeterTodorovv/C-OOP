using SpaceStation.Models.Planets.Contracts;
using SpaceStation.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Text;

namespace SpaceStation.Models.Planets
{
    public class Planet : IPlanet
    {
        private string name;
        private List<string> _Items;

        public Planet(string name)
        {
            Name = name;
            _Items = new List<string>();
        }

        public ICollection<string> Items => _Items;

        public string Name { get => name; private set 
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException(ExceptionMessages.InvalidPlanetName);
                }

                name = value;
            }
        }
    }
}
