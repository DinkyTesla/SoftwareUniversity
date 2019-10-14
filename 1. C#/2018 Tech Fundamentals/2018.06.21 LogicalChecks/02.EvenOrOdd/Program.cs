using System;


namespace _02.EvenOrOdd
{
class Program
{
    static void Main(string[] args)
    {
        int num = int.Parse(Console.ReadLine());
        if (num % 2 == 0)
        {
            Console.WriteLine("Even");
        }
        else
        {
            Console.WriteLine("Odd");
        }
    }
}
}
