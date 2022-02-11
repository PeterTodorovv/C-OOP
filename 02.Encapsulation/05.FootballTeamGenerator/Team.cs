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
            set
            {
                if (!string.IsNullOrEmpty(value))
                {
                    name = value;
                }
                else
                {
                    throw new ArgumentException();
                }
            }
        }

        private List<Player> players;
        public int Rating { get 
            {
                if (players.Count != 0)
                {
                    double averageRating = 0;
                    foreach(var player in players)
                    {
                        averageRating =+ player.SkillLevel;
                    }
                    averageRating /= players.Count;
                    return (int)Math.Round(averageRating);
                }
                return 0;
            }
        }

        public void AddPlayer(Player player)
        {
            if(player.IsAValidPlayer)
                players.Add(player);
        }
        
        public void RemovePlayer(string playerName)
        {
            if(players.Any(p => p.PlayerName == playerName))
            {
                players.Remove(players.FirstOrDefault(p => p.PlayerName == playerName));
            }
            else
            {
                Console.WriteLine($"Player {playerName} is not in {name} team.");
            }
        }
    }
}
