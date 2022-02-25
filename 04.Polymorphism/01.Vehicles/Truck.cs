using System;
using System.Collections.Generic;
using System.Text;

namespace _01.Vehicles
{
    internal class Truck : Vehicle
    {
        public Truck(double fuelQuantity, double fuelConsumption, double tankCapacity) : base(fuelQuantity, fuelConsumption, tankCapacity)
        {
        }

        public override double FuelConsumption => base.FuelConsumption + 1.6;

        public override void Refuel(double fuel)
        {
            fuel *= 0.95;
            base.Refuel(fuel);
        }

        public override bool HaveEnoughSpace(double liters)
        {
            liters *= 0.95;
            return base.HaveEnoughSpace(liters);
        }
    }
}
