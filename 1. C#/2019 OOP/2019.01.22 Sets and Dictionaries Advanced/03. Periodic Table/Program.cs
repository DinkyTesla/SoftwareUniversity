
namespace _03._Periodic_Table
{
    using System;
    using System.Collections.Generic;

    public class Program
    {
        public static void Main()
        {
            var numberOfElements = int.Parse(Console.ReadLine());

            SortedSet<string> elements = new SortedSet<string>();

            for (int i = 0; i < numberOfElements; i++)
            {
                var input = Console.ReadLine().Split();

                foreach (var item in input)
                {
                    elements.Add(item);
                }
            }

            Console.WriteLine(string.Join(" ", elements));
        }
    }
}
