using System;
using System.Collections.Generic;

namespace _05.FootballTeamGenerator
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Team> teams = new Dictionary<string, Team>();

            string[] input = Console.ReadLine().Split(";");

            while(input[0] != "END")
            {
                if(input[0] == "Team")
                {
                    teams.Add(input[1], new Team(input[1]));
                }
                else if(input[0] == "Add")
                {
                    string teamName = input[1];
                    string playerName = input[2];
                    int endurance = int.Parse(input[3]);
                    int sprint = int.Parse(input[4]);
                    int dribble = int.Parse(input[5]);
                    int passing = int.Parse(input[6]);
                    int shooting = int.Parse(input[7]);

                    if (teams.ContainsKey(teamName))
                    {
                        teams[teamName].AddPlayer(new Player(playerName, endurance, sprint, dribble, passing, shooting));
                    }
                    else
                    {
                        Console.WriteLine($"Team {teamName} does not exist.");
                    }
                }
                else if(input[0] == "Remove")
                {
                    string teamName = input[1];
                    string playerName = input[2];
                    teams[teamName].RemovePlayer(playerName);
                }
                else if(input[0] == "Rating")
                {
                    string teamName = input[1];
                    if (!teams.ContainsKey(teamName))
                    {
                        Console.WriteLine($"Team {teamName} does not exist.");
                    }
                    else
                    {
                        Console.WriteLine($"{teamName} - {teams[teamName].Rating}");
                    }
                }

                input = Console.ReadLine().Split(";");
            }
        }
    }
}
