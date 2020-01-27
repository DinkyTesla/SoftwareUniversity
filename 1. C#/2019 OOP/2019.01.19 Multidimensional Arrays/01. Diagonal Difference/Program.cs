
namespace _01._Diagonal_Difference
{
    using System;
    using System.Linq;

    public class Program
    {
        public static void Main()
        {
            var mSize = int.Parse(Console.ReadLine());

            int[,] intMatrix = new int[mSize, mSize];

            var primaryDSum = 0;
            var secondaryDSum = 0;

            for (int row = 0; row < intMatrix.GetLength(0); row++)
            {
                int[] colElements = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                for (int col = 0; col < intMatrix.GetLength(1); col++)
                {
                    intMatrix[row, col] = colElements[col];
                }
            }

            for (int i = 0; i < mSize; i++)
            {
                primaryDSum += intMatrix[i, i];
                secondaryDSum += intMatrix[i, (mSize - 1) - i];
            }
            var result = Math.Abs(primaryDSum - secondaryDSum);
            Console.WriteLine(result);
        }
    }
}
