using System;

namespace _01.SquareRoot
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                int number = int.Parse(Console.ReadLine());
                if (number < 0)
                    throw new ArgumentException();
                Console.WriteLine(Math.Sqrt(number));

            }
            catch (Exception)
            {

                Console.WriteLine("InvalidNumber");
            }
            finally
            {
                Console.WriteLine("Goodbye");
            }
        }
    }
}
