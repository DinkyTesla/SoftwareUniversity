using System;
using System.Linq;

namespace _03.Zig_Zag_Arrays
{
    public class Program
    {
        public static void Main(string[] args)
        {
            int arraysLength = int.Parse(Console.ReadLine());
            int[] firstArray = new int[arraysLength];
            int[] secondArray = new int[arraysLength];

            for (int i = 0; i < arraysLength; i++)
            {
                int[] input = Console.ReadLine().Split().Select(int.Parse).ToArray();
                if (i % 2 == 0)
                {
                    secondArray[i] = input[1];
                    firstArray[i] = input[0];
                }
                else
                {
                    secondArray[i] = input[0];
                    firstArray[i] = input[1];
                }

            }
            for (int i = 0; i < arraysLength; i++)
            {
                Console.Write(firstArray[i] + " ");
            }

            Console.WriteLine();

            for (int i = 0; i < arraysLength; i++)
            {
                Console.Write(secondArray[i] + " ");
            }
            Console.WriteLine();
        }
    }
}