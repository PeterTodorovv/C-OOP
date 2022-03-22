using CarRacing.Models.Cars.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarRacing.Models.Cars
{
    public abstract class Car : ICar
    {
        private string make;
        private string model;
        private string vIN;
        private int horsePower;
        private double fuelAvailable;
        private double fuelConsumptionPerRace;

        protected Car(string make, string model, string vIN, int horsePower, double fuelAvailable, double fuelConsumptionPerRace)
        {
            Make = make;
            Model = model;
            VIN = vIN;
            HorsePower = horsePower;
            FuelAvailable = fuelAvailable;
            FuelConsumptionPerRace = fuelConsumptionPerRace;
        }

        public string Make
        {
            get => make; set
            {
                if (value == null || value == " ")
                {
                    throw new ArgumentNullException("Car make cannot be null or empty.");
                }
                else
                {
                    make = value;
                }
            }
        }
        public string Model
        {
            get => model; set
            {
                if (value == null || value == " ")
                {
                    throw new ArgumentNullException("Car model cannot be null or empty.");
                }
                else
                {
                    model = value;
                }
            }
        }

        public string VIN
        {
            get => vIN; set
            {
                if (value.Length != 17)
                {
                    throw new ArgumentException("Car VIN must be exactly 17 characters long.");
                }
            }
        }

        public int HorsePower
        {
            get => horsePower; set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Horse power cannot be below 0.");
                }
                else
                {
                    horsePower = value;
                }
            }
        }

        public double FuelAvailable { get => fuelAvailable; set 
            {
                if(value < 0)
                {
                    fuelAvailable = 0;
                }
                else
                {
                    fuelAvailable = value;
                }
            }
        }

        public double FuelConsumptionPerRace { get => fuelConsumptionPerRace; set 
            {
                if(value < 0)
                {
                    throw new ArgumentException("Fuel consumption cannot be below 0.");
                }
            }
        }

        public virtual void Drive()
        {
            FuelAvailable -= FuelConsumptionPerRace;
        }
    }
}
