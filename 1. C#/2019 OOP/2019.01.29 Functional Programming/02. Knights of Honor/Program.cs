
namespace _02._Knights_of_Honor
{
    using System;

    public class Program
    {
        public static void Main()
        {
            string[] peasantsCollection = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);

            Action<string> knightPrint = message => Console.WriteLine($"Sir {message}");

            foreach (var name in peasantsCollection)
            {
                knightPrint($"{name}");
            }
        }
    }
}
