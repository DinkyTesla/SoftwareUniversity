using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _00._04.Split
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = "A, B, ! C, D";

            string[] texts = text.Split(new char[] {',', ' ', '!'}, StringSplitOptions.RemoveEmptyEntries);

            for (int i = 0; i < texts.Length; i++)
            {
                Console.WriteLine(texts[i]);
            }

        }
    }
}
