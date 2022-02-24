using System;
using System.Collections.Generic;
using System.Text;

namespace _01.Vehicles
{
    internal interface IVehicle
    {
        public double FuelQuantity { get; set; }
        public double FuelConsumption { get; set; }
        public double TankCapacity { get; set; }
        public bool IsEmpty { get; set; }

        public void Drive(double km);
        public void Refuel(double fuel);
        public bool CanBeDriven(double km); 
        public bool HaveEnoughSpace(double liters);
    }
}
