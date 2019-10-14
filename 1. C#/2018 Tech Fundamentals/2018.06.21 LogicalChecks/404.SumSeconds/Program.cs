using System;


namespace _404.SumSeconds
{
    class Program
    {
        static void Main(string[] args)
        {

            int num1 = int.Parse(Console.ReadLine());
            int num2 = int.Parse(Console.ReadLine());
            int num3 = int.Parse(Console.ReadLine());

            int result = num1 + num2 + num3;


            int minutes = result / 60;
            int seconds = result % 60;

            Console.WriteLine($"{minutes}:{seconds:d2}");


        }
    }
}
