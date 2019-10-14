using System;

namespace _405.UnitsConvertor
{
    class Program
    {
        static void Main(string[] args)
        {

            double value = double.Parse(Console.ReadLine());
            string inputValue = Console.ReadLine();
            string outputValue = Console.ReadLine();

            int mm = 1000;
            int cm = 100;
            double mi = 0.000621371192;
            double inches = 39.3700787;
            double km = 0.001;
            double feet = 3.2808399;
            double yards = 1.0936133;

            double resultInMeters = 0d;

            if (inputValue == "m")
            {
                resultInMeters = value;
            }
            else if ( inputValue == "mm")
            {
                resultInMeters = value /  mm;
            }
            else if ( inputValue == "cm")
            {
               resultInMeters =  value / cm;
            }
            else if (inputValue == "mi")
            {
                resultInMeters = value / mi;
            }
            else if (inputValue == "in")
            {
                resultInMeters = value / inches;
            }
            else if (inputValue == "km")
            {
                resultInMeters = value / km;
            }
            else if (inputValue == "ft")
            {
                resultInMeters = value / feet;
            }
            else if (inputValue == "yd")
            {
                resultInMeters = value / yards;
            }

            double finalResult = 0d;
            
            if (outputValue == "m")
            {
                finalResult = resultInMeters;
            }
            else if ( outputValue == "mm")
            {
                finalResult = resultInMeters * mm;
            }
            else if (outputValue == "cm")
            {
                finalResult = resultInMeters * cm;
            }
            else if (outputValue == "mi")
            {
                finalResult = resultInMeters * mi;
            }
            else if (outputValue == "in")
            {
                finalResult = resultInMeters * inches;
            }
            else if (outputValue == "km")
            {
                finalResult = resultInMeters * km;
            }
            else if (outputValue == "ft")
            {
                finalResult = resultInMeters * feet;
            }
            else if (outputValue == "yd")
            {
                finalResult = resultInMeters * yards;
            }

            Console.WriteLine($"{finalResult:F8}");
        }
    }
}
