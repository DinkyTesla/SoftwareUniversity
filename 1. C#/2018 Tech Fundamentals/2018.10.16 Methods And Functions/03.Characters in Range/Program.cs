using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.Characters_in_Range
{
    public class Program
    {
        public static void Main(string[] args)
        {
            PrintCharactersInBetween();
        }

        public static void PrintCharactersInBetween()
        {
            char firstChar = char.Parse(Console.ReadLine());
            char secondChar = char.Parse(Console.ReadLine());

            if ((int)firstChar < (int)secondChar)
            {
                for (int i = (int)firstChar + 1; i < (int)secondChar; i++)
                {
                    Console.Write((char)i + " ");
                }
            }
            else
            {
                for (int i = (int)secondChar + 1; i < (int)firstChar; i++)
                {
                    Console.Write((char)i + " ");
                }
            }
        }
    }
}
