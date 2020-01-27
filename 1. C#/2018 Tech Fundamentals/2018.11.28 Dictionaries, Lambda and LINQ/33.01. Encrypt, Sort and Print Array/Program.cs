using System;
using System.Collections.Generic;
using System.Linq;

namespace _33._01._Encrypt__Sort_and_Print_Array
{
    public class Program
    {
        public static void Main()
        {

            int givenInputLength = int.Parse(Console.ReadLine());

            var resultingDictionary = new Dictionary<string, double>();

            double sumOf = 0;

            for (int i = 0; i < givenInputLength; i++)
            {
                string theNameOf = Console.ReadLine();

                resultingDictionary.Add(theNameOf, 0);

                foreach (var item in theNameOf)
                {
                    bool containsLowerVowel = item == 'a' || item == 'e' || item == 'i' || item == 'o' || item == 'u';
                    bool containsCapitalVowel = item == 'A' || item == 'E' || item == 'I' || item == 'O' || item == 'U';

                    if (containsLowerVowel || containsCapitalVowel)
                    {
                        int test = item * theNameOf.Length;
                        sumOf += test;
                    }
                    else
                    {
                        double test = item / theNameOf.Length;
                        sumOf += test;
                    }
                }

                resultingDictionary[theNameOf] = sumOf;

                sumOf = 0;
            }

            resultingDictionary = new Dictionary<string, double>(resultingDictionary.OrderBy(x => x.Value));

            foreach (var kvp in resultingDictionary)
            {
                Console.WriteLine($"{kvp.Value}");
            }
        }
    }
}
