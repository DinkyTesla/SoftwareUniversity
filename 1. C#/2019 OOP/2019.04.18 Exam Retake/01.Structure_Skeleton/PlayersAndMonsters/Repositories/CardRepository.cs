using PlayersAndMonsters.Models.Cards.Contracts;
using PlayersAndMonsters.Repositories.Contracts;
using System;
using System.Collections.Generic;

namespace PlayersAndMonsters.Repositories
{
    public class CardRepository : ICardRepository
    {
        private List<ICard> cards;
        private ICard cardToFind;
        private bool remove;

        public CardRepository()
        {
            this.cards = new List<ICard>();
            this.remove = false;
        }

        public int Count { get => this.cards.Count; }

        public IReadOnlyCollection<ICard> Cards { get => this.cards; }

        public void Add(ICard card)
        {
            if (card == null)
            {
                throw new ArgumentException("Card cannot be null!");
            }

            foreach (var cardToCheck in cards)
            {
                if (cardToCheck.Name == card.Name)
                {
                    throw new ArgumentException($"Card {card.Name} already exists!");
                }
            }

            cards.Add(card);
        }

        public ICard Find(string name)
        {
            foreach (var card in cards)
            {
                if (card.Name == name)
                {
                    cardToFind = card;
                }
            }
            return cardToFind;
        }

        public bool Remove(ICard card)
        {
            if (card == null)
            {
                throw new ArgumentException("Card cannot be null!");
            }

            foreach (var cardToRemove in cards)
            {
                if (cardToRemove.Name == card.Name)
                {
                    cardToFind = cardToRemove;
                }
            }
            cards.Remove(cardToFind);

            remove = true;

            return remove;
        }
    }
}
