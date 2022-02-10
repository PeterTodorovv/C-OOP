using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _05.FootballTeamGenerator
{
    class Team
    {
        private string name;

        public Team(string name)
        {
            Name = name;
            players = new List<Player>();
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        private List<Player> players;
        public int Rating { get => (int)Math.Round(players.Average(p => p.SkillLevel)); }

        public void AddPlayer(Player player)
        {
            players.Add(player);
        }
        
        public void RemovePlayer(string playerName)
        {
            players.Remove(players.FirstOrDefault(p => p.PlayerName == playerName));
        }
    }
}
