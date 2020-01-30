using System;

namespace _09.CelsiusToFarenheit
{
class Program
{
static void Main(string[] args)
{
        Console.Write("Input Temperature in Celsius: ");
        double Celsius = double.Parse(Console.ReadLine());

        double Farenheit = Celsius * 1.8 + 32;
        Console.WriteLine("The Temperature in Farenheit is {0}", Math.Round(Farenheit,2));
}
}
}
