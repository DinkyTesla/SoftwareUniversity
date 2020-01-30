using System;

namespace _06.CircleAreaAndPerimeter
{
class Program
{
    static void Main(string[] args)
    {
            Console.Write("Enter circle radius. r = ");
            double r = double.Parse(Console.ReadLine());

            double area = Math.PI * r * r;
            double perimeter = 2 * Math.PI * r;

            Console.WriteLine("Area = {0}", area);
            Console.WriteLine("Perimeter = {0}", perimeter);
    }
}
}
