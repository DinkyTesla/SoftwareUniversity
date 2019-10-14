using System;
using System.Linq;

namespace _04.Array_Rotation
{
    public class Program
    {
        public static void Main(string[] args)
        {
            int[] givenArray = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            int rotations = int.Parse(Console.ReadLine());

            for (int i = 0; i < rotations % givenArray.Length; i++) //Тук използваме трик за да не въртим излишни цикли.
            {
                int firstElement = givenArray[0];

                for (int j = 0; j < givenArray.Length - 1; j++)
                {
                givenArray[j] = givenArray[j + 1];

                }
                givenArray[givenArray.Length  - 1] = firstElement;

            }
            Console.WriteLine(string.Join(" ", givenArray));
        }
    }
}