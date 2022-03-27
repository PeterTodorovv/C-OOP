using CarRacing.Core.Contracts;
using CarRacing.Models.Cars;
using CarRacing.Models.Maps;
using CarRacing.Models.Maps.Contracts;
using CarRacing.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using CarRacing.Models.Racers;
using CarRacing.Models.Cars.Contracts;
using CarRacing.Models.Racers.Contracts;

namespace CarRacing.Core
{
    internal class Controller : IController
    {
        CarRepository cars;
        RacerRepository racers;
        IMap map;

        public Controller()
        {
            cars = new CarRepository();
            racers = new RacerRepository();
            map = new Map();
        }

        public string AddCar(string type, string make, string model, string VIN, int horsePower)
        {
            if(type == "SuperCar")
            {
                cars.Add(new SuperCar(make, model, VIN, horsePower));
            }
            else if (type == "TunedCar")
            {
                cars.Add(new SuperCar(make, model, VIN, horsePower));

            }
            else
            {
                throw new ArgumentException("Invalid car type!");
            }

            return $"Successfully added car {make} {model} ({VIN}).";
        }

        public string AddRacer(string type, string username, string carVIN)
        {
            ICar car;
            IRacer racer;
            if (cars.FindBy(carVIN) == null)
            {
                throw new ArgumentException("Car cannot be found!");
            }
            else
            {
                car = cars.FindBy(carVIN);
            }

            if (type == "ProfessionalRacer")
            {
                racer = new ProfessionalRacer(username, car);
            }
            else if(type == "StreetRacer")
            {
                racer = new StreetRacer(username, car);
            }
            else
            {
                throw new ArgumentException("Invalid racer type!");
            }

            racers.Add(racer);
            return $"Successfully added racer {username}.";
        }

        public string BeginRace(string racerOneUsername, string racerTwoUsername)
        {
            IRacer racer1;
            IRacer racer2;

            if(racers.FindBy(racerOneUsername) != null)
            {
                racer1 = racers.FindBy(racerOneUsername);
            }
            else
            {
                throw new ArgumentException($"Racer {racerOneUsername} cannot be found!");
            }

            if (racers.FindBy(racerTwoUsername) != null)
            {
                racer2 = racers.FindBy(racerTwoUsername);
            }
            else
            {
                throw new ArgumentException($"Racer {racerTwoUsername} cannot be found!");
            }

            return map.StartRace(racer1, racer2);

        }

        public string Report()
        {
            StringBuilder txt = new StringBuilder();
            var racers = this.racers.Models.OrderByDescending(x => x.DrivingExperience).ThenBy(x => x.Username);

            foreach(var racer in racers)
            {
                txt.AppendLine(racer.ToString());
            }

            return txt.ToString().TrimEnd();
        }
    }
}
