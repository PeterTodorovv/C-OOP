using System;
using System.Collections.Generic;
using System.Text;

namespace _05.FootballTeamGenerator
{
    class Player
    {
        private string playerName;
        private int endurance;
        private int sprint;
        private int dribble;
        private int passing;
        private int shooting;

        public Player(string playerName, int endurance, int sprint, int dribble, int passing, int shooting)
        {
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
            set { playerName = value; }
        }
        public int Endurance
        {
            get { return endurance; }
            set { endurance = value; }
        }
        public int Sprint
        {
            get { return sprint; }
            set { sprint = value; }
        }
        public int Dribble
        {
            get { return dribble; }
            set { dribble = value; }
        }
        public int Passing
        {
            get { return passing; }
            set { passing = value; }
        }
        public int Shooting
        {
            get { return shooting; }
            set { shooting = value; }
        }

        public int SkillLevel { get => (Endurance + Sprint + Dribble + Passing + Shooting) / 5; }

    }
}
