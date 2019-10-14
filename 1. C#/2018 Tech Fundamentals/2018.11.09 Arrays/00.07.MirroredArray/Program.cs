using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _00._07.MirroredArray
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] texts = Console.ReadLine().Split();

            for (int i = 0; i < texts.Length / 2; i++)
            {
                string firstText = texts[i];
                int indexOfReversedCell = texts.Length - i - 1;

                texts[i] = texts[indexOfReversedCell];

                texts[indexOfReversedCell] = firstText;

            }


        }
    }
}
