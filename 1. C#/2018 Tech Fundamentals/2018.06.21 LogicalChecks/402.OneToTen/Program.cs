using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _402.OneToTen
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());
            string result = string.Empty;

            if (number == 1)
            {
                result = "one";
            }
            else if ( number == 2)
            {
                result = "two";
            }
            else if (number == 3)
            {
                result = "three";
            }
            else if (number == 4)
            {
                result = "four";
            }
            else if (number == 5)
            {
                result = "five";
            }
            else if (number == 6)
            {
                result = "six";
            }
            else if (number == 7)
            {
                result = "seven";
            }
            else if (number == 8)
            {
                result = "eight";
            }
            else if (number == 9)
            {
                result = "nine";
            }
            else
            {
                result = "number too big";
            }
            
            Console.WriteLine(result);
        }
    }
}
