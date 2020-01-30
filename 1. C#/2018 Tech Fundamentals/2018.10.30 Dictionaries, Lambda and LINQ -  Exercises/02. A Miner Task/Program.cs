using System;
using System.Collections.Generic;
using System.Linq;

namespace _02._A_Miner_Task
{
    public class Program
    {
        public static void Main()
        {

            var typesAndQuantity = new Dictionary<string, int>();

            while (true)
            {
                string typeOfRock = Console.ReadLine();

                if (typeOfRock == "stop")
                {
                    break;
                }
                int rockQuantity = int.Parse(Console.ReadLine());

                if (typesAndQuantity.Keys.Contains(typeOfRock))
                {
                    typesAndQuantity[typeOfRock] += rockQuantity;
                }
                else
                {
                    typesAndQuantity[typeOfRock] = rockQuantity;
                }

            }
            foreach (var kvp in typesAndQuantity)
            {
                Console.WriteLine($"{kvp.Key} -> {kvp.Value}");
            }

        }
    }
}
