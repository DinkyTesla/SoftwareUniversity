using System;


namespace _51.Exam7JanuaryAirplane
{
    class Program
    {
        static void Main(string[] args)
        {
            int takeoffHour = int.Parse(Console.ReadLine());
            int takeoffMinutes = int.Parse(Console.ReadLine());
            int flightLenght = int.Parse(Console.ReadLine());

            int flightHours = flightLenght / 60;
            int flightMinutes = flightLenght % 60;

            

            int landingHours = takeoffHour + flightHours;
            int landingMinutes = takeoffMinutes + flightMinutes;

            if (landingMinutes > 60)
            {
                landingHours++;
                landingMinutes %= 60;   // possible -=
            }
            if (landingHours >= 24)
            {
                landingHours %= 24;  // possible landingHours -= 24;
            }

            string landingTime = $"{landingHours}h {landingMinutes}m";

            Console.WriteLine(landingTime);
        }
    }
}
