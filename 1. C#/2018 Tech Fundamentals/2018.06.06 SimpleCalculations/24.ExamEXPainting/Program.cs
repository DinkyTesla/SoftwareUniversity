using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _24.ExamEXPainting
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Въведете височина на къщата: ");
            double houseHeight = double.Parse(Console.ReadLine());
            Console.WriteLine("Въведете страничната стена на къщата:");
            double sideLenght = double.Parse(Console.ReadLine());
            Console.WriteLine("Въведете вичосина на покрива:");
            double roofHeight = double.Parse(Console.ReadLine());

            //Wall
            double windowArea = 1.5 * 1.5;
            double doorArea = 1.2 * 2;
            double sideArea = ((sideLenght * houseHeight) - windowArea) * 2;
            double frontArea = ((houseHeight * houseHeight) * 2) - doorArea;

            //Roof
            double roofSide = (houseHeight * sideLenght) * 2;
            double roofFront = 2 * (houseHeight * roofHeight / 2 );

            double houseArea = sideArea + frontArea;
            double roofArea = roofSide + roofFront;


            double greenPaint = houseArea / 3.4;
            double redPaint = roofArea / 4.3;

            
            Console.WriteLine("Ще бъдат нужни {0:F2} литра зелена боя.", greenPaint);
            Console.WriteLine("Ще бъдат нужни {0:F2} литра червена боя.", redPaint);

        }
    }
}
