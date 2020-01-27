
using PlayersAndMonsters.Repositories.Contracts;

namespace PlayersAndMonsters.Models.Players
{
    public class Advanced : Player
    {
        private const int AdvancedPlayerHealth = 250;

        public Advanced(ICardRepository cardRepository, string name) 
            : base(cardRepository, name, AdvancedPlayerHealth)
        {
        }
    }
}
