using System;
using System.Collections.Generic;
using System.Text;

namespace _02.Vehicles2._0
{
    internal abstract class Vehicle
    {
        protected Vehicle(double fuel, double fuelConsumption, double tankCapacity)
        {
            Fuel = fuel;
            FuelConsumption = fuelConsumption;
            TankCapacity = tankCapacity;
        }

        public double Fuel { get;  set; }
        public double FuelConsumption { get; private set; }
        public double TankCapacity { get; private set; }

        public virtual void Drive(double distance)
        {
             Fuel -= distance * FuelConsumption;
        }

        public virtual void Refil(double amountFuel)
        {
            Fuel += amountFuel;
        }

        internal bool CanDrive(double distance)
        {
            return distance * FuelConsumption <= TankCapacity;
        }
    }
}
