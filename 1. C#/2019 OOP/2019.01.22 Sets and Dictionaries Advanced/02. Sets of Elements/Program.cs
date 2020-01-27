
namespace _02._Sets_of_Elements
{
    using System;
    using System.Collections.Generic;

    public class Program
    {
        public static void Main()
        {
            var setsLenght = Console.ReadLine().Split();

            var firstSetCount = int.Parse(setsLenght[0]);
            var secondSetCount = int.Parse(setsLenght[1]);

            HashSet<int> firstSet = new HashSet<int>();
            HashSet<int> secondSet = new HashSet<int>();

            for (int i = 0; i < firstSetCount; i++)
            {
                var input = int.Parse(Console.ReadLine());
                firstSet.Add(input);
            }
            for (int i = 0; i < secondSetCount; i++)
            {
                var input = int.Parse(Console.ReadLine());
                secondSet.Add(input);
            }

            foreach (var number in firstSet)
            {
                if (secondSet.Contains(number))
                {
                    Console.Write($"{number} ");
                }
            }
        }
    }
}
