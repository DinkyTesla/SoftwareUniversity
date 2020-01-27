
namespace _04._Find_Evens_or_Odds
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Program
    {
        public static void Main()
        {
            int[] rangeOfNumbers = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int start = rangeOfNumbers[0];
            int end = rangeOfNumbers[1];

            string typeOfNumbers = Console.ReadLine();

            Predicate<int> filter = x => typeOfNumbers == "odd" ? x % 2 != 0 : x % 2 == 0;

            List<int> numbers = new List<int>();

            for (int i = start; i <= end; i++)
            {
                numbers.Add(i);
            }

            Console.WriteLine(string.Join(" ", numbers.Where(x => filter(x))));
        }
    }
}
