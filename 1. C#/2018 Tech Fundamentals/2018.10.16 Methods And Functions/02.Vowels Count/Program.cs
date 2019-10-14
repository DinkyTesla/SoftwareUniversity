using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.Vowels_Count
{
    public class Program
    {
        public static void Main()
        {

            VowelsCounter();

        }

        public static void VowelsCounter()
        {
            string givenString = Console.ReadLine().ToLower();

            List<Char> vowels = new List<char>() { 'a', 'e', 'i', 'o', 'u' };

            int vowelsCounter = 0;

            foreach (char myChar in givenString)
            {
                if (vowels.Contains(myChar))
                {
                    vowelsCounter++;
                }
            }

            Console.WriteLine(vowelsCounter);
        
        }
    }
}
