using System;
using System.Collections.Generic;
using System.Text;

namespace _01.Vehicles
{
    internal class Vehicle : IVehicle
    {
        private double fuelQuantity;
        private double fuelConsumption;
        private double tankCapacity;

        public Vehicle(double fuelQuantity, double fuelConsumption, double tankCapacity)
        {
            TankCapacity = tankCapacity;
            FuelQuantity = fuelQuantity;
            FuelConsumption = fuelConsumption;
            IsEmpty = false;
        }

        public double FuelQuantity
        {
            get => fuelQuantity; set
            {
                if (value <= TankCapacity)
                {
                    fuelQuantity = value;
                }
                else
                {
                    fuelQuantity = 0;
                }
            }
        }
        public virtual double FuelConsumption { get => fuelConsumption; set => fuelConsumption = value; }
        public double TankCapacity { get => tankCapacity; set => tankCapacity = value; }
        public bool IsEmpty { get; set; }

        public bool CanBeDriven(double km)
        {
            return fuelQuantity >= km * FuelConsumption;
        }

        public virtual bool HaveEnoughSpace(double liters)
        {
            return tankCapacity >= liters + fuelQuantity;
        }

        public virtual void Drive(double km)
        {
            this.FuelQuantity -= km * FuelConsumption;
        }

        public virtual void Refuel(double fuel)
        {
            if(fuel <= 0)
            {
                Console.WriteLine("Fuel must be a positive number");
            }
            else
            {
                this.FuelQuantity += fuel;
            }
        }
    }
}
