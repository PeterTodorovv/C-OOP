﻿using CarRacing.Core.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarRacing.Core
{
    internal class Controller : IController
    {
        public string AddCar(string type, string make, string model, string VIN, int horsePower)
        {
            throw new NotImplementedException();
        }

        public string AddRacer(string type, string username, string carVIN)
        {
            throw new NotImplementedException();
        }

        public string BeginRace(string racerOneUsername, string racerTwoUsername)
        {
            throw new NotImplementedException();
        }

        public string Report()
        {
            throw new NotImplementedException();
        }
    }
}
