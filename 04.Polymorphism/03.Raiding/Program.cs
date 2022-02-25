using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.Raiding
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            List<IBaseHero> rapidGroup = new List<IBaseHero>();

            for(int i = 0; i < n; i++)
            {
                string name = Console.ReadLine().TrimEnd();
                string type = Console.ReadLine().TrimEnd();

                if (type == "Druid" || type == "Paladin" || type == "Rogue" || type == "Warrior")
                {
                    if(type == "Druid")
                    {
                        rapidGroup.Add(new Druid(name));
                    }
                    else if (type == "Paladin")
                    {
                        rapidGroup.Add(new Paladin(name));
                    }
                    else if(type == "Rogue")
                    {
                        rapidGroup.Add(new Rogue(name));
                    }
                    else if(type == "Warrior")
                    {
                        rapidGroup.Add(new Warrior(name));
                    }
                }
                else
                {
                    Console.WriteLine("Invalid hero!");
                    i--;
                }
            }

            int bossPower = int.Parse(Console.ReadLine());

            foreach(var hero in rapidGroup)
            {
                Console.WriteLine(hero.CastAbility()); 
            }

            if (rapidGroup.Sum(h => h.Power) >= bossPower)
            {
                Console.WriteLine("Victory!");
            }
            else
            {
                Console.WriteLine("Defeat...");
            }
        }
    }
}
