
namespace _01._Action_Point
{
    using System;

    public class Program
    {
        public static void Main()
        {
            string[] namesCollection = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);

            Action<string> print = message => Console.WriteLine(message);

            foreach (var name in namesCollection)
            {
                print($"{name}");
            }
        }
    }
}
