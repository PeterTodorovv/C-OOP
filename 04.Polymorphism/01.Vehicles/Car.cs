using System;
using System.Collections.Generic;
using System.Text;

namespace _01.Vehicles
{
    internal class Car : Vehicle
    {
        public Car(double tankCapacity, double fuelConsumption, double fuelQuantity) : base(tankCapacity, fuelConsumption, fuelQuantity)
        {
        }

        public override double FuelConsumption => base.FuelConsumption + 0.9;

    }
}
