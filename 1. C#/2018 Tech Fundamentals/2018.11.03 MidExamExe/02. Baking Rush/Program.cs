using System;
using System.Collections.Generic;
using System.Linq;

namespace _02.Baking_Rush
{
    class Program
    {
        static void Main(string[] args)
        {
            int energy = 100;
            int coins = 100;

            List<string> inputList = new List<string>(Console.ReadLine()
                .Split('|', '-')
                .ToList());


            for (int i = 0; i < inputList.Count - 1; i++)
            {

                if (inputList[i] == "rest")
                {
                    if (energy >= 100)
                    {
                        energy = 100;
                        Console.WriteLine("You gained 0 energy.");
                        Console.WriteLine("Current energy: 100.");
                        i++;

                    }
                    else
                    {
                        energy += int.Parse(inputList[i + 1]);
                        Console.WriteLine($"You gained {inputList[i + 1]} energy.");
                        Console.WriteLine($"Current energy: {energy}.");
                        if (energy > 100)
                        {
                            energy = 100;
                        }
                        i++;
                    }
                }
                else if (inputList[i] == "order")
                {
                    if (energy >= 30)
                    {
                        coins += int.Parse(inputList[i + 1]);
                        Console.WriteLine($"You earned {inputList[i + 1]} coins.");
                        energy -= 30;
                        i++;
                    }
                    else
                    {
                        energy += 50;
                        Console.WriteLine("You had to rest!");
                        i ++; 
                        // Skips the next step. Maybe should skip several step till the orded it should skip. 
                       
                    }
                }
                else if (i % 2 == 0 && inputList[i] != "order" && inputList[i] != "rest")
                {

                    if (coins - int.Parse(inputList[i+1]) > 0)
                    {
                        Console.WriteLine($"You bought {inputList[i]}.");
                        coins -= int.Parse(inputList[i+1]);
                        
                    }
                    else
                    {
                        Console.WriteLine($"Closed! Cannot afford {inputList[i]}.");
                        return;
                    }

                }
            }
            if (coins >= 0)
            {
                Console.WriteLine("Day completed!");
                Console.WriteLine($"Coins: {coins}");
                Console.WriteLine($"Energy: {energy}");
            }
        }
    }
}
