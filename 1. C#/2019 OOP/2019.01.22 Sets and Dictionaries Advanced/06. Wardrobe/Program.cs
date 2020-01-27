
namespace _06._Wardrobe
{
    using System;
    using System.Collections.Generic;

    public class Program
    {
        public static void Main()
        {
            var numberOfClothes = int.Parse(Console.ReadLine());

            var myClothes = new Dictionary<string, Dictionary<string, int>>();

            for (int i = 0; i < numberOfClothes; i++)
            {
                string[] tokens = Console.ReadLine()
                    .Split(" -> ", StringSplitOptions.RemoveEmptyEntries);

                var color = tokens[0];
                var correspondingClothes = tokens[1].Split(',');

                if (!myClothes.ContainsKey(color))
                {
                    myClothes.Add(color, new Dictionary<string, int>());
                }

                foreach (var item in correspondingClothes)
                {
                    if (!myClothes[color].ContainsKey(item))
                    {
                        myClothes[color].Add(item, 0);
                    }
                    myClothes[color][item]++;
                }
            }

            var clothesToSearchFor = Console.ReadLine().Split();
            var colorToSearchFor = clothesToSearchFor[0];
            var itemToSearchFor = clothesToSearchFor[1];

            foreach (var kvp in myClothes)
            {
                Console.WriteLine($"{kvp.Key} clothes:");

                foreach (var item in kvp.Value)
                {
                    if (item.Key == itemToSearchFor && kvp.Key == colorToSearchFor)
                    {
                        Console.WriteLine($"* {item.Key} - {item.Value} (found!)");
                    }
                    else
                    {
                        Console.WriteLine($"* {item.Key} - {item.Value}");
                    }
                }
            }
        }
    }
}
