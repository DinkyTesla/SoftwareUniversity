using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01._01
{
    public class Program
    {
        public static void Main()
        {
            List<string> givenText = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .ToList();

            var someDictionary = new Dictionary<char, int>();

            for (int i = 0; i < givenText.Count; i++)
            {
                foreach (var item in givenText[i])
                {
                    if (!someDictionary.Keys.Contains(item))
                    {
                        someDictionary.Add(item, 0);
                    }
                    someDictionary[item]++;
                }
            }

            foreach (var kvp in someDictionary)
            {
                Console.WriteLine($"{kvp.Key} -> {kvp.Value}");
            }
        }
    }
}
