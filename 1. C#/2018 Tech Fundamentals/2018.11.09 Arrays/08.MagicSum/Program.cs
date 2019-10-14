using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _08.MagicSum
{
    public class Program
    {
        public static void Main()
        {
            int[] givenArray = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

            int wantedSum = int.Parse(Console.ReadLine());

            for (int i = 0; i < givenArray.Length; i++)
            {
                for (int j = i+1; j < givenArray.Length; j++)
                {
                    if (givenArray[i]+givenArray[j] == wantedSum)
                    {
                        Console.WriteLine(givenArray[i] + " " + givenArray[j]);
                    }
                }
            }

        }
    }
}
