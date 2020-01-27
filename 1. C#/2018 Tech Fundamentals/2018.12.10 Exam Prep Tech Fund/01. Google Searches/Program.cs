namespace _01._Google_Searches
{
    using System;
    public class Program
    {
        public static void Main()
        {
            int totalDays = int.Parse(Console.ReadLine());
            int numberOfUsers = int.Parse(Console.ReadLine());
            double moneyPerDay = double.Parse(Console.ReadLine());

            double totalMoney = 0.0;

            for (int i = 1; i <= numberOfUsers; i++)
            {
                int wordsInRange = int.Parse(Console.ReadLine());

                if (wordsInRange > 5)
                {
                    continue;
                }

                double moneyForTheSearch = moneyPerDay;

                if (wordsInRange == 1)
                {
                    moneyForTheSearch *= 2;
                }

                if (i % 3 == 0)
                {
                    moneyForTheSearch *= 3;
                }

                moneyForTheSearch *= totalDays;
                totalMoney += moneyForTheSearch;
            }

            Console.WriteLine($"Total money earned for {totalDays} days: {totalMoney:F2}");
        }
    }
}