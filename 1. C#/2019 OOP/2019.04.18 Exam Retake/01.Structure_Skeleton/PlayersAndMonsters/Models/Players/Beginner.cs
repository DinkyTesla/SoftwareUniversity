
using PlayersAndMonsters.Repositories.Contracts;

namespace PlayersAndMonsters.Models.Players
{
    public class Beginner : Player
    {
        private const int BegginnersHealth = 50;

        public Beginner(ICardRepository cardRepository, string name) 
            : base(cardRepository, name, BegginnersHealth)
        {
        }
    }
}
