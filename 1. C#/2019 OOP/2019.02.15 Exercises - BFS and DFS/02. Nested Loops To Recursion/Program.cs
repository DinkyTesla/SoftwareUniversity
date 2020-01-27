
namespace _02._Nested_Loops_To_Recursion
{
    using System;

    public class Program
    {

        private static int[] arr;

        public static void Main()
        {
            int number = int.Parse(Console.ReadLine());
            arr = new int[number];
            PrintNestedLoops(number, 0);


        }

        private static void PrintNestedLoops(int number, int counter)
        {
            if (counter >= number)
            {
                Console.WriteLine(string.Join(" ", arr));
                return;
            }

            for (int i = 1; i < number; i++)
            {
                arr[counter] = i;
                PrintNestedLoops(number, counter + 1);
            }

        }
    }
}
