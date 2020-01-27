
namespace _03._Oldest_Family_Member
{
    using DefiningClasses;
    using System.Collections.Generic;
    using System.Linq;

    public class Family
    {
        private List<Person> people = new List<Person>();

        public void AddMember(Person member)
        {
            this.people.Add(member);
        }

        public Person GetOldestMember()
        {
            return this.people.OrderByDescending(x => x.Age).FirstOrDefault();
        }
    }
}
