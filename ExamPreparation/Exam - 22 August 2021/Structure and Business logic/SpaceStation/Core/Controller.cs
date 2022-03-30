using SpaceStation.Core.Contracts;
using SpaceStation.Models.Astronauts;
using SpaceStation.Models.Astronauts.Contracts;
using SpaceStation.Models.Mission;
using SpaceStation.Models.Planets;
using SpaceStation.Models.Planets.Contracts;
using SpaceStation.Repositories;
using SpaceStation.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpaceStation.Core
{
    internal class Controller : IController
    {
        AstronautRepository astronauts;
        PlanetRepository planets;
        private HashSet<IPlanet> planetsExplored;

        public Controller()
        {
            astronauts = new AstronautRepository();
            planets = new PlanetRepository();
            planetsExplored = new HashSet<IPlanet>();
        }

        public string AddAstronaut(string type, string astronautName)
        {
            if(type == "Biologist")
            {
                astronauts.Add(new Biologist(astronautName));
            }
            else if(type == "Geodesist")
            {
                astronauts.Add(new Geodesist(astronautName));
            }
            else if(type == "Meteorologist")
            {
                astronauts.Add(new Meteorologist(astronautName));
            }
            else
            {
                throw new InvalidOperationException(ExceptionMessages.InvalidAstronautType);
            }

            return $"Successfully added {type}: {astronautName}!";
        }

        public string AddPlanet(string planetName, params string[] items)
        {
            IPlanet planet = new Planet(planetName);

            foreach(string item in items)
            {
                planet.Items.Add(item);
            }

            planets.Add(planet);

            return $"Successfully added Planet: {planetName}!";
        }

        public string ExplorePlanet(string planetName)
        {
            Mission misson = new Mission();
            IPlanet planet = planets.FindByName(planetName);
            List<IAstronaut> astronautsOnMission = astronauts.Models.Where(a => a.Oxygen > 60).ToList();

            if(astronautsOnMission.Count == 0)
            {
                throw new InvalidOperationException("You need at least one astronaut to explore the planet");
            }

            misson.Explore(planet, astronautsOnMission);

            int deadAstronauts = astronautsOnMission.Where(a => a.Oxygen == 0).Count();
            planetsExplored.Add(planet);

            return $"Planet: {planetName} was explored! Exploration finished with {deadAstronauts} dead astronauts!";
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"{planetsExplored.Count} planets were explored!");
            sb.AppendLine($"Astronauts info:");

            foreach(IAstronaut astronaut in astronauts.Models)
            {
                sb.AppendLine($"Name: {astronaut.Name}");
                sb.AppendLine($"Oxygen: {astronaut.Oxygen}");

                if(astronaut.Bag.Items.Count == 0)
                {
                    sb.AppendLine($"Bag items: none");
                }
                else
                {
                    sb.AppendLine($"Bag items: {string.Join(", ", astronaut.Bag.Items)} ");
                }
            }

            return sb.ToString().TrimEnd();
        }

        public string RetireAstronaut(string astronautName)
        {
            IAstronaut astronaut = astronauts.FindByName(astronautName);

            if(astronaut == null)
            {
                throw new InvalidOperationException(ExceptionMessages.InvalidRetiredAstronaut);
            }

            astronauts.Remove(astronaut);
            return $"Astronaut {astronautName} was retired!";
        }
    }
}
