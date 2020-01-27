
namespace _01.GenericBoxOfString
{
    using System;

    public class Program
    {
        public static void Main()
        {
            int linesToRead = int.Parse(Console.ReadLine());

            for (int i = 0; i < linesToRead; i++)
            {
                var someInput = Console.ReadLine();

                var box = new Box<string>(someInput);

                Console.WriteLine(box);
            }
        }
    }
}
