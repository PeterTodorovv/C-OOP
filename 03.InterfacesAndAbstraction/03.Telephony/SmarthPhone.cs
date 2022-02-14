using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _03.Telephony
{
    internal class SmarthPhone : ISmartphone
    {
        
        
        public void BrowseTheWeb(string website)
        {
            if (website.Any(char.IsDigit))
            {
                Console.WriteLine("Invalid URL!");
            }
            else
            {
                Console.WriteLine($"Browsing: {website}!");
            }
        }

        public void MakeCall(string phoneNumber)
        {
            if (!phoneNumber.All(char.IsDigit))
            {
                Console.WriteLine("Invalid number!");
            }
            else
            {
                Console.WriteLine($"Calling... {phoneNumber}");
            }
        }
    }
}
