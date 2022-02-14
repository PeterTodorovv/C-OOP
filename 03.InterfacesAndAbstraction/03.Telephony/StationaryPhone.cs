using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _03.Telephony
{
    internal class StationaryPhone : IStationaryPhone
    {
        public void DiealCall(string number)
        {
            if (!number.All(char.IsDigit))
            {
                Console.WriteLine("Invalid number!");
            }
            else
            {
                Console.WriteLine($"Dialing... {number}");
            }
        }
    }
}
