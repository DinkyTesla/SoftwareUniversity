using System;
using System.Linq;
using System.Collections.Generic;

namespace _22._05._Top_Integers
{
    public class Program
    {
        public static void Main()
        {
            int[] givenArray = Console.ReadLine()
                .Split(" ")
                .Select(int.Parse)
                .ToArray();

            string result = string.Empty;

            int positiveCounter = 0;
            int negativeConter = 0;


            for (int i = 0; i < givenArray.Length; i++)
            {
                for (int j = i + 1; j < givenArray.Length; j++)
                {
                    bool ifBigger = givenArray[i] > givenArray[j];

                    if (ifBigger)
                    {
                        positiveCounter++;
                    }
                    else
                    {
                        negativeConter++;
                    }

                }

                if (positiveCounter > 0 && negativeConter == 0)
                {
                    result += givenArray[i] + " ";
                }
                    positiveCounter = 0;
                    negativeConter = 0;
                
            }

            Console.WriteLine($"{result}{givenArray[givenArray.Length - 1]}");
        }
    }
}
