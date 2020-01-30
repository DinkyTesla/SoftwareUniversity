using System;
using System.Linq;

namespace _22._04._Array_Rotation
{
    public class Program
    {
        public static void Main()
        {
            int[] givenArray = Console.ReadLine()
                .Split(" ")
                .Select(int.Parse)
                .ToArray();

            int rotations = int.Parse(Console.ReadLine());

            for (int i = 0; i < rotations % givenArray.Length; i++)
            {
                
                int firstInt = givenArray[0];

                for (int j = 0; j < givenArray.Length - 1; j++)
                {
                    givenArray[j] = givenArray[j + 1];
                }

                givenArray[givenArray.Length - 1] = firstInt;
            }

            Console.WriteLine(string.Join(" ", givenArray));
        }
    }
}
