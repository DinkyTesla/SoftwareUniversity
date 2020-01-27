
namespace _01.Vehicles
{
    using System;
    using Models;

    public class Program
    {
        public static void Main()
        {
            var carArgs = Console.ReadLine()
                .Split();

            double carFuelQuantity = double.Parse(carArgs[1]);
            double carFuelConsumption = double.Parse(carArgs[2]);

            Car car = new Car(carFuelQuantity, carFuelConsumption);

            var truckArgs = Console.ReadLine()
                .Split();

            double truckFuelQuantity = double.Parse(truckArgs[1]);
            double truckFuelConsumption = double.Parse(truckArgs[2]);

            var numberOfCommands = int.Parse(Console.ReadLine());

            Truck truck = new Truck(truckFuelQuantity, truckFuelConsumption);

            for (int i = 0; i < numberOfCommands; i++)
            {
                string[] commandArgs = Console.ReadLine()
                    .Split();

                string command = commandArgs[0];
                string commandType = commandArgs[1];

                if (true)
                {

                }

            }

        }
    }
}
