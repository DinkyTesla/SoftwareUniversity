
using PlayersAndMonsters.Core.Factories.Contracts;
using PlayersAndMonsters.Models.Players;
using PlayersAndMonsters.Models.Players.Contracts;
using PlayersAndMonsters.Repositories;

namespace PlayersAndMonsters.Core.Factories
{
    public class PlayerFactory : IPlayerFactory
    {
        private IPlayer player;

        public IPlayer CreatePlayer(string type, string username)
        {
            CardRepository cardRepository = new CardRepository();

            if (type == "Beginner")
            {
                 player = new Beginner(cardRepository, username);

            }
            else if (type == "Advanced")
            {
                player = new Advanced(cardRepository, username);
            }

            return player;
        }
    }
}

