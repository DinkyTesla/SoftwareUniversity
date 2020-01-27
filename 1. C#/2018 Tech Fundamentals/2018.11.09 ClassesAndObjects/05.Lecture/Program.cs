using System;

namespace _05.Lecture
{
    class Program
    {
        static void Main(string[] args)
        {
            var words = Console.ReadLine().Split();

            var random = new Random();

            for (int i = 0; i < words.Length; i++)
            {
                var randomIndex = random.Next(0, words.Length);

                var tempValue = words[i];

                words[i] = words[randomIndex];

                words[randomIndex] = tempValue;
                
            }
            Console.WriteLine(string.Join(Environment.NewLine, words));
        }
    }
}
