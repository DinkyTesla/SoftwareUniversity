using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lecture._03
{
    public class Program
    {
        public static void Main()
        {

            int totalWords = int.Parse(Console.ReadLine());

            var words = new Dictionary<string, List<string>>();

            for (int i = 0; i < totalWords; i++)
            {
                string word = Console.ReadLine();
                string synonym = Console.ReadLine();

                if (!words.ContainsKey(word))
                {
                    words[word] = new List<string>();
                }

                var existingWords = words[word];
                existingWords.Add(synonym);

                foreach (var kvp in collection)
                {
                    var synonyms =

                }

            }
        }
    }
}
