using System;


namespace _09.Num100To200
{
    class Program
    {
        static void Main(string[] args)
        {
            int points = int.Parse(Console.ReadLine());
            double bonusPoints = 0;


            if ( points > 1_000)
            {
                bonusPoints = points * 0.1;
            }
            else if (points > 100)
            {
                bonusPoints = points * 0.2;
            }
            else
            {
                bonusPoints = 5;
            }


         if (bonusPoints % 2 == 0)
            {
                bonusPoints += 1;
            }
         if ( points % 10 == 5)
            {
                bonusPoints += 2;
            }

            double totalPoints = points + bonusPoints;

            Console.WriteLine(bonusPoints);
            Console.WriteLine(totalPoints);


           
        }
    }
}
