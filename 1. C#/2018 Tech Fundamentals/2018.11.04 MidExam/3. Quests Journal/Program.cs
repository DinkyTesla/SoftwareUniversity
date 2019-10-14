using System;
using System.Collections.Generic;
using System.Linq;

namespace _3._Quests_Journal
{
    public class Program
    {
        public static void Main()
        {
            string input = string.Empty;

            List<string> givenList = new List<string>(Console.ReadLine()
                .Split(", " , StringSplitOptions.RemoveEmptyEntries)
                .ToList());

            List<string> journal = new List<string>();
            for (int i = 0; i < givenList.Count; i++)
            {
                journal.Add(givenList[i]);
            }
            
            while (input != "Retire!")
            {
                input = Console.ReadLine();
                List<string> workList = new List<string>(input
                    .Split(" - ")
                    .ToList());

                if (input == "Retire!")
                {
                    break;
                }
                else if (workList.Contains("Start"))
                {
                    if (journal.Contains(workList[1]))
                    {
                        break;
                    }
                    else
                    {
                        journal.Add(workList[1]);
                    }
                }
                else if (workList.Contains("Complete"))
                {
                    journal.Remove(workList[1]);
                }
                else if (workList.Contains("Side Quest"))
                {
                    List<string> sideQuestList = new List<string>(workList[1]
                        .Split(":", StringSplitOptions.RemoveEmptyEntries)
                        .ToList());
                    if (journal.Contains(sideQuestList[0]))
                    {
                        if (journal.Contains(sideQuestList[1]))
                        {
                            break;
                        }
                        else
                        {
                            int index = journal.IndexOf(sideQuestList[0]);
                            journal.Insert(index + 1, sideQuestList[1]);
                        }

                    }
                    //else
                    //{
                    //        journal.Add(sideQuestList[0]);
                    //    int index = journal.IndexOf(sideQuestList[0]);
                    //    journal.Insert(index + 1, sideQuestList[1]);
                    //}
                    
                }
                else if (workList.Contains("Renew"))
                {
                    if (journal.Contains(workList[1]))
                    {
                        journal.Remove(workList[1]);
                        journal.Add(workList[1]);
                    }
                    
                }
            }
            Console.WriteLine(string.Join(", ", journal));
        }
    }
}
