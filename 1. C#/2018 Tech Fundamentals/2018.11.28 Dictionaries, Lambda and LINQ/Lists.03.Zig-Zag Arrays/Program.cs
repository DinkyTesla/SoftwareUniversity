using System;
using System.Collections.Generic;
using System.Linq;

namespace Lists._03.Zig_Zag_Arrays
{
    class Program
    {
        static void Main(string[] args)
        {
            int givenNumber = int.Parse(Console.ReadLine());

            List<int> givenList = new List<int>();
            List<int> oddList = new List<int>();
            List<int> evenList = new List<int>();

            for (int i = 0; i < givenNumber; i++)
            {
                givenList = Console.ReadLine()
                    .Split(' ')
                    .Select(int.Parse)
                    .ToList();
                if (i % 2 == 0)
                {
                    oddList.Add(givenList[0]);
                    evenList.Add(givenList[1]);
                }
                else
                {
                    oddList.Add(givenList[1]);
                    evenList.Add(givenList[0]);
                }
            }

            Console.WriteLine(string.Join(' ', oddList));
            Console.WriteLine(string.Join(' ', evenList));
        }
    }
}
