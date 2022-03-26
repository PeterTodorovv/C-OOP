using CarRacing.Models.Cars.Contracts;
using CarRacing.Models.Racers.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarRacing.Models.Racers
{
    public abstract class Racer : IRacer
    {
        private string username;
        private string racingBehavior;
        private int drivingExperience;
        private ICar car;

        protected Racer(string username, string racingBehavior, int drivingExperience, ICar car)
        {
        }

        public string Username { get => username; set
            {
                if (value == null || value == " ")
                {
                    throw new ArgumentNullException("Username cannot be null or empty.");
                }
                else
                {
                    username = value;
                }
            }
        }

        public string RacingBehavior
        {
            get => racingBehavior; set
            {
                if (value == null || value == " ")
                {
                    throw new ArgumentNullException("Racing behavior cannot be null or empty.");
                }
                else
                {
                    racingBehavior = value;
                }
            }
        }

        public int DrivingExperience { get => drivingExperience; set 
            {
                if(value < 0 || value > 100)
                {
                    throw new ArgumentException("Racer driving experience must be between 0 and 100.");
                }
                else
                {
                    drivingExperience = value;
                }
            }
        }

        public ICar Car { get => car; set 
            {
                if(value == null)
                {
                    throw new ArgumentException("Car cannot be null or empty.");
                }
                else
                {
                    car = value;
                }
            }
        }

        public bool IsAvailable()
        {
            return car.FuelAvailable >= car.FuelConsumptionPerRace;
        }

        public virtual void Race()
        {
            car.Drive();
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"{GetType().Name}: {Username}");
            sb.AppendLine($"--Driving behavior: {RacingBehavior}");
            sb.AppendLine($"--Driving experience: {DrivingExperience}");
            sb.AppendLine($"--Car: {car.Make} {car.Model} ({car.VIN})");

            return sb.ToString().TrimEnd();
        }
    }
}
