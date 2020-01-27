
namespace _08._Custom_Comparator
{
    using System;
    using System.Linq;

    public class Program
    {
        public static void Main()
        {
           int[] numbers = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            Func<int, int, int> sortFunc = (a, b) => a.CompareTo(b);
            Action<int[]> print = x => Console.Write(string.Join(" ", x));

            int[] evenNumbers = numbers
                .Where(x => x % 2 == 0)
                .ToArray();

            int[] oddNumbers = numbers
                .Where(x => x % 2 != 0)
                .ToArray();

            Array.Sort(evenNumbers, new Comparison<int>(sortFunc));
            Array.Sort(oddNumbers, new Comparison<int>(sortFunc));

            print(evenNumbers);
            Console.Write(" ");
            print(oddNumbers);
        }
    }
}
