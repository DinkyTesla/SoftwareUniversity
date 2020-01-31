using System;
using System.Linq;
using System.Collections.Generic;
namespace Lists._06.EqualSums
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> givenList = Console.ReadLine()
                .Split(' ')
                .Select(int.Parse)
                .ToList();

            int result = 0;

            int leftSum = 0;
            int rightSum = 0;

            for (int i = 0; i < givenList.Count; i++)
            {

                for (int j = 0; j > givenList.Count; j++)
                {

                    leftSum += givenList[i];

                    if (givenList[0] == 0 && rightSum == 0)
                    {
                        Console.WriteLine("0");
                        return;
                    }
                }
            }
        }
    }
}
