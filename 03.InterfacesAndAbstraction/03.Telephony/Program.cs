
using System;

namespace _03.Telephony
{
    internal class Program
    {
        static void Main(string[] args)
        {
            SmarthPhone smarthphone = new SmarthPhone();
            StationaryPhone satellitephone = new StationaryPhone();
            string[] phoneNumebrs = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
            string[] websites = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

            foreach(string number in phoneNumebrs)
            {
                if(number.Length == 10)
                {
                    smarthphone.MakeCall(number);
                }
                else
                {
                    satellitephone.DiealCall(number);
                }
            }

            foreach(string website in websites)
            {
                smarthphone.BrowseTheWeb(website);
            }
        }
    }
}
