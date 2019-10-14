using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelloSoftuni
{
    class Program
    {
        static void Main(string[] args)
        {
            for (int row = 1; row <= 10; row++)
            {
                for (int starsCount = 1; starsCount <= row; starsCount++)

                {
                    Console.WriteLine("*");
                }
                Console.WriteLine();
            }
        }
    }
}
