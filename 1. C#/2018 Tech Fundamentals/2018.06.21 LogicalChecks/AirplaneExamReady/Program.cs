using System;


namespace AirplaneExamReady
{
    class Program
    {
        static void Main(string[] args)
        {
            int hours = int.Parse(Console.ReadLine());
            int minutes = int.Parse(Console.ReadLine());
            int flyLenght = int.Parse(Console.ReadLine());

            int hoursInMinutes = hours * 60;

            int result = hoursInMinutes + minutes + flyLenght;

            int hour = result / 60;
            int actualMinutes = result % 60;

            if (hour >= 24)
            {
                hour -= 24;
            }

            Console.WriteLine($"{hour}h {actualMinutes}m");
        }
    }
}
