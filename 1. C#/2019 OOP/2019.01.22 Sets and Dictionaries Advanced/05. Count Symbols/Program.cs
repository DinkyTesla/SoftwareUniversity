
namespace _05._Count_Symbols
{
    using System;
    using System.Collections.Generic;

    public class Program
    {
        public static void Main()
        {
            var input = Console.ReadLine().ToCharArray(); ;

            var myDictionary = new SortedDictionary<char, int>();

            foreach (var ch in input)
            {
                if (!myDictionary.ContainsKey(ch))
                {
                    myDictionary.Add(ch, 1);
                }
                else
                {
                    myDictionary[ch]++;
                }
            }

            foreach (var kvp in myDictionary)
            {
                Console.WriteLine($"{kvp.Key}: {kvp.Value} time/s");
            }
        }
    }
}
