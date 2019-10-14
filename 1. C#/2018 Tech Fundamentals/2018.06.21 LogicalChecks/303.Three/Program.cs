using System;

namespace _303.Three
{
    class Program
    {
        static void Main(string[] args)
        {
            int a = int.Parse(Console.ReadLine());
            int b = int.Parse(Console.ReadLine());
            string result = "The greater number is: ";

            if (a > b)
            {
                result = result + a;
            }
            else
            {
                result = result + b;
            }
            Console.WriteLine(result);
        }
    }
}
