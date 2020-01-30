using System;
using System.Linq;
using System.Collections.Generic;

namespace _22.HomeExe
{
    public class Program
    {
        public static void Main()
        {
            List<int> numbers = Console.ReadLine()
                .Split(' ')
                .Select(int.Parse)
                .ToList();

            for (int i = 0; i < numbers.Count; i++)
            {
                var currentNumber = numbers[i];
                var nextNumber = numbers[i + 1];

                if (currentNumber == nextNumber)
                {
                    numbers[i] *= 2;
                    numbers.Remove(nextNumber);
                    i = -1;
                }
            }
            Console.WriteLine(string.Join(" ", numbers));
        }
    }
}
