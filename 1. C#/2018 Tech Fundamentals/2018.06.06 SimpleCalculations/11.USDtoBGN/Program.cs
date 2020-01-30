using System;

namespace _11.USDtoBGN
{
class Program
{
static void Main(string[] args)
{
    Console.Write("Input USD Amount: ");
    double USD = double.Parse(Console.ReadLine());

    double BGN = USD * 1.79549;
    Console.WriteLine("Your USD is equal to {1} BGN", USD, Math.Round(BGN,2));

}
}
}
