using System;
using System.Collections.Generic;
using System.Text;

namespace _01.Vehicles
{
    internal class Truck : Vehicle
    {
        public Truck(double tankCapacity, double fuelConsumption, double fuelQuantity) : base(tankCapacity, fuelConsumption, fuelQuantity)
        {
        }

        public override double FuelConsumption => base.FuelConsumption + 1.6;

        public override void Refuel(double fuel)
        {
            fuel *= 0.95;
            base.Refuel(fuel);
        }
    }
}
