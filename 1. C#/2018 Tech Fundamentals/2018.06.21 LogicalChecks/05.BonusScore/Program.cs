using System;


namespace _05.BonusScore
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter score: ");
            double num = double.Parse(Console.ReadLine());
            double bonus = 0.0;


                    if (num <= 100)
                    {
                        bonus += 5;
                    }
                    else if (num > 1000)
                    {
                        bonus = num * 0.1;
                    }
                    else
                    {
                        bonus = num * 0.2;
                    }

            if (num % 10 == 5)
            {
                bonus += 2;
            }
            else if (num % 2 == 0)
                {
                    bonus += 1;
                }

            
            Console.WriteLine("Bonus score: {0}", bonus);
            Console.WriteLine("Total score: {0}", num + bonus);

        }
    }
}
