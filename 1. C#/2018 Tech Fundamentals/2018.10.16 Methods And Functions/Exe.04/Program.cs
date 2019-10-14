using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exe._04
{
    public class Program
    {
        public static void Main()
        {
            string password = Console.ReadLine();

            bool isBetween6And10Symbols = CheckLengthOfPassword(password);

            if (isBetween6And10Symbols == false)
            {
                Console.WriteLine("Password must be between 6 and 10 characters");
            }

            bool ContainsOnlyDigitsAndLetters = ContainsOnlyDigitsAndLetters(password);

        }

        public static bool CheckLengthOfPassword(string password)
        {
            return password.Length >= 6 && password.Length <= 10 ? true : false;    
        }
    }
}
