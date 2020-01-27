
namespace _01.Reverse_Array
{
    using System;
    using System.Linq;

    public class Program
    {
        public static void Main()
        {
            int[] arr = Console.ReadLine()
                .Split(" ")
                .Select(int.Parse)
                .ToArray();

            PrintInReverseOrder(arr, arr.Length - 1);
        }

        private static void PrintInReverseOrder(int[] arr, int index)
        {
            if (index < 0)
            {
                return;
            }

            Console.Write(arr[index] + " ");
            PrintInReverseOrder(arr, index - 1);
        }
    }
}
