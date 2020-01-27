
namespace _02._Basic_Queue_Operations
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Program
    {
        public static void Main()
        {
            var input = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            var givenIntegers = Console.ReadLine()
                .Split(" " ,StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            var elementsToEnque = input[0];
            var elementsToDeque = input[1];
            var elementToLookFor = input[2];

            var myQueue = new Queue<int>();

            for (int i = 0; i < elementsToEnque; i++)
            {
                var currentElement = givenIntegers[i];
                myQueue.Enqueue(currentElement);
            }
            for (int i = 0; i < elementsToDeque; i++)
            {
                myQueue.Dequeue();
            }

            if (myQueue.Any())
            {
                if (myQueue.Contains(elementToLookFor))
                {
                    Console.WriteLine("true");
                }
                else
                {
                    var smallestElement = int.MaxValue;
                    for (int i = 0; i < myQueue.Count; i++)
                    {
                        var testingElement = myQueue.Dequeue();
                        if (testingElement < smallestElement)
                        {
                            smallestElement = testingElement;
                        }
                        i--;
                    }
                    Console.WriteLine(smallestElement);
                }
            }
            else
            {
                Console.WriteLine("0");
            }
        }
    }
}
