using System;
using System.Linq;
using System.Collections.Generic;

namespace Lists._05.Top_Integers
{
    public class Program
    {
        public static void Main()
        {
            List<int> givenList = new List<int>(Console.ReadLine()
                .Split(' ')
                .Select(int.Parse)
                .ToList());

            int counter = 0;

            string answer = string.Empty;

            for (int i = 0; i < givenList.Count - 1; i++)
            {
                for (int j = i + 1; j < givenList.Count; j++)
                {
                    if (givenList[i] > givenList[j])
                    {
                        counter++;
                    }
                    else
                    {
                        counter = 0;
                        break;
                    }
                }
                if (counter > 0)
                {
                    answer += givenList[i] + " ";
                    counter = 0;
                }
            }

            Console.WriteLine(answer + givenList[givenList.Count - 1]);
        }
    }
}
