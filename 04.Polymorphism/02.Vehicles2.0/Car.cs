using System;
using System.Collections.Generic;
using System.Text;

namespace _02.Vehicles2._0
{
    internal class Car : Vehicle
    {
        public Car(double fuel, double fuelConsumption, double tankCapacity) : base(fuel, fuelConsumption, tankCapacity)
        {
        }

        public override void Drive(double distance)
        {
            if (CanDrive(distance))
            {
                Fuel -= distance * 0.9;
                base.Drive(distance);
                Console.WriteLine($"Car travelled {distance} km");
            }
            else
            {
                Console.WriteLine("Car needs refueling");
            }
        }
    }
}
