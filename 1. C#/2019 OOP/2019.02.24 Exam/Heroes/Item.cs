
using System.Text;

namespace Heroes
{
    public class Item
    {
        private int strength;
        private int ability;
        private int intelligence;

        public int Strength
        {
            get { return strength; }
            set { strength = value; }
        }
        public int Ability
        {
            get { return ability; }
            set { ability = value; }
        }
        public int Intelligence
        {
            get { return intelligence; }
            set { intelligence = value; }
        }

        public Item(int strenght, int ability, int intelligence)
        {
            this.Strength = strenght;
            this.Ability = ability;
            this.Intelligence = intelligence;
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();
            result.AppendLine($"Item:");
            result.AppendLine($"  * Strength: {this.Strength}");
            result.AppendLine($"  * Ability: {this.Ability}");
            result.AppendLine($"  * Intelligence: {this.Intelligence}");

            return result.ToString();
        }
    }
}

//"Item:"
//"  * Strength: {Strength Value}"
//"  * Ability: {Ability Value}"
//"  * Intelligence: {Intelligence Value}"

