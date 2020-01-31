using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lecture._02
{
    public class Program
    {
        public static void Main()
        {
            var dict = new SortedDictionary<string, int>();

            dict["Ivan"] = 6;

            dict["Pesho"] = 7;

            dict["Ana"] = 10;


            foreach (var nameToMark in dict)
            {
                Console.WriteLine($"{nameToMark.Key} -> {nameToMark.Value}");
            }
        }
    }
}
