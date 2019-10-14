using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _09.Kamino_Factory
{
    public class Program
    {
        public static void Main(string[] args)
        {
            int DNALength = int.Parse(Console.ReadLine());

            int lenght = 0;
            int sum = 0;
            int startIndex = -1;
            int row = 0;
            int currentRow = 1;

            int[] DNA = new int[DNALength];

            while (true)
            {
                string line = Console.ReadLine();

                if (line == "Clone them!")
                {
                    break;
                }

                int[] currentDNA = line
                    .Split("!", StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                int currentSum = 0;

                for (int i = 0; i < currentDNA.Length; i++)
                {
                    if (currentDNA[i] == 1)
                    {
                        currentSum++;
                    }
                }


                int currentStarIndex = -1;
                int currentLength = 0;
                bool isFound = false;

                for (int i = 0; i < currentDNA.Length; i++)
                {
                    if (currentDNA[i] == 1)
                    {
                        if (!isFound)
                        {
                            currentStarIndex = i;

                        }
                    }

                    currentLength++;

                    if (currentLength > lenght)
                    {
                        lenght = currentLength;
                        startIndex = currentStarIndex;
                        sum = currentSum;
                        row = currentRow;

                        DNA = currentDNA;

                    }
                    else if (currentLength == lenght)
                    {
                        if (currentStarIndex < startIndex)
                        {
                            lenght = currentLength;
                            startIndex = currentStarIndex;
                            sum = currentSum;
                            row = currentRow;

                            DNA = currentDNA;
                        }
                        else if (currentSum > sum)
                        {
                            lenght = currentLength;
                            startIndex = currentStarIndex;
                            sum = currentSum;
                            row = currentRow;

                            DNA = currentDNA;
                        }
                    }
                    else
                    {
                        currentStarIndex = -1;
                        currentLength = 0;
                        isFound = false;
                    }
                }

                currentRow++;

            }
            Console.WriteLine($" Best DNA sampe {row} with sum: {sum}. ");
            Console.WriteLine(string.j, DNA);




        }
    }
}
