
namespace _01._Basic_Stack_Operations
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Program
    {
        public static void Main()
        {
            var input = Console.ReadLine().Split();
            var givenIntegers = Console.ReadLine().Split();

            var elementsToPush = int.Parse(input[0]);
            var elementsToPop = int.Parse(input[1]);
            var elementToLookFor = int.Parse(input[2]);

            var stack = new Stack<int>();

            for (int i = 0; i < elementsToPush; i++)
            {
                var pushUp = int.Parse(givenIntegers[i]);
                stack.Push(pushUp);
            }
            for (int i = 0; i < elementsToPop; i++)
            {
                stack.Pop();
            }
            if (stack.Any())
            {
                if (stack.Contains(elementToLookFor))
                {
                    Console.WriteLine("true");
                }
                else
                {
                    var smallestRemainingInteger = int.MaxValue;

                    for (int i = 0; i < stack.Count; i++)
                    {
                        var testInteger = stack.Pop();
                        if (testInteger < smallestRemainingInteger)
                        {
                            smallestRemainingInteger = testInteger;
                        }
                    }

                    Console.WriteLine(smallestRemainingInteger);
                }
            }
            else
            {
                Console.WriteLine("0");
            }
        }
    }
}
