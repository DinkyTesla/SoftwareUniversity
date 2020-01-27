
namespace _03._Custom_Min_Function
{
    using System;
    using System.Linq;

    public class Program
    {
        public static void Main()
        {
            int[] input = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            Func<int[], int> minNumFunc = m => m.Min();

            Action<int> minNumPrint = message => Console.WriteLine($"{message}");

            minNumPrint(minNumFunc(input));
        }
    }
}
