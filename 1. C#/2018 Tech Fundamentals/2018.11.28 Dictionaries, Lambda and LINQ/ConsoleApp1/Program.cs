using System;
using System.Collections.Generic;

namespace ConsoleApp1
{
    public class Program
    {
        public static void Main()
        {

            int numberOfWagons = int.Parse(Console.ReadLine());

            List<int> wagons = new List<int>();

            var sum = 0;

            for (int i = 0; i < numberOfWagons; i++)
            {
                wagons.Add(int.Parse(Console.ReadLine()));
                sum += wagons[i];
            }

            Console.WriteLine(string.Join(' ', wagons));
            Console.WriteLine(sum);
        }
    }
}
