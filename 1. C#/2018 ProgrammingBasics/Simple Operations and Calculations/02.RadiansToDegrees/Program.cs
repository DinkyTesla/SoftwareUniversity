
namespace _02.RadiansToDegrees
{
    using System;

    public class Program
    {
        public static void Main()
        {
            double radiansInput = double.Parse(Console.ReadLine());

            double degreesOutput = Math.Round((radiansInput * 180) / Math.PI);

            Console.WriteLine(degreesOutput);
        }
    }
}
