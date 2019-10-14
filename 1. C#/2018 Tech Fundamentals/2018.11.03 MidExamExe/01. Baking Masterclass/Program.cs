using System;

namespace _01._Baking_Masterclass
{
    public class Program
    {
        public static void Main()
        {
            double startingBudget = double.Parse(Console.ReadLine());
            int numberOfStudents = int.Parse(Console.ReadLine());
            double flourPrice = double.Parse(Console.ReadLine());
            double eggsPrice = double.Parse(Console.ReadLine());
            double apronPrice = double.Parse(Console.ReadLine());

            if (numberOfStudents == 0)
            {
                Console.WriteLine($"Items purchased for {0:F2}$.");
                return;
            }

            int freePackages = 0;

            if (numberOfStudents % 5 == 0)
            {
                for (int i = 0; i < numberOfStudents / 5; i++)
                {
                    freePackages++;
                }
            }

            double apronMix = apronPrice * Math.Ceiling(numberOfStudents * 1.2);
            double eggsMix = eggsPrice * 10 * numberOfStudents;
            double flourMix = flourPrice * (numberOfStudents - freePackages);

            double ingredientsBudget = apronMix + eggsMix + flourMix;

            if (startingBudget >= ingredientsBudget)
            {
                Console.WriteLine($"Items purchased for {ingredientsBudget:F2}$.");
            }
            else
            {
                double notEnougBudget = ingredientsBudget - startingBudget;
                Console.WriteLine($"{notEnougBudget:F2}$ more needed.");
            }
        }
    }
}
