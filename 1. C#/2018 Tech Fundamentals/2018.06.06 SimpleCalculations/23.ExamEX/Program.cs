using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _23.ExamEX
{
class Program
{
    static void Main(string[] args)
    {
        double hallLenght = double.Parse(Console.ReadLine());
        double hallWidth = double.Parse(Console.ReadLine());
        double wardrobeSide = double.Parse(Console.ReadLine()) * 100;

        double hallArea = (hallLenght * 100) * (hallWidth * 100);
        double wardrobeArea = wardrobeSide * wardrobeSide;
        double benchArea = hallArea / 10;

        double freeSpace = hallArea - wardrobeArea - benchArea;

        double finalSpace = freeSpace / (40 + 7000);

        Console.WriteLine(Math.Floor(finalSpace));
    }
}
}
