using System;

namespace _21.TriangleArea
{
class Program
{
    static void Main(string[] args)
    {

        double sideA = double.Parse(Console.ReadLine());
        double height = double.Parse(Console.ReadLine());

        double area = (sideA * height) / 2;
        Console.WriteLine("Triange area = {0:F2}", area);
    }
}
}
