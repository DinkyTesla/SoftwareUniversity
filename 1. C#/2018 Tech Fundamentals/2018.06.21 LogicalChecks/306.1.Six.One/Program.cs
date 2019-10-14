using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _306._1.Six.One
{
    class Program
    {
        static void Main(string[] args)
        {
            int seconds1 = int.Parse(Console.ReadLine());
            int seconds2 = int.Parse(Console.ReadLine());
            int seconds3 = int.Parse(Console.ReadLine());
            int totalSeconds = seconds1 + seconds2 + seconds3;

            int minutes = totalSeconds / 60;
            int seconds = totalSeconds % 60;
        }
    }
}
