
namespace PlayersAndMonsters.Models.Cards
{
    public class MagicCard : Card
    {
            private const int magicCardDamage = 5;
            private const int magicCardHealth = 80;

        public MagicCard(string name) 
            : base(name, magicCardDamage, magicCardHealth)
        {
        }
    }
}
