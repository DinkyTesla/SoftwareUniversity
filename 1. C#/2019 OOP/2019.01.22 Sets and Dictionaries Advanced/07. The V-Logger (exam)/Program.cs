
namespace _07._The_V_Logger__exam_
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Program
    {
        public static void Main()
        {
            HashSet<string> usernames = new HashSet<string>();

            //Pesho followed by...
            var userFollowers = new Dictionary<string, HashSet<string>>();
            //Pesho is following ...
            var userFollowing = new Dictionary<string, HashSet<string>>();

            while (true)
            {
                string input = Console.ReadLine();

                if (input == "Statistics")
                {
                    break;
                }

                string[] splittedInput = input.Split();

                if (splittedInput.Length == 4)
                {
                    string username = splittedInput[0];
                    if (usernames.Contains(username) == false)
                    {
                        usernames.Add(username);
                        userFollowers.Add(username, new HashSet<string>());
                        userFollowing[username] = new HashSet<string>();  //Нарочно по различен начин.
                    }
                }
                else
                {
                    string heFollows = splittedInput[0];
                    string followed = splittedInput[2];

                    if (usernames.Contains(heFollows) &&
                        usernames.Contains(followed) &&
                        heFollows != followed)
                    {
                        userFollowers[followed].Add(heFollows);
                        userFollowing[heFollows].Add(followed);
                    }
                }
            }

            Console.WriteLine($"The V-Logger has a total of {usernames.Count} vloggers in its logs.");

            var topuser = userFollowers
                .OrderByDescending(x => x.Value.Count)
                .ThenBy(x => userFollowing[x.Key].Count)
                .FirstOrDefault();

            Console.WriteLine($"1. {topuser.Key} : {topuser.Value.Count} followers, {userFollowing[topuser.Key].Count} following");
            foreach (var username in topuser.Value.OrderBy(a => a))
            {
                Console.WriteLine($"*  {username}");
            }

            int count = 2;
            foreach (var item in userFollowers.Where(x => x.Key != topuser.Key)
                .OrderByDescending(x => x.Value.Count)
                .ThenBy(x => userFollowing[x.Key].Count))
            {
                Console.WriteLine($"{count}. {item.Key} : {item.Value.Count} followers, {userFollowing[item.Key].Count} following");
                count++;
            }
        }
    }
}
