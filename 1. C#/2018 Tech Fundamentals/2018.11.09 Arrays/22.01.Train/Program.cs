using System;
using System.Linq;

namespace _22._01.Train
{
    public class Program
    {
        public static void Main()
        {

            int givenWagons = int.Parse(Console.ReadLine());

            int[] trainLength = new int[givenWagons];

            for (int i = 0; i < givenWagons; i++)
            {
                trainLength[i] = int.Parse(Console.ReadLine());
            }

            int passangersSum = trainLength.Sum();
            Console.WriteLine(string.Join(" ", trainLength));
            Console.WriteLine(passangersSum);
        }
    }
}
