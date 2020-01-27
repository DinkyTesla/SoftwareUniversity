
namespace PlayersAndMonsters.Models.Cards
{
    public class TrapCard : Card
    {
        private const int trapCardDamage = 120;
        private const int trapCardHealth = 5;

        public TrapCard(string name)
            : base(name, trapCardDamage, trapCardHealth)
        {
        }
    }
}
