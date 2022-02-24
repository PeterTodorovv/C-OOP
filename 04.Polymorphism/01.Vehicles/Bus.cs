using System;
using System.Collections.Generic;
using System.Text;

namespace _01.Vehicles
{
    internal class Bus : Vehicle
    {
        public Bus(double tankCapacity, double fuelConsumption, double fuelQuantity) : base(tankCapacity, fuelConsumption, fuelQuantity)
        {
        }

        public override void Drive(double km)
        {
            if (IsEmpty)
            {
                base.Drive(km);
            }
            else
            {
                FuelConsumption = base.FuelConsumption + 1.4;
                base.Drive(km);
            }
        }
    }
}
