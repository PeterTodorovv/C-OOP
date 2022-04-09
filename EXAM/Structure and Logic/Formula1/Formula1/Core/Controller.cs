using Formula1.Core.Contracts;
using Formula1.Models;
using Formula1.Models.Contracts;
using Formula1.Repositories;
using Formula1.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Formula1.Core
{
    class Controller : IController
    {
        private PilotRepository pilots;
        private RaceRepository races;
        private FormulaOneCarRepository cars;

        public Controller()
        {
            pilots = new PilotRepository();
            races = new RaceRepository();
            cars = new FormulaOneCarRepository();
        }

        public string AddCarToPilot(string pilotName, string carModel)
        {
            IPilot pilot = pilots.FindByName(pilotName);
            IFormulaOneCar car = cars.FindByName(carModel);

            if(pilot == null || pilot.CanRace)
            {
                throw new InvalidOperationException(String.Format(ExceptionMessages.PilotDoesNotExistOrHasCarErrorMessage, pilotName));
            }

            if(car == null)
            {
                throw new NullReferenceException(String.Format(ExceptionMessages.CarDoesNotExistErrorMessage, carModel));
            }

            pilot.AddCar(car);
            cars.Remove(car);
            return String.Format(OutputMessages.SuccessfullyPilotToCar, pilotName, car.GetType().Name, carModel);
        }

        public string AddPilotToRace(string raceName, string pilotFullName)
        {
            IRace race = races.FindByName(raceName);
            IPilot pilot = pilots.FindByName(pilotFullName);

            if(race == null)
            {
                throw new NullReferenceException(String.Format(ExceptionMessages.RaceDoesNotExistErrorMessage, raceName));
            }

            if(pilot == null || !pilot.CanRace || race.Pilots.Contains(pilot))
            {
                throw new InvalidOperationException(String.Format(ExceptionMessages.PilotDoesNotExistErrorMessage, pilotFullName));
            }

            race.AddPilot(pilot);
            return String.Format(OutputMessages.SuccessfullyAddPilotToRace, pilotFullName, raceName);
        }

        public string CreateCar(string type, string model, int horsepower, double engineDisplacement)
        {
            if(cars.FindByName(model) != null)
            {
                throw new InvalidOperationException(String.Format(ExceptionMessages.CarExistErrorMessage, model));
            }

            IFormulaOneCar car;

            if(type == "Ferrari")
            {
                car = new Ferrari(model, horsepower, engineDisplacement);
            }
            else if(type == "Williams")
            {
                car = new Williams(model, horsepower, engineDisplacement);
            }
            else
            {
                throw new InvalidOperationException(String.Format(ExceptionMessages.InvalidTypeCar, type));
            }

            cars.Add(car);
            return $"Car { type }, model { model } is created.";
        }

        public string CreatePilot(string fullName)
        {
            if(pilots.FindByName(fullName) != null)
            {
                throw new InvalidOperationException(String.Format(ExceptionMessages.PilotExistErrorMessage, fullName));
            }

            pilots.Add(new Pilot(fullName));
            return $"Pilot { fullName } is created.";
        }

        public string CreateRace(string raceName, int numberOfLaps)
        {
            if(races.FindByName(raceName) != null)
            {
                throw new InvalidOperationException(String.Format(ExceptionMessages.RaceExistErrorMessage, raceName));
            }

            IRace race = new Race(raceName, numberOfLaps);
            races.Add(race);
            return $"Race { raceName } is created.";

        }

        public string PilotReport()
        {
            StringBuilder sb = new StringBuilder();

            foreach(var pilot in pilots.Models.OrderByDescending(p => p.NumberOfWins))
            {
                sb.AppendLine(pilot.ToString());
            }

            return sb.ToString().TrimEnd();
        }

        public string RaceReport()
        {
            StringBuilder sb = new StringBuilder();

            foreach(var race in races.Models.Where(r => r.TookPlace))
            {
                sb.AppendLine(race.RaceInfo());
            }

            return sb.ToString().TrimEnd();
        }

        public string StartRace(string raceName)
        {
            IRace race = races.FindByName(raceName);

            if(race == null)
            {
                throw new NullReferenceException(String.Format(ExceptionMessages.RaceDoesNotExistErrorMessage, raceName));
            }

            if(race.Pilots.Count < 3)
            {
                throw new InvalidOperationException(String.Format(ExceptionMessages.InvalidRaceParticipants, raceName));
            }

            if (race.TookPlace)
            {
                throw new InvalidOperationException(String.Format(ExceptionMessages.RaceTookPlaceErrorMessage, raceName));
            }

            race.TookPlace = true;
            var sortedRace = race.Pilots.OrderByDescending(p => p.Car.RaceScoreCalculator(race.NumberOfLaps));
            int position = 1;
            StringBuilder sb = new StringBuilder();

            foreach(var pilot in sortedRace)
            {
                if(position == 1)
                {
                    pilot.WinRace();
                    sb.AppendLine($"Pilot { pilot.FullName } wins the { raceName } race.");
                }
                else if(position == 2)
                {
                    sb.AppendLine($"Pilot { pilot.FullName } is second in the { raceName } race.");
                }
                else if(position == 3)
                {
                    sb.AppendLine($"Pilot { pilot.FullName } is third in the { raceName } race.");
                }
                else
                {
                    break;
                }

                position++;
            }

            return sb.ToString().TrimEnd();
        }
    }
}
