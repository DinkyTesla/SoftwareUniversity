using System;
using System.Globalization;

namespace _13.TimePlus15Minutes
{
    class Program
    {
        static void Main(string[] args)
        {
            int hours = int.Parse(Console.ReadLine());
            int minutes = int.Parse(Console.ReadLine());

            string currentTime = $"{hours}:{minutes}";

            DateTime time = DateTime.ParseExact(currentTime, "H:m", CultureInfo.InvariantCulture);

            time = time.AddMinutes(15);

            Console.WriteLine($"{time.Hour}:{time.Minute:D2}");
        }
    }
}
