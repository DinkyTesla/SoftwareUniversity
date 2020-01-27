using System;
using System.Linq;
using System.Collections.Generic;

namespace Lists._04.Array_Rotation
{
    public class Program
    {
        public static void Main()
        {
            List<int> givenList = new List<int>(Console.ReadLine()
                .Split(' ')
                .Select(int.Parse)
                .ToList());

            List<int> rotatedList = new List<int>(givenList);

            int rotations = int.Parse(Console.ReadLine());
            int firstRotated = 0;
           
                for (int i = 0; i < rotations % givenList.Count; i++) // Трик за по-малко ротации.
                {
                    firstRotated = rotatedList[0];

                    for (int j = 0; j < rotatedList.Count - 1; j++)
                    {
                        rotatedList[j] = rotatedList[j + 1];

                    }
                    rotatedList[rotatedList.Count - 1] = firstRotated;
                }

            Console.WriteLine(string.Join(' ', rotatedList));
        }

    }
}
