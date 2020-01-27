
namespace _01.ClassBox
{
    using System;

    public class Program
    {
        public static void Main()
        {
            var length = double.Parse(Console.ReadLine());
            var width = double.Parse(Console.ReadLine());
            var height = double.Parse(Console.ReadLine());

            var myBox = new Box(length, width, height);

            Console.WriteLine(string.Join("", myBox));
        }
    }
}
