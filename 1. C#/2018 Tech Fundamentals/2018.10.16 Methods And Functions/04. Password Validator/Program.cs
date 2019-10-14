using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04.Password_Validator
{
    public class Program
    {
        public static void Main()
        {
            string inputPassword = Console.ReadLine();

            IsLetterOrDigitBool();


        }

        public static bool IsLetterOrDigitBool (string inputPassword)
        {
            foreach (var chr in inputPassword)
            {

                if (char.IsLetterOrDigit(chr) == false)
                {
                    Console.WriteLine("Password must consist only of letters and digits");
                }
            }

        }

    }

}
}
