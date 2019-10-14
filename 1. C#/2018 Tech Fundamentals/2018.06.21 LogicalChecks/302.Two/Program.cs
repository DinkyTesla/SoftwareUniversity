using System;


namespace _302.Two
{
    class Program
    {
        static void Main(string[] args)
        {

            int number = int.Parse(Console.ReadLine());
            bool isEven = number % 2 == 0;
            string result = "";

            if (isEven)
            {
                result = "Even number";
            }
            else
            {
                result = "Odd number";
            }
            Console.WriteLine(result);
        }
    }
}
