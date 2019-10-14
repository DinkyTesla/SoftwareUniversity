using System;
using System.Collections.Generic;
using System.Linq;

namespace _03._Baking_Factory
{
    public class Program
    {
        public static void Main()
        {
            string input = string.Empty;

            double batchQuality = 0;
            double averageQuality = 0;
            int batchLength = 0;
            var result = string.Empty;

            while ( input != "Bake It!")
            {
                input = Console.ReadLine();
                if (input == "Bake It!")
                {
                    break;
                }
                List<double> bakeQuality = new List<double>(input
                    .Split('#')
                    .Select(double.Parse)
                    .ToList());

                double currentBatchQuality = bakeQuality.Sum();
                double currentAverageQuality = bakeQuality.Average();
                int currentLength = bakeQuality.Count;

                if (currentBatchQuality > batchQuality)
                {
                    batchQuality = currentBatchQuality;
                    averageQuality = currentAverageQuality;
                    batchLength = currentLength;
                    result = string.Join(" ", bakeQuality);
                }
                else if (currentBatchQuality == batchQuality)
                {
                    if (currentAverageQuality > averageQuality)
                    {
                        batchQuality = currentBatchQuality;
                        averageQuality = currentAverageQuality;
                        batchLength = currentLength;
                        result = string.Join(" ", bakeQuality);

                    }
                    else if (currentAverageQuality == averageQuality)
                    {
                        if (currentLength < batchLength)
                        {
                            batchQuality = currentBatchQuality;
                            averageQuality = currentAverageQuality;
                            batchLength = currentLength;
                            result = string.Join(" ", bakeQuality);
                        }
                        
                    }
                    
                }
                
            }
            Console.WriteLine($"Best Batch quality: {batchQuality}");
            Console.WriteLine(result);

        }
    }
}
