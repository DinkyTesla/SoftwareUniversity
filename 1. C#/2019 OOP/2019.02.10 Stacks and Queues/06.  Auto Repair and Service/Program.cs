
namespace _06.__Auto_Repair_and_Service
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class Program
    {
        public static void Main()
        {
            var carsToService = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);

            var workQueue = new Queue<string>(carsToService);
            var historyQueue = new Stack<string>();

            var command = Console.ReadLine();

            while (command != "End" )
            {
                if (command == "Service" && workQueue.Any())
                {
                    var servicedCar = workQueue.Dequeue();
                    Console.WriteLine($"Vehicle {servicedCar} got served.");
                    historyQueue.Push(servicedCar);
                }
                else if (command == "History")
                {
                    var historyCommand = string.Join(", ", historyQueue);
                    Console.WriteLine(historyCommand);
                }
                else if (command.Contains("CarInfo"))
                {
                    string[] myTest = command.Split("-");
                    var car = myTest[1];

                    if (historyQueue.Contains(car))
                    {
                        Console.WriteLine("Served.");
                    }
                    else
                    {
                        Console.WriteLine("Still waiting for service.");
                    }
                }

                command = Console.ReadLine();
            }

            var historySB = new StringBuilder();
            var waitingSB = new StringBuilder();
            waitingSB.Append(string.Join(", ", workQueue));
            historySB.Append(string.Join(", ", historyQueue));

            if (workQueue.Any())
            {
                Console.WriteLine($"Vehicles for service: {waitingSB}");
            }
            if (historyQueue.Any())
            {
                Console.WriteLine($"Served vehicles: {historySB}");
            }
        }
    }
}
