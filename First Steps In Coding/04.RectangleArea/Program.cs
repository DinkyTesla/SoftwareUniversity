
namespace _04.RectangleArea
{
    using System;

    public class Program
    {
        public static void Main()
        {
            double SideA = double.Parse(Console.ReadLine());
            double SideB = double.Parse(Console.ReadLine());

            double area = SideA * SideB;

            Console.WriteLine(area);
        }
    }
}