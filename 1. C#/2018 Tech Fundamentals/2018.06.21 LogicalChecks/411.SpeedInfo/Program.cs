using System;


namespace _11.SpeedInfo
{
    class Program
    {
        static void Main(string[] args)
        {

            double speedValue = double.Parse(Console.ReadLine());

            string result = "";

            if ( speedValue > 1_000)
            {
                result = "extremely fast";
            }
            else if ( speedValue > 150 && speedValue <= 1_000 )
            {
                result = "ultra fast";
            }
            else if ( speedValue > 50 && speedValue <= 150 )
            {
                result = "fast";
            }
            else if ( speedValue > 10 && speedValue <= 50)
            {
                result = "average";
            }
            else
            {
                result = "slow";
            }

            Console.WriteLine(result);
        }
    }
}
