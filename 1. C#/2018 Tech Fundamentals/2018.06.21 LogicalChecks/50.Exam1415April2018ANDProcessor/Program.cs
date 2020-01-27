using System;


namespace _50.Exam1415April2018ANDProcessor
{
    class Program
    {
        static void Main(string[] args)
        {
            int processors = int.Parse(Console.ReadLine());
            int workers = int.Parse(Console.ReadLine());
            int workDays = int.Parse(Console.ReadLine());

            int totalWorkHours = workers * workDays * 8;
            int processorsMade = totalWorkHours / 3;

            double sum = 0;

            if (processors == processorsMade)
            {
                sum = (processorsMade - processors) * 110.10;
                Console.WriteLine($"Profit: -> {sum:F2} BGN");
            }

            else if (processorsMade > processors)
            {
                sum = (processorsMade - processors) * 110.10;
                Console.WriteLine($"Profit: -> {sum:F2} BGN");
            }
            else
            {
                sum = (processors - processorsMade) * 110.10;
                Console.WriteLine($"Losses: -> {sum:F2} BGN");
            }

        }
    }
}
