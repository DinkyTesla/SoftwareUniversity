using System;
using System.Collections.Generic;
using System.Linq;

namespace _02.Baking_Rush
{
    class Program
    {
        static void Main(string[] args)
        {
            int health = 100;
            int coins = 0;

            List<string> inputList = new List<string>(Console.ReadLine()
                .Split('|', ' ')
                .ToList());

            int levelCounter = 1;

            for (int i = 0; i < inputList.Count - 1; i++)
            {

                if (inputList[i] == "potion")
                {
                    if (health >= 100)
                    {
                        health = 100;
                        Console.WriteLine("You healed for 0 hp.");
                        Console.WriteLine("Current health: 100 hp.");
                        levelCounter++;

                    }
                    else
                    {
                        int currentHealth = health;
                        health += int.Parse(inputList[i + 1]);
                        if (health > 100)
                        {
                            health = 100;
                        }
                        Console.WriteLine($"You healed for {health - currentHealth} hp.");
                        Console.WriteLine($"Current health: {health} hp.");
                        levelCounter++;
                    }
                }
                else if (inputList[i] == "chest")
                {
                    coins += int.Parse(inputList[i + 1]);
                    Console.WriteLine($"You found {inputList[i + 1]} coins.");
                    levelCounter++;

                }
                else if (i % 2 == 0 && inputList[i] != "potion" && inputList[i] != "coins")
                {

                    if (health - int.Parse(inputList[i + 1]) > 0)
                    {
                        Console.WriteLine($"You slayed {inputList[i]}.");
                        health -= int.Parse(inputList[i + 1]);
                        levelCounter++;
                    }
                    else
                    {
                        Console.WriteLine($"You died! Killed by {inputList[i]}.");
                        Console.WriteLine($"Best room: {levelCounter}");
                        levelCounter++;
                        return;
                    }
                }
            }
            if (health > 0)
            {
                Console.WriteLine("You've made it!");
                Console.WriteLine($"Coins: {coins}");
                Console.WriteLine($"Health: {health}");
            }
        }
    }
}
