using System;
using System.Globalization;
using System.Collections;

namespace _03.Lecture
{
    public class Program
    {
        public static void Main()
        {
            string stringDate = Console.ReadLine();

            DateTime date = DateTime.ParseExact(stringDate, "dd-MM-yyyy", CultureInfo.InvariantCulture);

            Console.WriteLine();
        }  
    }
}
