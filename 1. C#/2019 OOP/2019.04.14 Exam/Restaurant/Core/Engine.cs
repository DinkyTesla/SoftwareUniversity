
namespace SoftUniRestaurant.Core
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class Engine
    {
        private RestaurantController restaurantController;

        public Engine()
        {
            this.restaurantController = new RestaurantController();
        }

        public void Run()
        {
            string input = Console.ReadLine();

            while (input != "END")
            {
                string[] commandArgs = input
                    .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                string command = commandArgs[0];
                string[] args = commandArgs.Skip(1).ToArray();

                string result = ReadCommand(command, args);

                Console.WriteLine(result);


                input = Console.ReadLine();
            }
        }

        private string ReadCommand(string command, string[] args)
        {
            string result = string.Empty;

            switch (command)
            {
                case "AddFood":
                    string type = args[0];
                    string name = args[1];
                    decimal price = decimal.Parse(args[2]);

                    result = this.restaurantController.AddFood(type, name, price);
                    break;

                case "AddDrink":
                    type = args[0];
                    name = args[1];
                    int servingSize = int.Parse(args[2]);
                    string brand = args[3];

                    result = this.restaurantController.AddDrink(type, name, servingSize, brand);
                    break;

                case "AddTable":
                    type = args[0];
                    int tableNumber = int.Parse(args[1]);
                    int capacity = int.Parse(args[2]);

                    result = this.restaurantController.AddTable(type, tableNumber, capacity);
                    break;

                case "ReserveTable":
                    int numberOfPeople = int.Parse(args[0]);

                    result = this.restaurantController.ReserveTable(numberOfPeople);
                    break;

                case "OrderFood":
                    tableNumber = int.Parse(args[0]);
                    string foodName = args[1];

                    result = this.restaurantController.OrderFood(tableNumber, foodName);
                    break;

                case "OrderDrink":
                    tableNumber = int.Parse(args[0]);
                    string drinkName = args[1];
                    string drinkBrand = args[2];

                    result = this.restaurantController.OrderDrink(tableNumber, drinkName, drinkBrand);
                    break;

                case "LeaveTable":
                    tableNumber = int.Parse(args[0]);

                    result = this.restaurantController.LeaveTable(tableNumber);
                    break;

                case "GetFreeTablesInfo":
                    result = restaurantController.GetFreeTablesInfo();
                    break;

                case "GetOccupiedTablesInfo":
                    result = restaurantController.GetOccupiedTablesInfo();
                    break;

                //default:
                //    break;
            }

            return result;
        }
    }
}
