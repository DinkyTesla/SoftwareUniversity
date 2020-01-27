using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lecture._01
{
    public class Program
    {
        public static void Main()
        {
            var marks = new Dictionary<string, double>();

            marks["Pesho"] = 5.6;
            marks["Ivan"] = 4.7;
            marks["Maria"] = 6;

            double peshoMark = marks["Pesho"];

            Console.WriteLine($"Peshos Mark: {peshoMark}");

        }
    }
}
