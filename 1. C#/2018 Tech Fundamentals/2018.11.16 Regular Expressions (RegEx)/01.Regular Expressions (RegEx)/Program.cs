using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace _01.Regular_Expressions__RegEx_
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            string[] names = input
                .Split(", ", StringSplitOptions.RemoveEmptyEntries); // Да си проверя по какво да сплитвам.

            foreach (var name in names)
            {
                Regex regex = new Regex("^[A-Z][a-z]+ [A-Z][a-z]+$");
                bool hasMatch = regex.Match(name).Success;

                if (hasMatch)
                {
                Console.Write(name + " ");

                }
            }

            //var r = new Regex("regex");
            //MatchCollection m = r.Matches("asdasd");

            //foreach (Match match in m)
            //{
            //    match.
            //}
        }
    }
}
