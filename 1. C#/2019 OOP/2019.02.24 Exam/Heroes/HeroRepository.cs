
namespace Heroes
{
    using System.Collections.Generic;
    using System.Linq;

    public class HeroRepository
    {
        //private Dictionary<int, Hero> heroes;
        private List<Hero> heroes;
        //private int id;

        public HeroRepository()
        {
            this.heroes = new List<Hero>();
            //this.heroes = new Dictionary<int, Hero>();
            //this.id = 0;
        }

        public void Add(Hero hero)
        {
            this.heroes.Add(hero);
            //this.heroes.Add(id++, hero);
        }

        public Hero Get(int id)
        {
            return this.heroes[id];
        }

        public bool Remove(string name)
        {
            foreach (var hero in heroes)
            {
                if (hero.Name == name)
                {
                    this.heroes.Remove(hero);
                    return true;
                }
            }
            //if (this.heroes.Contains[name])
            //    {
            //        this.heroes.Remove(item);
            //        return true;
            //    }


            return false;
        }

        public Hero GetHeroWithHighestStrength()
        {
            return this.heroes.OrderByDescending(x => x.Item.Strength).FirstOrDefault();
        }
        public Hero GetHeroWithHighestAbility()
        {
            return this.heroes.OrderByDescending(x => x.Item.Ability).FirstOrDefault();
        }
        public Hero GetHeroWithHighestIntelligence()
        {
            return this.heroes.OrderByDescending(x => x.Item.Intelligence).FirstOrDefault();
        }

        public int Count => this.heroes.Count;
    }
}
