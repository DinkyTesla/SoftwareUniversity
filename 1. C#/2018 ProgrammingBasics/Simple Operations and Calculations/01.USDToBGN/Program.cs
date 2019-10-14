
namespace _01.USDToBGN
{
    using System;

    public class Program
    {
        public static void Main()
        {
            double usd = double.Parse(Console.ReadLine());
            double bgn = Math.Round(usd * 1.79549, 2); //Fixed

            Console.WriteLine(bgn);
        }
    }
}
