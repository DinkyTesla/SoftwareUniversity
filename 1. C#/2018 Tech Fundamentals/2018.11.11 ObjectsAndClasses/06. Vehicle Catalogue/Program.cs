using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _06._Vehicle_Catalogue
{
    public class Vehicle
    {
        public Vehicle(string typeOf, string make, string color, int horsePower)
        {
            TypeOf = typeOf;
            Make = make;
            Color = color;
            HorsePower = horsePower;
        }

        public string TypeOf { get; set; }

        public string Make { get; set; }

        public string Color { get; set; }

        public int HorsePower { get; set; }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Type: {this.TypeOf}");
            sb.AppendLine($"Model: {this.Make}");
            sb.AppendLine($"Color: {this.Color}");
            sb.Append($"Horsepower: {this.HorsePower}");
            return sb.ToString();
        }
    }

    public class Program
    {
        public static void Main()
        {
            List<Vehicle> vehicles = new List<Vehicle>();
            string input = Console.ReadLine();
            int carCounter = 0;
            int truckCounter = 0;
            while (true)
            {
               
                if (input == "End")
                {
                    break;
                }
                string[] splitedInput = input
                   .Split(" ");

                string typeOfWithLower = splitedInput[0].ToLower();
                string typeOf = string.Empty;
                    //typeOfWithLower.First().ToString().ToUpper() + typeOfWithLower.Substring(1);

                if (typeOfWithLower == "car" )
                {
                    typeOf = "Car";
                    carCounter++;
                }
                else
                {
                    typeOf = "Truck";
                    truckCounter++;
                }
                string make = splitedInput[1];
                string color = splitedInput[2];
                int horsePower = int.Parse(splitedInput[3]);

                Vehicle vehicle = new Vehicle(typeOf, make, color, horsePower);

                vehicles.Add(vehicle);
                input = Console.ReadLine();
            }
            string model = Console.ReadLine();
            while (true)
            {
                if (model == "Close the Catalogue")
                {
                    break;
                }

                Vehicle vehicle = vehicles.Find(v => v.Make == model);
                Console.WriteLine(vehicle);
                model = Console.ReadLine();

            }

            if (carCounter > 0)
            {
            var avrgCarHP= vehicles.FindAll(v=>v.TypeOf=="Car").Average(x => x.HorsePower);
            Console.WriteLine($"Cars have average horsepower of: {avrgCarHP:f2}.");
            }
            else
            {
                Console.WriteLine($"Cars have average horsepower of: {0:f2}.");
            }
            if (truckCounter > 0)
            {
            var avrgTruckHP = vehicles.FindAll(v => v.TypeOf == "Truck").Average(x => x.HorsePower);
            Console.WriteLine($"Trucks have average horsepower of: {avrgTruckHP:f2}.");
            }
            else
            {
                Console.WriteLine($"Trucks have average horsepower of: {0:f2}.");
            }
        }
    }
}
