using System;


namespace _05.TrapezoidArea
{
class Program
{
    static void Main(string[] args)
    {
            var sideA = double.Parse(Console.ReadLine());
            var sideB = double.Parse(Console.ReadLine());
            var height = double.Parse(Console.ReadLine());
            var area = (sideA + sideB) * height / 2;
            Console.WriteLine("Trapezoid area = " + area);
           

        }
}
}
