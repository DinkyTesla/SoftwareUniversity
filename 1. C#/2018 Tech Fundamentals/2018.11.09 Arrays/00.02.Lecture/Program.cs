using System;

namespace _00._02.Lecture
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = { 1, 2, 3, 4, 5 }; //и така може да се създаде масив с конкретни стойности.

            string[] weekDays = new string[7];

            weekDays[0] = "Mon";

            //или

            string[] newWeekDays =
            {
                "Monday",
                "Tuesday",
                "Wednsday",
                "Thursday",
                "Friday",
                "Saturday",
                "Sunday"
            };

            int day = int.Parse(Console.ReadLine());

            if (day < 1 || day > 7)
            {
                Console.WriteLine("Invalid day!");
            }
            else
            {
                Console.WriteLine(newWeekDays[day-1]);
            }



        }
    }
}
