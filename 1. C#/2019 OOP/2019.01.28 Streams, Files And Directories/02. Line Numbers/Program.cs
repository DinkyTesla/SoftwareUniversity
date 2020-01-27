
namespace _02._Line_Numbers
{
    using System.IO;

    public class Program
    {
        public static void Main()
        {
            using (var reader = new StreamReader("../../../text.txt"))
            {
                var counter = 1;

                string line = reader.ReadLine();

                using (var writer = new StreamWriter("../../../Output.txt"))
                {
                    while (line != null)
                    {
                        var charCounter = 0;
                        var punctuationCounter = 0;

                        if (counter != 1)
                        {
                            writer.WriteLine();
                        }

                        foreach (var item in line)
                        {
                            if (char.IsLetter(item))
                            {
                                charCounter++;
                            }
                            else if (char.IsPunctuation(item))
                            {
                                punctuationCounter++;
                            }
                        }

                        writer.Write($"Line {counter}:{line} ({charCounter})({punctuationCounter})");
                        counter++;
                        line = reader.ReadLine();
                    }
                }
            }
        }
    }
}
