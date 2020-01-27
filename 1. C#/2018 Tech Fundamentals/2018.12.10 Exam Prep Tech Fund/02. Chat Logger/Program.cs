namespace _02._Chat_Logger
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Program
    {
        public static void Main()
        {
            var chatLog = new List<string>();

            while (true)
            {
                var input = Console.ReadLine().Split(' ').ToList();

                if (input.Contains("end"))
                {
                    for (int i = 0; i < chatLog.Count; i++)
                    {
                        Console.WriteLine(string.Join("", chatLog[i]));
                    }
                    break;
                }
                if (input.Contains("Chat"))
                {
                    var message = input[1];
                    chatLog.Add(message);
                }
                else if (input.Contains("Delete"))
                {
                    var messageToDelete = input[1];
                    if (chatLog.Contains(messageToDelete))
                    {
                        chatLog.Remove(messageToDelete);
                    }
                }
                else if (input.Contains("Edit"))
                {
                    var messageToEdit = input[1];
                    var editedVersion = input[2];
                    for (int i = 0; i < chatLog.Count; i++)
                    {
                        var test = chatLog[i];

                        if (test == messageToEdit)
                        {
                            if (i >= chatLog.Count)
                            {
                                chatLog.Remove(messageToEdit);
                                chatLog.Add(editedVersion);
                            }
                            else
                            {
                                chatLog[i] = editedVersion;
                            }
                        }
                    }
                }
                else if (input.Contains("Pin"))
                {
                    var message = input[1];
                    chatLog.Remove(message);
                    chatLog.Add(message);
                }
                else if (input.Contains("Spam"))
                {
                    for (int i = 1; i < input.Count; i++)
                    {
                        chatLog.Add(input[i]);
                    }
                }
            }
        }
    }
}