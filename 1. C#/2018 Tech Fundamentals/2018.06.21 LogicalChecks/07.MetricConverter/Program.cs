using System;


namespace _07.MetricConverter
{
    class Program
    {
        static void Main(string[] args)
        {

            double units = double.Parse(Console.ReadLine());
            string inputUnints = Console.ReadLine().ToLower();
            string outputUnits = Console.ReadLine().ToLower();
            double meters = 1d;

            if (inputUnints == "mm" )
            {
                    meters = units  / 1000;
            }
            else if (inputUnints == "cm")
            {
                meters = units / 100;
            }
            else if (inputUnints == "mi")
            {
                meters = units / 0.000621371192;
            }
            else if (inputUnints == "in")
            {
                meters = units / 39.3700787;
            }
            else if (inputUnints == "km")
            {
                meters = units / 0.001;
            }
            else if (inputUnints == "ft")
            {
                meters = units / 3.2808399;
            }
            else if (inputUnints == "yd")
            {
                meters = units / 1.0936133;
            }
            else if (inputUnints == "m")
            {
                meters = units;
            }


            double result = 0d;


            if (outputUnits == "mm")
            {
                result = meters * 1000;
            }
            else if (outputUnits == "cm")
            {
                result = meters * 100;
            }
            else if (outputUnits == "mi")
            {
                result = meters * 0.000621371192;
            }
            else if (outputUnits == "in")
            {
                result = meters * 39.3700787;
            }
            else if (outputUnits == "km")
            {
                result = meters * 0.001;
            }
            else if (outputUnits == "ft")
            {
                result = meters * 3.2808399;
            }
            else if (outputUnits == "yd")
            {
                result = meters * 1.0936133;
            }
            else if (outputUnits == "m")
            {
                result = meters;
            }
                Console.WriteLine($"{result:f8} {outputUnits}");


        }
    }
}
