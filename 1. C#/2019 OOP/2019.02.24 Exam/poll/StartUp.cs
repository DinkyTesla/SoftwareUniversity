
namespace DefiningClasses
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StartUp
    {
        public static void Main()
        {
            int memberCount = int.Parse(Console.ReadLine());

            Family family = new Family();

            for (int i = 0; i < memberCount; i++)
            {
                string[] personArgs = Console.ReadLine()
                    .Split();
                string name = personArgs[0];
                int age = int.Parse(personArgs[1]);

                Person person = new Person(name, age);
                family.AddMember(person);
            }

            //Person oldestMember = family.GetOldestMember();
            List<Person> peopleOverThirty = family .GetPeopleOverThirty() .OrderBy(x => x.Name) .ToList();

            //Console.WriteLine(oldestMember);
            Console.WriteLine(string.Join(Environment.NewLine, peopleOverThirty));
        }
    }
}
