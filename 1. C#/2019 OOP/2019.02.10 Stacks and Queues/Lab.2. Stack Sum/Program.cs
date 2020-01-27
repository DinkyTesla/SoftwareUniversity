
namespace Lab._2._Stack_Sum
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Program
    {
        public static void Main()
        {
            var input = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            Stack<int> stack = new Stack<int>(input);

            var commandInfo = Console.ReadLine().ToLower();

            while (commandInfo != "end")
            {
                var tokens = commandInfo.Split();

                var command = tokens[0].ToLower();
                
                if (command == "add")
                {
                    var firstInt = int.Parse(tokens[1]);
                    var secondInt = int.Parse(tokens[2]);

                    stack.Push(firstInt);
                    stack.Push(secondInt);  
                }
                else if (command == "remove")
                {
                    var numbersToRemove = int.Parse(tokens[1]);

                    if (stack.Count < numbersToRemove)
                    {
                        continue;
                    }

                    for (int i = 0; i < numbersToRemove; i++)
                    {
                        stack.Pop();
                    }
                   
                }
                commandInfo = Console.ReadLine().ToLower();

            }

            var sum = stack.Sum();

            Console.WriteLine($"Sum: {sum}");
        }
    }
}
