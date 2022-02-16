using System;
using System.Collections.Generic;
using System.Text;

namespace _07.MilitaryElite.Interfaces
{
    public abstract class Soldier
    {
        protected Soldier(string id, string firstName, string lastName)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
        }

        public string Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
