using System;


namespace _08.TriangleArea
{
class Program
{
static void Main(string[] args)
{
        Console.WriteLine("Input side A: ");
        double sideA = double.Parse(Console.ReadLine());

        Console.WriteLine("Input side Height: ");
        double height = double.Parse(Console.ReadLine());

        double area = sideA * height / 2.0;
            
        Console.WriteLine("Area = {0}", Math.Round(area, 2));
}
}
}
