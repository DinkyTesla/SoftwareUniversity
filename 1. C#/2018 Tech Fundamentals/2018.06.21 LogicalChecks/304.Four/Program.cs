using System;

namespace _304.Four
{
    class Program
    {
        static void Main(string[] args)
        {

            int number = int.Parse(Console.ReadLine());
            string numberAsText = "";

            if (number == 0)
            {
                numberAsText = "zero";
            }
            else if (number == 1)
            {
                numberAsText = "one";
            }
            else
            {
                numberAsText = "Invalid";
            }
            Console.WriteLine(numberAsText);
        }
    }
}
