namespace PlayersAndMonsters.Core
{
    using System.Collections.Generic;
    using System.Text;
    using Contracts;
    using PlayersAndMonsters.Core.Factories;
    using PlayersAndMonsters.Models.BattleFields;
    using PlayersAndMonsters.Models.Cards.Contracts;
    using PlayersAndMonsters.Models.Players.Contracts;

    public class ManagerController : IManagerController
    {
        private List<IPlayer> players;
        private List<ICard> cards;
        private IPlayer attackPlayer;
        private IPlayer enemyPlayer;

        public ManagerController()
        {
            this.players = new List<IPlayer>();
            this.cards = new List<ICard>();
        }

        public string AddPlayer(string type, string username)
        {
            foreach (var playerToCheck in players)
            {
                if (playerToCheck.Username == username)
                {
                    return $"Player {username} already exists!";
                }
            }

            PlayerFactory playerFactory = new PlayerFactory();
            IPlayer player = playerFactory.CreatePlayer(type, username);
            players.Add(player);

            return $"Successfully added player of type {type} with username: {username}";
        }

        public string AddCard(string type, string name)
        {
            foreach (var cardToAdd in cards)
            {
                if (cardToAdd.Name == name)
                {
                    return $"Card {name} already exists!";
                }
            }

            CardFactory cardFactory = new CardFactory();
            ICard card = cardFactory.CreateCard(type, name);
            cards.Add(card);

            return $"Successfully added card of type {type}Card with name: {name}";
        }

        public string AddPlayerCard(string username, string cardName)
        {
            bool cardIsNull = false;

            foreach (var card in cards)
            {
                if (card.Name == cardName)
                {
                    break;
                }
                cardIsNull = true;
            }

            foreach (var player in players)
            {
                if (player.Username == username)
                {
                    foreach (var card in cards)
                    {
                        if (card.Name == cardName)
                        {
                            player.CardRepository.Add(card);
                        }
                    }
                }
            }

            if (cardIsNull)
            {
                return "Card cannot be null!";
            }

            return $"Successfully added card: {cardName} to user: {username}";

        }

        public string Fight(string attackUser, string enemyUser)
        {
            foreach (var player in players)
            {
                if (player.Username == attackUser)
                {
                    attackPlayer = player;
                }
                else if (player.Username == enemyUser)
                {
                    enemyPlayer = player;
                }
            }

            BattleField battleField = new BattleField();

            battleField.Fight(attackPlayer, enemyPlayer);

            return $"Attack user health {attackPlayer.Health} - Enemy user health {enemyPlayer.Health}";
        }

        public string Report()
        {
            StringBuilder result = new StringBuilder();

            foreach (var user in players)
            {
                result.AppendLine($"Username: {user.Username} - Health: {user.Health} – Cards {user.CardRepository.Count}");

                foreach (var card in user.CardRepository.Cards)
                {
                    result.AppendLine($"Card: {card.Name} - Damage: {card.DamagePoints}");
                }

                result.AppendLine("###");
            }

            return result.ToString().TrimEnd();
        }
    }
}
