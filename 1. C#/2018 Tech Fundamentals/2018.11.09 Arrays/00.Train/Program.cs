using System;

namespace _00.Train
{
    public class Program
    {
        public static void Main(string[] args)
        {
            int numberOfWagons = int.Parse(Console.ReadLine());
            int[] passangers = new int[numberOfWagons];
            int totalPassangers = 0;

            for (int i = 0; i < numberOfWagons; i++)
            {
                passangers[i] = int.Parse(Console.ReadLine());
                totalPassangers += passangers[i];
            }

            for (int i = 0; i < passangers.Length; i++)
            {
                Console.Write(passangers[i] + " ");
            }
            Console.WriteLine();
            Console.WriteLine(totalPassangers);
        }
    }
}