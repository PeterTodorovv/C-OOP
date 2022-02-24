using System;
using System.Collections.Generic;
using System.Text;

namespace _02.Vehicles2._0
{
    internal class Truck : Vehicle
    {
        public Truck(double fuel, double fuelConsumption, double tankCapacity) : base(fuel, fuelConsumption, tankCapacity)
        {
        }

        public override void Drive(double distance)
        {
            if (CanDrive(distance))
            {
                Fuel -= distance * 1.6;
                base.Drive(distance);
                Console.WriteLine($"Truck travelled {distance} km");
            }
            else
            {
                Console.WriteLine("Truck needs refueling");
            }
        }

        public override void Refil(double amountFuel)
        {
            amountFuel = amountFuel * 0.95;
            base.Refil(amountFuel);
        }
    }
}
