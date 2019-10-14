using System;


namespace _10.EqualWords
{
    class Program
    {
        static void Main(string[] args)
        {
            string firstWord = Console.ReadLine().ToLower();
            string secondWord = Console.ReadLine().ToLower();
            string result = "";

            if ( firstWord == secondWord)
            {
                result = "yes";
            }
            else
            {
                result = "no";
            }

            Console.WriteLine(result);
        }
    }
}
