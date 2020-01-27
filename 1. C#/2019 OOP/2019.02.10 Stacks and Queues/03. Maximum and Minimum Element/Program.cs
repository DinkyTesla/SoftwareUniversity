
namespace _03._Maximum_and_Minimum_Element
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class Program
    {
        public static void Main()
        {
            var givenQueries = int.Parse(Console.ReadLine());

            var myStack = new Stack<int>();

            var sb = new StringBuilder();

            for (int i = 0; i < givenQueries; i++)
            {
                var input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

                var command = input[0];

                if (command == 1)
                {
                    var element = input[1];
                    myStack.Push(element);
                }

                else if (command == 2 && myStack.Any())
                {
                    myStack.Pop();
                }

                else if (command == 3 && myStack.Any())
                {
                    var biggestRemainingInteger = myStack.Max();

                    sb.AppendLine(string.Join("", biggestRemainingInteger));
                }

                else if (command == 4 && myStack.Any())
                {
                    var smallestRemainingInteger = myStack.Min();

                    sb.AppendLine(string.Join("", smallestRemainingInteger));

                }
            }

            sb.Append(string.Join(", ", myStack));
            Console.WriteLine(sb);
        }
    }
}
