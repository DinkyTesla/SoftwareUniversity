using System;
using System.Collections.Generic;
using System.Linq;

namespace _2.Common_Elements
{
    public class Program
    {
        public static void Main()
        {
            List<string> fistList = new List<string>(Console.ReadLine()
                .Split(' ')
                .ToList());
            List<string> secondList = new List<string>(Console.ReadLine()
                .Split(' ')
                .ToList());

            foreach (var kvp in secondList)
            {
                if (fistList.Contains(kvp))
                {
                    Console.Write($"{kvp} ");
                }
            }
        }
    }
}
