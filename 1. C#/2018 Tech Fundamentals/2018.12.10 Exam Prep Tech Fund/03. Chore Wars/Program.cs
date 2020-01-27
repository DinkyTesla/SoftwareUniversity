namespace _03._Chore_Wars
{
    using System;
    using System.Text.RegularExpressions;

    public class Program
    {
        public static void Main()
        {
            int timeDishes = 0;
            int timeCleaning = 0;
            int timeLaundry = 0;
            int totalMinutes = 0;

            string dishesPattern = @"(?<=<)[a-z0-9]+(?=>)";
            string cleaningPattern = @"(?<=\[)[A-Z0-9]+(?=\])";
            string laundryPattern = @"(?<={).+(?=\})";

            string input = Console.ReadLine();

            while (input != "wife is happy")
            {
                Match dishesMatch = Regex.Match(input, dishesPattern);
                Match cleaningMatch = Regex.Match(input, cleaningPattern);
                Match laundryMatch = Regex.Match(input, laundryPattern);

                if (dishesMatch.Success)
                {
                    string disheshStr = dishesMatch.ToString();
                    string numPattern = @"\d";

                    MatchCollection nums = Regex.Matches(disheshStr, numPattern);

                    foreach (Match match in nums)
                    {
                        int num = int.Parse(match.ToString());
                        timeDishes += num;
                    }
                }
                else if (cleaningMatch.Success)
                {
                    string cleaningStr = cleaningMatch.ToString();
                    string numPattern = @"\d";

                    MatchCollection nums = Regex.Matches(cleaningStr, numPattern);

                    foreach (Match match in nums)
                    {
                        int num = int.Parse(match.ToString());
                        timeCleaning += num;
                    }
                }
                else if (laundryMatch.Success)
                {
                    string laundryStr = laundryMatch.ToString();
                    string numPattern = @"\d";

                    MatchCollection nums = Regex.Matches(laundryStr, numPattern);

                    foreach (Match match in nums)
                    {
                        int num = int.Parse(match.ToString());
                        timeLaundry += num;
                    }
                }

                input = Console.ReadLine();
            }

            totalMinutes = timeCleaning + timeDishes + timeLaundry;

            Console.WriteLine($"Doing the dishes - {timeDishes} min.");
            Console.WriteLine($"Cleaning the house - {timeCleaning} min.");
            Console.WriteLine($"Doing the laundry - {timeLaundry} min.");
            Console.WriteLine($"Total - {totalMinutes} min.");
        }
    }
}