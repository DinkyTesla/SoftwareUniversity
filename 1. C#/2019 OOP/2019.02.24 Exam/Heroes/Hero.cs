
using System.Text;

namespace Heroes
{
    public class Hero
    {
        private string name;
        private int level;
        private Item item;

        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        public int Level
        {
            get { return level; }
            set { level = value; }
        }
        public Item Item
        {
            get { return item; }
            set { item = value; }
        }

        public Hero(string name, int level, Item item)
        {
            this.Name = name;
            this.Level = level;
            this.Item = item;
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();
            result.AppendLine($"Hero: {this.Name} – {this.Level}lvl");
            result.AppendLine($"{this.Item}");
           
            return result.ToString();
        }
    }
}

//"Hero: {Name} – {Level}lvl"
//" Item:"
//"  * Strength: {Strength Value}"
//"  * Ability: {Ability Value}"
//"  * Intelligence: {Intelligence Value}"

