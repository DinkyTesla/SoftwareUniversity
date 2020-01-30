using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.Collections.Generic;

namespace _03.Legendary_Farming
{
    public class Program
    {
        public static void Main()
        {

            // Dictionary<string, int> legendaryItems = new Dictionary<string, int>(); // Main Items
            Dictionary<string, int> givenFragments = new Dictionary<string, int>(); // Console Input

            List<string> input = Console.ReadLine().ToLower()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .ToList();

            givenFragments.Add("fragments", 0);
            givenFragments.Add("shards", 0);
            givenFragments.Add("motes", 0);
            //givenFragments.Add("leathers", 0);
            //givenFragments.Add("stones", 0);

            int quantity = 0;

            for (int i = 0; i < input.Count; i++)
            {
                foreach (var kvp in givenFragments)
                {
                    if (kvp.Key == "shards" || kvp.Value >= 250 || kvp.Key == "fragments" || kvp.Key == "motes")
                    {
                        break;
                    }
                }

                if (i % 2 == 1)
                {
                    quantity = int.Parse(input[i]);
                }
                else
                {
                    if (givenFragments.ContainsKey(input[i])) 
                    {
                        
                        givenFragments[input[i]] += quantity;
                    }
                    else
                    {
                        givenFragments.Add(input[i], quantity);
                    }
                }

            }



            //•	Shadowmourne – requires 250 Shards;
            //•	Valanyr – requires 250 Fragments;
            //•	Dragonwrath – requires 250 Motes;

        }
    }
}
