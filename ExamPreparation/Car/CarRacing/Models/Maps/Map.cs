using CarRacing.Models.Maps.Contracts;
using CarRacing.Models.Racers.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarRacing.Models.Maps
{
    internal class Map : IMap
    {
        public string StartRace(IRacer racerOne, IRacer racerTwo)
        {
            if(!racerOne.IsAvailable() && !racerTwo.IsAvailable())
            {
                return "Race cannot be completed because both racers are not available!";
            }
            else if (!racerOne.IsAvailable())
            {
                return $"{racerTwo.Username} wins the race! {racerOne.Username} was not available to race!";
            }
            else if (!racerTwo.IsAvailable())
            {
                return $"{racerOne.Username} wins the race! {racerTwo.Username} was not available to race!";
            }

            racerOne.Race();
            racerTwo.Race();

            double racerOneChanceOfWinning = racerOne.Car.HorsePower * racerOne.DrivingExperience;

            if(racerOne.RacingBehavior == "strict")
            {
                racerOneChanceOfWinning *= 1.2;
            }
            else
            {
                racerOneChanceOfWinning *= 1.1;
            }

            double racerTwoChanceOfWinning = racerTwo.Car.HorsePower * racerTwo.DrivingExperience;

            if (racerTwo.RacingBehavior == "strict")
            {
                racerTwoChanceOfWinning *= 1.2;
            }
            else
            {
                racerTwoChanceOfWinning *= 1.1;
            }

            IRacer winner;

            if(racerOneChanceOfWinning > racerTwoChanceOfWinning)
            {
                winner = racerOne;
            }
            else
            {
                winner = racerTwo;
            }

            return $"{racerOne.Username} has just raced against {racerTwo.Username}! {winner.Username} is the winner!";
        }
    }
}
