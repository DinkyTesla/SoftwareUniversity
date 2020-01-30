using System;
using System.Linq;
using System.Collections.Generic;

namespace _22._01._Count_Chars_in_a_String
{
    public class Program
    {
        public static void Main()
        {
            List<string> givenText = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .ToList();

            var newDictionary = new Dictionary<char, int>();

            for (int i = 0; i < givenText.Count; i++)
            {
                foreach (var item in givenText[i])
                {
                    if (!newDictionary.Keys.Contains(item))
                    {
                        newDictionary.Add(item, 0);
                    }
                        newDictionary[item]++;
                }
            }
            foreach (var kvp in newDictionary)
            {
                Console.WriteLine($"{kvp.Key} -> {kvp.Value}");
            }
        }
    }
}
