using System;
using System.Collections.Generic;

namespace _01._Valid_Usernames
{
    public class Program
    {
        public static void Main()
        {
            var input = Console.ReadLine().Split(", ");
            int positiveCounter = 0;
            int negativeCounter = 0;
            List<string> splittedInput = new List<string>(input);
            string result = string.Empty;

            while (true)
            {
                for (int j = 0; j < splittedInput.Count; j++)
                {
                    string username = splittedInput[j];

                    for (int i = 0; i < username.Length; i++)
                    {
                        if (username.Length < 3 || username.Length > 16)
                        {
                            break;
                        }

                        char check = username[i];

                        if (char.IsLetterOrDigit(check) || check == '_' || check == '-')
                        {
                            if (negativeCounter > 0)
                            {
                                positiveCounter = 0;
                                negativeCounter = 0;
                                break;
                            }
                            positiveCounter++;
                        }
                        else
                        {
                            negativeCounter++;
                        }
                        if (positiveCounter == username.Length)
                        {
                            result += username;
                        }
                    }

                    positiveCounter = 0;
                    negativeCounter = 0;
                    if (result != string.Empty)
                    {
                    Console.WriteLine(result);
                    result = string.Empty;
                    }
                }
                break;
            }
        }
    }
}
