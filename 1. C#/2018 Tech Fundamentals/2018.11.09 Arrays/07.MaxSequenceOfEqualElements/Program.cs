using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _07.MaxSequenceOfEqualElements
{
    public class Program
    {
        public static void Main()
        {
            List<int> givenNumbers = Console.ReadLine().Split(' ').Select(int.Parse).ToList();
            List<int> workList = new List<int>();
            List<int> finalList = new List<int>();

            int counter = 1;
            int maxCounter = 1;

            workList.Add(givenNumbers[0]);

            for (int i = 0; i < givenNumbers.Count - 1; i++)
            {
                if (givenNumbers[i] == givenNumbers[i+1])
                {
                    counter++;
                    workList.Add(givenNumbers[i + 1]);
                }
                else
                {
                    counter = 1;
                    workList.Clear();
                    workList.Add(givenNumbers[i + 1]);
                }
                if (counter > maxCounter)
                {
                    finalList.Clear();
                    maxCounter = counter;
                    finalList.AddRange(workList);
                }
            }
            if (maxCounter == 1)
            {
                Console.WriteLine(givenNumbers[0]);
                return;
            }

            Console.WriteLine(string.Join(" ", finalList));
        }

    }
}
