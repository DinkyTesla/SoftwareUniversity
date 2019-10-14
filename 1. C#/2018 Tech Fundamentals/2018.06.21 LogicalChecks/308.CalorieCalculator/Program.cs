using System;


namespace _308.CalorieCalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            char gender = char.Parse(Console.ReadLine());
            double weightInKg = double.Parse(Console.ReadLine());
            double heightInMeters = double.Parse(Console.ReadLine());
            int age = int.Parse(Console.ReadLine());
            string levelOfActivity = Console.ReadLine();

            double bnm = 0;

            if (gender == 'm')
            {
                bnm = 66 + (13.7 * weightInKg) + (500 * heightInMeters) - (6.8 * age);
            }
            else if (gender == 'f')
            {
                bnm = 655 + (9.6 * weightInKg) + (180 * heightInMeters) - (4.7 * age);
            }

            double coef = 0;
            if (levelOfActivity == "sedentary")
            {
                coef = 1.2;
            }
            else if ( levelOfActivity == "lightly active")
            {
                coef = 1.375;
            }
            else if (levelOfActivity == "moderately active")
            {
                coef = 1.55;
            }
            else if (levelOfActivity == "very active")
            {
                coef = 1.725;
            }
            double totalCalories = Math.Ceiling( bnm * coef);
            Console.WriteLine("To maintain your current weight you will need {0} calories per day.", totalCalories );
        }
    }
}
