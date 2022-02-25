using System;

namespace _01.Vehicles
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] carInfo = Console.ReadLine().Split(' ');
            double cFuel = double.Parse(carInfo[1]);
            double cFuelConsumprion = double.Parse(carInfo[2]);
            double cTankCapacity = double.Parse(carInfo[3]);
            IVehicle car = new Car(cFuel, cFuelConsumprion, cTankCapacity);

            string[] truckInfo = Console.ReadLine().Split(' ');
            double tFuel = double.Parse(truckInfo[1]);
            double tFuelConsumprion = double.Parse(truckInfo[2]);
            double tTankCapacity = double.Parse(truckInfo[3]);
            IVehicle truck = new Truck(tFuel, tFuelConsumprion, tTankCapacity);

            string[] busInfo = Console.ReadLine().Split(' ');
            double bFuel = double.Parse(busInfo[1]);
            double bFuelConsumprion = double.Parse(busInfo[2]);
            double bTankCapacity = double.Parse(busInfo[3]);
            IVehicle bus = new Bus(bFuel, bFuelConsumprion, bTankCapacity);

            int n = int.Parse(Console.ReadLine());

            for(int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split(' ');
                string command = input[0];
                string vehickeType = input[1];

                if(command == "Drive")
                {
                    double distance = double.Parse(input[2]);
                    if(vehickeType == "Car")
                    {
                        if (car.CanBeDriven(distance))
                        {
                            car.Drive(distance);
                            Console.WriteLine($"Car travelled {distance} km");
                        }
                        else
                        {
                            Console.WriteLine("Car needs refueling");
                        }
                    }
                    else if(vehickeType == "Truck")
                    {
                        if (truck.CanBeDriven(distance))
                        {
                            truck.Drive(distance);
                            Console.WriteLine($"Truck travelled {distance} km");
                        }
                        else
                        {
                            Console.WriteLine("Truck needs refueling");
                        }
                    }
                    else if(vehickeType == "Bus")
                    {
                        if (bus.CanBeDriven(distance))
                        {
                            bus.IsEmpty = false;
                            bus.Drive(distance);
                            Console.WriteLine($"Bus travelled {distance} km");
                        }
                        else
                        {
                            Console.WriteLine("Bus needs refueling");
                        }
                    }
                }
                else if(command == "Refuel")
                {
                    double fuel = double.Parse(input[2]);
                    if (vehickeType == "Car")
                    {
                        if (car.HaveEnoughSpace(fuel))
                        {
                            car.Refuel(fuel);
                        }
                        else
                        {
                            Console.WriteLine($"Cannot fit {fuel} fuel in the tank");
                        }
                    }
                    else if (vehickeType == "Truck")
                    {
                        if (truck.HaveEnoughSpace(fuel))
                        {
                            truck.Refuel(fuel);
                        }
                        else
                        {
                            Console.WriteLine($"Cannot fit {fuel} fuel in the tank");
                        }
                    }
                    else if(vehickeType == "Bus")
                    {
                        if (bus.HaveEnoughSpace(fuel))
                        {
                            bus.Refuel(fuel);
                        }
                        else
                        {
                            Console.WriteLine($"Cannot fit {fuel} fuel in the tank");
                        }
                    }
                }
                else if(command == "DriveEmpty")
                {
                    bus.IsEmpty = true;
                    double distance = double.Parse(input[2]);

                    if (bus.CanBeDriven(distance))
                    {
                        bus.Drive(distance);
                        Console.WriteLine($"Bus travelled {distance} km");
                    }
                    else
                    {
                        Console.WriteLine("Bus needs refueling");
                    }
                }
            }

            Console.WriteLine($"Car: {car.FuelQuantity:f2}");
            Console.WriteLine($"Truck: {truck.FuelQuantity:f2}");
            Console.WriteLine($"Bus: {bus.FuelQuantity:f2}");
        }
    }
}
