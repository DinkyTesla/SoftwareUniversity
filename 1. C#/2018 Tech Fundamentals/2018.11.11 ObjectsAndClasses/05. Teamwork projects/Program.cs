﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace _05._Teamwork_projects
{
    public class Program
    {
        public static void Main()
        {
            int teamCount = int.Parse(Console.ReadLine());

            List<Team> teams = new List<Team>();

            for (int i = 0; i < teamCount; i++)
            {
                string[] splitedInput = Console.ReadLine()
                    .Split('-');

                string creatorName = splitedInput[0];
                string teamName = splitedInput[1];

                bool isTeamNameExist = teams.Any(x => x.Name == teamName);
                bool isCreatorNameExist = teams.Any(x => x.CreatorName == creatorName);

                if (isTeamNameExist == false && isCreatorNameExist == false)
                {
                    Team team = new Team(teamName, creatorName);
                    teams.Add(team);
                    Console.WriteLine($"Team {teamName} has been created by {creatorName}!");
                }
                else if (isTeamNameExist)
                {
                    Console.WriteLine($"Team {teamName} was already created!");
                }
                else if (isCreatorNameExist)
                {
                    Console.WriteLine($"{creatorName} cannot create another team!");
                }
            }

            while (true)
            {
                string input = Console.ReadLine();

                if (input == "end of assignment")
                {
                    break;
                }

                string[] splitedInput = input
                    .Split("->");

                string user = splitedInput[0];
                string teamName = splitedInput[1];

                bool isTeamExists = teams.Any(x => x.Name == teamName);
                bool isAlreadyMember = teams.Any(x => x.Members.Contains(user) || 
                x.CreatorName == user);

                if (isTeamExists == false)
                {
                    Console.WriteLine($"Team {teamName} does not exist!");
                    continue;
                }
                if (isAlreadyMember)
                {
                    Console.WriteLine($"Member {user} cannot join team {teamName}!");
                    continue;
                }
                if (isTeamExists && isAlreadyMember == false)
                {
                    int indexOfTeam = teams.FindIndex(x => x.Name == teamName);
                    teams[indexOfTeam].Members.Add(user);
                }
            }
            List<Team> teamsWithMembers = teams
                .Where(x => x.Members.Count > 0)
                .OrderByDescending(x => x.Members.Count)
                .ThenBy(x => x.Name)
                .ToList();

            List<Team> teamsWithoutMembers = teams
                .Where(x => x.Members.Count == 0)
                .OrderBy(x => x.Name)
                .ToList();

            foreach (var team in teamsWithMembers)
            {
                Console.WriteLine(team.Name);
                Console.WriteLine("- " + team.CreatorName);
                Console.WriteLine(string.Join(Environment.NewLine, team.Members
                    .Select(x => $"-- {x}")));
            }

            Console.WriteLine("Teams to disband:");

            foreach (var team in teamsWithoutMembers)
            {
                Console.WriteLine(team.Name);
            }
        }
    }

    public class Team
    {
        public Team(string name, string creatorName)
        {
            Name = name;
            CreatorName = creatorName;
            Members = new List<string>();
        }

        public string Name { get; set; }

        public string CreatorName { get; set; }

        public List<string> Members { get; set; }
    }
}
