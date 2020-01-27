
namespace _01._Even_Lines
{
    using System;
    using System.IO;
    using System.Linq;
    using System.Text;

    public class Program
    {
        public static void Main()
        {
            using (var reader = new StreamReader("../../../text.txt"))
            {
                using (var writer = new StreamWriter("../../../Output.txt"))
                {
                    int counter = 0;

                    while (true)
                    {

                        string line = reader.ReadLine();

                        if (line == null)
                        {
                            break;
                        }

                        if (counter % 2 == 0)
                        {

                            var myArray = line.Split().Reverse();

                            var text = string.Join(" ", myArray);

                            var sb = new StringBuilder();

                            for (int i = 0; i < text.Length; i++)
                            {
                                var toSwitch = text[i];

                                if (toSwitch == '-' || toSwitch == ',' ||
                                    toSwitch == '.' || toSwitch == '!' ||
                                    toSwitch == '?')
                                {
                                    sb.Append('@');
                                }
                                else
                                {
                                    sb.Append(toSwitch);
                                }
                            }

                            Console.WriteLine(sb);
                            writer.WriteLine(sb);
                        }

                        counter++;
                    }
                }
            }
        }
    }
}
