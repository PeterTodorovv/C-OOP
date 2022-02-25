using System;
using System.Collections.Generic;
using System.Text;

namespace _01.Vehicles
{
    internal class Bus : Vehicle
    {
        public Bus(double fuelQuantity, double fuelConsumption, double tankCapacity) : base(fuelQuantity, fuelConsumption, tankCapacity)
        {
           baseFuelConsumption = fuelConsumption;
        }

        private double baseFuelConsumption { get; set; }
        public override double FuelConsumption { get 
            {
                if (IsEmpty)
                {
                    return baseFuelConsumption;
                }
                return baseFuelConsumption + 1.4;
            }
        }
    }
}
