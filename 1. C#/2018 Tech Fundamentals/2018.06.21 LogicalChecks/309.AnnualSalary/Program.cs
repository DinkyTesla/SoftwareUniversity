using System;


namespace _309.AnnualSalary
{
    class Program
    {
        static void Main(string[] args)
        {

            int yearsExperience = int.Parse(Console.ReadLine());
            string specialisation = Console.ReadLine();

            double salary = 0;
            if (specialisation == "C# Developer")
            {
                salary = 5_400;
            }
            else if (specialisation == "Java Developer")
            {
                salary = 5_700;
            }
            else if (specialisation == "Front-End Web Developer")
            {
                salary = 4_100;
            }
            else if (specialisation == "UX / UI Designer")
            {
                salary = 3_100;
            }
            else if (specialisation == "Game Designer")
            {
                salary = 3_600;
            }

            if (yearsExperience <= 5)
            {
                salary = salary * 34.2 / 100;
            }
            double totalEarnedMoney = salary * 12;
            Console.WriteLine($"Total earned money {totalEarnedMoney}");
        }
    }
}
