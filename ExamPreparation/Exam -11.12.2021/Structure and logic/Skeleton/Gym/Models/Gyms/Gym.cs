using Gym.Models.Athletes.Contracts;
using Gym.Models.Equipment.Contracts;
using Gym.Models.Gyms.Contracts;
using Gym.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Gym.Models.Gyms
{
    internal abstract class Gym : IGym
    {
        private string name;
        private List<IEquipment> equipment;
        private List<IAthlete> athletes;

        public Gym(string name, int capacity)
        {
            Name = name;
            Capacity = capacity;
            equipment = new List<IEquipment>();
            athletes = new List<IAthlete>();
        }

        public string Name { get => name; private set 
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException(ExceptionMessages.InvalidGymName);
                }
                name = value;
            }
        }

        public int Capacity { get; private set; }

        public double EquipmentWeight => equipment.Sum( e => e.Weight );

        public ICollection<IEquipment> Equipment => equipment;

        public ICollection<IAthlete> Athletes => athletes;

        public void AddAthlete(IAthlete athlete)
        {
            if(Capacity < athletes.Count)
            {
                athletes.Add(athlete);
            }
            else
            {
                throw new InvalidOperationException(ExceptionMessages.NotEnoughSize);
            }
        }

        public void AddEquipment(IEquipment equipment)
        {
            this.equipment.Add(equipment);
        }

        public abstract void Exercise();

        public string GymInfo()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"{this.Name} is a {GetType().Name}:");

            if(athletes.Count > 0)
            {
                sb.AppendLine($"Athletes: {string.Join(", ", athletes)}");
            }
            else
            {
                sb.AppendLine("Athletes: No athletes");
            }

            sb.AppendLine($"Equipment total count: {equipment.Count}");
            sb.AppendLine($"Equipment total weight: {EquipmentWeight} grams");
            return sb.ToString().TrimEnd();
        }

        public bool RemoveAthlete(IAthlete athlete)
        {
            return athletes.Remove(athlete);
        }
    }
}
