using System;

namespace _02.Vehicles2._0
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] carInfo = Console.ReadLine().Split(' ');
            double cFuel = double.Parse(carInfo[1]);
            double cFuelConsumprion = double.Parse(carInfo[2]);
            double cTankCapacity = double.Parse(carInfo[3]);
            Car car = new Car(cFuel, cFuelConsumprion, cTankCapacity);

            string[] truckInfo = Console.ReadLine().Split(' ');
            double tFuel = double.Parse(truckInfo[1]);
            double tFuelConsumprion = double.Parse(truckInfo[2]);
            double tTankCapacity = double.Parse(truckInfo[3]);
            Truck truck = new Truck(tFuel, tFuelConsumprion, tTankCapacity);

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split(' ');
                string command = input[0];
                string vehickeType = input[1];

                if (command == "Drive")
                {
                    double distance = double.Parse(input[2]);
                    if (vehickeType == "Car")
                    {
                        car.Drive(distance);
                    }
                    else if (vehickeType == "Truck")
                    {
                        truck.Drive(distance);
                    }
                }
                else if (command == "Refuel")
                {
                    double fuel = double.Parse(input[2]);
                    if (vehickeType == "Car")
                    {
                        car.Refil(fuel);
                    }
                    else if (vehickeType == "Truck")
                    {
                        truck.Refil(fuel);
                    }
                }
            }
        }
    }
}
