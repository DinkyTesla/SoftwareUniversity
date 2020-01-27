using System;

namespace _04.Lecture
{
    public class Program
    {
        public static void Main()
        {
            var random = new Random();

            var first = random.Next(1, 100);
            var second = random.Next(1, 100);
            var third = random.Next(1, 100);

            Console.WriteLine(first);
            Console.WriteLine(second);
            Console.WriteLine(third);
        }
    }
}
