
namespace _01.ClubParty
{
    using System;
    using System.Linq;
    using System.Collections.Generic;

    public class Program
    {
        public static void Main()
        {
            var capacity = int.Parse(Console.ReadLine());

            var hallsInput = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Reverse()
                .ToArray();
            ///////////////////////////////////////////////////////
            Stack<int> values = new Stack<int>();
            Queue<char> halls = new Queue<char>();

            var counter = 0;

            for (int i = 0; i < hallsInput.Length; i++)
            {

                var currentInput = hallsInput[i];

                
                if (int.TryParse(currentInput, out int inputIsDigit))
                {
                    if (!halls.Any())
                    {
                        continue;
                    }

                    values.Push(inputIsDigit);

                    var sum = values.Sum();

                    if (sum == capacity)
                    {
                        var hall = halls.Dequeue();
                        var value = string.Join(", ", values.Reverse());

                        Console.WriteLine($"{hall} -> {value}");

                        values.Clear();
                    }
                    else if (sum > capacity)
                    {
                        var valueToInput = values.Pop();

                        var hall = halls.Dequeue();
                        var value = string.Join(", ", values.Reverse());

                        Console.WriteLine($"{hall} -> {value}");

                        values.Clear();

                        if (!halls.Any())
                        {
                            continue;
                        }

                        values.Push(valueToInput);
                        

                    }
                    else if (sum < capacity)
                    {
                        continue;
                    }

                }
                else if (char.TryParse(currentInput, out char inputIsChar))
                {
                    halls.Enqueue(inputIsChar);
                }
            }
        }
    }
}
