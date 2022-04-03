using Gym.Core.Contracts;
using Gym.Models.Athletes;
using Gym.Models.Athletes.Contracts;
using Gym.Models.Equipment;
using Gym.Models.Equipment.Contracts;
using Gym.Models.Gyms;
using Gym.Models.Gyms.Contracts;
using Gym.Repositories;
using Gym.Repositories.Contracts;
using Gym.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Gym.Core
{
    internal class Controller : IController
    {

        private IRepository<IEquipment> equipment = new EquipmentRepository(); 
        private List<IGym> gyms = new List<IGym>();
        public string AddAthlete(string gymName, string athleteType, string athleteName, string motivation, int numberOfMedals)
        {
            IAthlete athlete;
            IGym gym = gyms.First(g => g.Name == gymName);

            if(athleteType == "Boxer")
            {
                athlete = new Boxer(athleteName, motivation, numberOfMedals);
            }
            else if(athleteType == "Weightlifter")
            {
                athlete = new Weightlifter(athleteName, motivation, numberOfMedals);
            }
            else
            {
                throw new InvalidOperationException(ExceptionMessages.InvalidAthleteType);
            }

            if((gym is BoxingGym && athlete is Weightlifter) || (gym is WeightliftingGym && athlete is Boxer))
            {
                return "The gym is not appropriate.";
            }

            gym.AddAthlete(athlete);
            return $"Successfully added {athleteType} to {gymName}.";
        }

        public string AddEquipment(string equipmentType)
        {
            IEquipment equipmentObject;

            if (equipmentType == "Kettlebell")
            {
                equipmentObject = new Kettlebell();
                equipment.Add(equipmentObject);
            }
            else if (equipmentType == "BoxingGloves")
            {
                equipmentObject = new BoxingGloves();
                equipment.Add(equipmentObject);
            }
            else
            {
                throw new InvalidOperationException(ExceptionMessages.InvalidEquipmentType);
            }

            return $"Successfully added {equipmentType}.";
        }

        public string AddGym(string gymType, string gymName)
        {
            IGym gym;

            if(gymType == "BoxingGym")
            {
                gym = new BoxingGym(gymName);
                gyms.Add(gym);
            }
            else if(gymType == "WeightliftingGym")
            {
                gym = new WeightliftingGym(gymName);
                gyms.Add(gym);
            }
            else
            {
                throw new InvalidOperationException(ExceptionMessages.InvalidGymType);
            }

            return $"Successfully added {gymType}.";
        }

        public string EquipmentWeight(string gymName)
        {
            IGym gym = gyms.First(g => g.Name == gymName);
            return $"The total weight of the equipment in the gym {gymName} is {gym.EquipmentWeight:f2} grams.";
        }

        public string InsertEquipment(string gymName, string equipmentType)
        {
            IEquipment equipmentObject = equipment.FindByType(equipmentType);

            if(equipmentObject == null)
            {
                throw new InvalidOperationException(ExceptionMessages.InexistentEquipment);
            }

            IGym gym = gyms.First(g => g.Name == gymName);
            gym.AddEquipment(equipmentObject);
            equipment.Remove(equipmentObject);
            return $"Successfully added {equipmentType} to {gymName}.";

        }

        public string Report()
        {
            StringBuilder stringBuilder = new StringBuilder();

            foreach(var gym in gyms)
            {
                stringBuilder.AppendLine(gym.GymInfo());
            }

            return stringBuilder.ToString().TrimEnd();
        }

        public string TrainAthletes(string gymName)
        {
            IGym gym = gyms.First(g => g.Name == gymName);
            gym.Exercise();

            return $"Exercise athletes: {gym.Athletes.Count}.";
        }
    }
}
