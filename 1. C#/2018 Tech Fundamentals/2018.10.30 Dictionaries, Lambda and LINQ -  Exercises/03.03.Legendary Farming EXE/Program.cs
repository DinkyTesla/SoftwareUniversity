using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.Collections.Generic;

namespace _03._03.Legendary_Farming_EXE
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> keyMaterials = new Dictionary<string, int>();
            keyMaterials.Add("motes", 0);
            keyMaterials.Add("shards", 0);
            keyMaterials.Add("fragments", 0);
            Dictionary<string, int> junkMaterials = new Dictionary<string, int>();

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
                        keyMaterials[material] += quantity;

                        if (keyMaterials[material] >= 250)
                        {
                            keyMaterials[material] -= 250;

                            if (material == "shards")
                            {
                                Console.WriteLine($"Shadowmourne obtained");
                            }
                            else if (material == "motes")
                            {
                                Console.WriteLine($"Dragonwrath obtained");
                            }
                            else
                            {
                                Console.WriteLine($"Valanyr obtained");
                            }

                        }
                        if (hasToBreak)
                        {
                            break;
                        }

                    }
                }
            }
        }
    }
}
