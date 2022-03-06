using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace AuthorProblem
{
    internal class Tracker
    {
        public  void PrintMethodsByAuthor()
        {
            var classTypes  = Assembly.GetExecutingAssembly().GetTypes();

            foreach (var type in classTypes)
            {
                foreach (var method in type.GetMethods(BindingFlags.Public | BindingFlags.Instance | BindingFlags.Static | BindingFlags.NonPublic))
                {
                    var customAtribute = method.GetCustomAttribute<AuthorAttribute>();
                    if(customAtribute != null)
                        Console.WriteLine($"{method.Name} is written by {customAtribute.Name}");
                }
            }
        }
    }
}
