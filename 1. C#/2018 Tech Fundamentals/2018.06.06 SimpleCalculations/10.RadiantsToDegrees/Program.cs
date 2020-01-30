using System;

namespace _10.RadiantsToDegrees
{
class Program
{
static void Main(string[] args)
{
        Console.Write("Input Angle in Radians :");
        double Radians = double.Parse(Console.ReadLine());

        double Degrees = Radians * 180 / Math.PI;
        Console.WriteLine("The Degrees are: {0}", Math.Round(Degrees));
}
}
}
