using System;


namespace _60.NewHope
{
    class Program
    {
        static void Main(string[] args)
        {
            int distance = int.Parse(Console.ReadLine());
            string timeOfDay = Console.ReadLine().ToLower();

            if (distance >= 100)
            {
                double train = distance * 0.06;
                Console.WriteLine($"{train:F2}");
            }
            else if ( distance < 100 && distance >= 20)
            {
                double bus = distance * 0.09;
                Console.WriteLine($"{bus:F2}");
            }
            else
            {
                if (timeOfDay == "day")
                {
                    double taxiDay = (distance * 0.79) + 0.70;
                    Console.WriteLine($"{taxiDay:F2}");
                }
                else if ( timeOfDay == "night")
                {
                    double taxiNight = (distance * 0.9) + 0.70;
                    Console.WriteLine($"{taxiNight:F2}");
                }
            }

        }
    }
}
