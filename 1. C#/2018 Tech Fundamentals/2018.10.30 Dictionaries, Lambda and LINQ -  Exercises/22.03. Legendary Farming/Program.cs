using System;
using System.Linq;
using System.Collections.Generic;

namespace _22._03._Legendary_Farming
{
    public class Program
    {
        public static void Main()
        {

            // We give the list a starting position with the elements to collect.
            var legendaryMaterialsList = new Dictionary<string, int>();
            legendaryMaterialsList.Add("motes", 0);
            legendaryMaterialsList.Add("shards", 0);
            legendaryMaterialsList.Add("fragments", 0);

            //List for the not needed materials.
            var junkList = new Dictionary<string, int>();

            while (true)
            {
                string[] input = Console.ReadLine()
                    .Split();

                bool hasToBreak = false;

                for (int i = 0; i < input.Length; i += 2)
                {
                    int quantity = int.Parse(input[i]);
                    string material = input[i + 1].ToLower();

                    if (material == "shards" || material == "motes" || material == "fragments")
                    {
                        //We add the material in its rightful place.
                        legendaryMaterialsList[material] += quantity;

                        // We look if we have enough materials.
                        if (legendaryMaterialsList[material] >= 250)
                        {
                            legendaryMaterialsList[material] -= 250;

                            if (material == "shards")
                            {
                                Console.WriteLine($"Shadowmourne obtained!");
                            }
                            else if (material == "motes")
                            {
                                Console.WriteLine($"Dragonwrath obtained!");
                            }
                            else
                            {
                                Console.WriteLine($"Valanyr obtained!");
                            }
                            hasToBreak = true;
                            break;
                        }
                    }
                    else
                    {

                        if (!junkList.ContainsKey(material))
                        {
                            junkList[material] = 0;
                        }
                        junkList[material] += quantity;
                    }
                }

                if (hasToBreak)
                {
                    break;
                }
            }
            foreach (var kvp in legendaryMaterialsList.OrderByDescending(kvp => kvp.Value).ThenBy
                    (kvp => kvp.Key))
            {
                string material = kvp.Key;
                int quantity = kvp.Value;
                Console.WriteLine($"{material}: {quantity}");
            }

            foreach (var kvp in junkList.OrderBy(kvp => kvp.Key))
            {
                string material = kvp.Key;
                int quantity = kvp.Value;
                Console.WriteLine($"{material}: {quantity}");
            }
        }
    }
}