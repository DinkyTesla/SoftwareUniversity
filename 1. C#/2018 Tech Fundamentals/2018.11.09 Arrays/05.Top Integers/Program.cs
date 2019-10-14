using System;
using System.Linq;

namespace _05.Top_Integers
{
    public class Program
    {
        public static void Main(string[] args)
        {
            int[] givenArray = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            string answer = string.Empty;

            int positiveCounter = 0;
            int negativeCounter = 0;

            for (int i = 0; i < givenArray.Length; i++)
            {
                for (int j = i + 1; j < givenArray.Length; j++)
                {
                    bool bigger = givenArray[i] > givenArray[j];

                    if (bigger)
                    {
                        positiveCounter++;
                    }
                    else
                    {
                        negativeCounter++;
                    }
                }
                    if (positiveCounter > 0 && negativeCounter == 0)
                    {
                        answer += givenArray[i] + " ";
                    }
                        negativeCounter = 0;
                        positiveCounter = 0;
            }
            Console.WriteLine($"{answer}{givenArray[givenArray.Length -1]}");
        }
    }
}