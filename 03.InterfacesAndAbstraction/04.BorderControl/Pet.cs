using System;
using System.Collections.Generic;
using System.Text;

namespace _04.BorderControl
{
    public class Pet : IBirthDate
    {
        public Pet(string name, string birthdate)
        {
            Name = name;
            Birthdate = birthdate;
        }

        public string Name { get; set; }
        public string Birthdate { get; set; }
    }
}
