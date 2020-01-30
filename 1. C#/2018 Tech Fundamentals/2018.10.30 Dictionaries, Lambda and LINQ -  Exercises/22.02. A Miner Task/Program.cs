using System;
using System.Linq;
using System.Collections.Generic;

namespace _22._02._A_Miner_Task
{
    public class Program
    {
        public static void Main()
        {
            var myDictionaryBaby = new Dictionary<string, int>();

            while (true)
            {
                string rocksBaby = Console.ReadLine();

                if (rocksBaby == "stop")
                {
                    break;
                }

                int quantityBaby = int.Parse(Console.ReadLine());

                if (myDictionaryBaby.Keys.Contains(rocksBaby))
                {
                    myDictionaryBaby[rocksBaby] += quantityBaby;
                }
                else
                {
                    myDictionaryBaby[rocksBaby] = quantityBaby;
                }
            }

            foreach (var kvp in myDictionaryBaby)
            {
                Console.WriteLine($"{kvp.Key} -> {kvp.Value}");
            }
        }
    }
}
