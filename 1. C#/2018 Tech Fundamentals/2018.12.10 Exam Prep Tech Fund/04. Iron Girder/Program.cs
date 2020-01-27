namespace _04._Iron_Girder
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Program
    {
        public static void Main()
        {
            string[] input = Console.ReadLine().Split(new string[] { ":", "->" },
                StringSplitOptions.RemoveEmptyEntries);

            Dictionary<string, int> townAndTime = new Dictionary<string, int>();
            Dictionary<string, int> townAndPassangers = new Dictionary<string, int>();

            while (input[0] != "Slide rule")
            {
                string town = input[0];
                int passengers = int.Parse(input[2]);

                if (input[1] == "ambush")
                {
                    if (townAndTime.ContainsKey(town))
                    {
                        townAndTime[town] = 0;
                        townAndPassangers[town] -= passengers;
                    }
                }
                else
                {
                    int time = int.Parse(input[1]);

                    if (townAndTime.ContainsKey(town) == false)
                    {
                        townAndTime.Add(town, time);
                        townAndPassangers.Add(town, 0);
                    }
                    townAndPassangers[town] += passengers;

                    if (townAndTime[town] > time || townAndTime[town] == 0)
                    {
                        townAndTime[town] = time;
                    }
                }

                input = Console.ReadLine().Split(new string[] { ":", "->" },
                StringSplitOptions.RemoveEmptyEntries);
            }

            foreach (var town in townAndTime.OrderBy(x => x.Value)
                .ThenBy(x => x.Key)
                .Where(x => x.Value != 0))
            {
                if (townAndPassangers[town.Key] > 0)
                {
                    Console.WriteLine($"{town.Key} -> Time: {town.Value} -> Passengers: {townAndPassangers[town.Key]}");
                }

            }
        }
    }
}