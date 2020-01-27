
namespace _04._Even_Times
{
    using System;
    using System.Collections.Generic;

    public class Program
    {
        public static void Main()
        {
            var numberOfElements = int.Parse(Console.ReadLine());

            var countDictionary = new Dictionary<int, int>();

            for (int i = 0; i < numberOfElements; i++)
            {
                var elementForInput = int.Parse(Console.ReadLine());

                if (!countDictionary.ContainsKey(elementForInput))
                {
                    countDictionary.Add(elementForInput, 1);
                }
                else
                {
                    countDictionary[elementForInput]++;
                }
            }

            foreach (var element in countDictionary)
            {
                if (element.Value % 2 == 0)
                {
                    Console.WriteLine(element.Key);
                }
            }
        }
    }
}
