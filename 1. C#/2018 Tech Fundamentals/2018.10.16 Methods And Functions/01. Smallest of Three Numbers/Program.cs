using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.Smallest_of_Three_Numbers
{
    public class Program
    {
        public static void Main()
        {

            PrintingTheSMallestNumber();

        }

        public static void PrintingTheSMallestNumber()
        {
            int testNumber = int.MaxValue;

            for (int i = 0; i < 3; i++)
            {
                int number = int.Parse(Console.ReadLine());

                if (number < testNumber)
                {
                    testNumber = number;
                }

            }

            Console.WriteLine(testNumber);

        }
    }
}
