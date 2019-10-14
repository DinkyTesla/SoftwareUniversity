using System;

namespace _00._03.ValueTypes
{
    class Program
    {
        static void Main(string[] args)
        {

            //int[] numbers = { 1, 2, 3, 4, 5 };
            //int[] secondNumbers = numbers;

            //secondNumbers[2] = 1000;
            //Console.WriteLine(numbers[2]);

            //      // За да не се промени:

            int[] numbers = { 1, 2, 3, 4, 5 };
            int[] secondNumbers = new int[numbers.Length];

            secondNumbers[2] = 1000;
            Console.WriteLine(numbers[2]);


        }
    }
}
