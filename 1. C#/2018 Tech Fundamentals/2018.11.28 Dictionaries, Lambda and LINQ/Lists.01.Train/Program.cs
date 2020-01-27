using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.Collections.Generic;

namespace Lists._01.Train
{
    public class Program
    {
        public static void Main()
        {
            var wagons = Console.ReadLine()
                .Split(' ')
                .Select(int.Parse)
                .ToList();

            var maxCapacity = int.Parse(Console.ReadLine());

            while (true)
            {
                var newWagon = Console.ReadLine();

                if (newWagon.Contains("end"))
                {
                    break;
                }
                else if (true)
                {
                    newWagon = new List<int>
                        .Split("Add ")
                    .Select(int.Parse)
                    .ToList();
                }


                //if ()
                //{
                //    wagons.Add(maxCapacity);
                //    wagons.Add(int.Parse(maxCapacity));
                //}
            }

            Console.WriteLine($"{wagons}");
        }
    }
}
