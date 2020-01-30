using System;
using System.Linq;

namespace _22._02._Common_Elements
{
    public class Program
    {
        public static void Main()
        {
            string[] firstArray = Console.ReadLine()
                .Split(" ")
                .ToArray();

            string[] secondArray = Console.ReadLine()
                .Split(" ")
                .ToArray();

            for (int i = 0; i < secondArray.Length; i++)
            {
                for (int j = 0; j < firstArray.Length; j++)
                {
                    if (firstArray[j] == secondArray[i])
                    {
                        Console.Write($"{firstArray[j]} ");
                    }
                }
            }
        }
    }
}
