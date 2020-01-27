
namespace _02._2x2_Squares_in_Matrix
{
    using System;
    using System.Linq;

    public class Program
    {
        public static void Main()
        {
            int[] input = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            var rows = input[0];
            var cols = input[1];

            char[,] matrix = new char[rows, cols];

            int count = 0;

            for (int row = 0; row < rows; row++)
            {
                char[] colElements = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(char.Parse)
                .ToArray();

                for (int col = 0; col < cols; col++)
                {
                    matrix[row, col] = colElements[col];
                }
            }

            char letter = matrix[0, 0];

            for (int row = 0; row < rows - 1; row++)
            {
                for (int col = 0; col < cols - 1; col++)
                {
                    char check = matrix[row, col + 1];

                    letter = matrix[row, col];

                    if (letter == check)
                    {
                        char temp = matrix[row + 1, col];

                        if (letter == temp)
                        {
                            temp = matrix[row + 1, col + 1];
                            if (letter == temp)
                            {
                                count++;
                            }
                        }
                    }
                    else
                    {
                        letter = check;
                        continue;
                    }
                }
            }

            Console.WriteLine(count);
        }
    }
}
