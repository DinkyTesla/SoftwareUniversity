using System;
using System.Collections.Generic;
using System.Linq;

namespace _1._Party_Profit
{
    public class Program
    {
        public static void Main()
        {
            int partySize = int.Parse(Console.ReadLine());
            int daysGiven = int.Parse(Console.ReadLine());

            double daylyCoins = 0;
            int currentParty = partySize;

            bool motivationalDay = false;
            daylyCoins = daysGiven * 50;

            for (int i = 1; i <= daysGiven; i++)
            {

                if (i % 10 == 0)
                {
                    currentParty -= 2;
                }

                if (i % 15 == 0)
                {
                    currentParty += 5;
                }

                daylyCoins -= (currentParty * 2);

                if (i % 3 == 0)
                {
                    daylyCoins -= (currentParty * 3);
                    motivationalDay = true;
                }

                if (i % 5 == 0)
                {
                    daylyCoins += (currentParty * 20);
                    if (motivationalDay)
                    {
                        daylyCoins -= (currentParty * 2);
                        
                    }
                }

                motivationalDay = false;

            }

            double memberCoins = Math.Floor(daylyCoins / currentParty);
            Console.WriteLine($"{currentParty} companions received {memberCoins} coins each.");
        }
    }
}
