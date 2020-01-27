
namespace _04._Fast_Food
{
    using System;
    using System.Linq;
    using System.Collections.Generic;

    public class Program
    {
        public static void Main()
        {
            var foodQuantity = int.Parse(Console.ReadLine());

            var orders = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            var myQueue = new Queue<int>(orders);

            var max = myQueue.Max();

            Console.WriteLine(max);

            //////////////////////////////////////
            while (myQueue.Any())
            {
                if (foodQuantity >= myQueue.Peek())
                {
                    var nextOrder = myQueue.Dequeue();
                    foodQuantity -= nextOrder;
                }
                else
                {
                    break;
                }
            }

            if (myQueue.Any())
            {

                Console.WriteLine($"Orders left: {string.Join(" ", myQueue)}");
            }
            else
            {
                Console.WriteLine("Orders complete");
            }
        }
    }
}
