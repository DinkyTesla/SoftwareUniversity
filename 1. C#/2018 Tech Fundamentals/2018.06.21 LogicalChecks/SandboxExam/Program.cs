using System;


namespace SandboxExam
{
    class Program
    {
        static void Main(string[] args)
        {
            double widthA = double.Parse(Console.ReadLine());
            double lenghtB = double.Parse(Console.ReadLine());
            double sandPrice = double.Parse(Console.ReadLine());
            double plankPrice = double.Parse(Console.ReadLine());

            double boxArea = widthA * lenghtB;
            double sandboxArea = (widthA - (0.2 + 0.2)) * (lenghtB - (0.2 + 0.2));
            double sideWalk = Math.Round((boxArea - sandboxArea),2) ;
            double sandNeeded = Math.Ceiling( sandboxArea * 20);
            double planksNeeded = Math.Ceiling(sideWalk / (2.2 * 0.2));
            double sandCost = sandPrice * sandNeeded;
            double plankCost = planksNeeded * plankPrice;
            double price = sandCost + plankCost;

            Console.WriteLine($"{price:F2}");

        }
    }
}
