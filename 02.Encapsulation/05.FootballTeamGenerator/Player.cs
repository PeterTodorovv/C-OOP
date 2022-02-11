using System;
using System.Collections.Generic;
using System.Text;

namespace _05.FootballTeamGenerator
{
    class Player
    {
        private string playerName;
        private double endurance;
        private double sprint;
        private double dribble;
        private double passing;
        private double shooting;

        public Player(string playerName, double endurance, double sprint, double dribble, double passing, double shooting)
        {
            IsAValidPlayer = true;
            PlayerName = playerName;
            Endurance = endurance;
            Sprint = sprint;
            Dribble = dribble;
            Passing = passing;
            Shooting = shooting;
        }

        public string PlayerName
        {
            get { return playerName; }
            private set 
            {
                if (string.IsNullOrEmpty(value))
                {
                    IsAValidPlayer = false;
                    Console.WriteLine("A name should not be empty.");
                }
                else
                {
                    playerName = value;
                }
            }
        }
        public double Endurance
        {
            get { return endurance; }
            set 
            {
                if (IsValidRating(value))
                {
                    endurance = value;
                }
                else
                {
                    IsAValidPlayer = false;
                    Console.WriteLine($"Endurance should be between 0 and 100.");
                }
            }
        }
        public double Sprint
        {
            get { return sprint; }
            set 
            {
                if (IsValidRating(value))
                {
                    sprint = value;
                }
                else
                {
                    IsAValidPlayer = false;
                    Console.WriteLine($"Sprint should be between 0 and 100.");
                }
            }
        }
        public double Dribble
        {
            get { return dribble; }
            set 
            {
                if (IsValidRating(value))
                {
                    dribble = value;
                }
                else
                {
                    IsAValidPlayer = false;
                    Console.WriteLine($"Dribble should be between 0 and 100.");
                }
            }
        }
        public double Passing
        {
            get { return passing; }
            set 
            {
                if (IsValidRating(value))
                {
                    passing = value;
                }
                else
                {
                    IsAValidPlayer = false;
                    Console.WriteLine($"Passing should be between 0 and 100.");
                }
            }
        }
        public double Shooting
        {
            get { return shooting; }
            set 
            {
                if (IsValidRating(value))
                {
                    shooting = value;
                }
                else
                {
                    IsAValidPlayer = false;
                    Console.WriteLine($"Shooting should be between 0 and 100.");
                }
            }
        }

        public double SkillLevel { get => Math.Round((Endurance + Sprint + Dribble + Passing + Shooting) / 5); }

        public bool IsValidRating(double rating)
        {
            if(rating > 0 && rating < 100)
            {
                return true;
            }
            return false;
        }

        public bool IsAValidPlayer { get; private set; }
    }
}
