using PlayersAndMonsters.Models.Players.Contracts;
using PlayersAndMonsters.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PlayersAndMonsters.Repositories
{
    public class PlayerRepository : IPlayerRepository
    {
        private int count;
        private List<IPlayer> players;
        private bool remove;
        private IPlayer playerToFind;

        public PlayerRepository()
        {
            this.players = new List<IPlayer>();
            this.remove = false;
        }

        public int Count { get => this.players.Count; }

        public IReadOnlyCollection<IPlayer> Players { get => this.players; }

        public void Add(IPlayer player)
        {
            if (player == null)
            {
                throw new ArgumentException("Player cannot be null");
            }

            foreach (var playerToCheck in players)
            {
                if (playerToCheck.Username == player.Username)
                {
                    throw new ArgumentException($"Player {player.Username} already exists!");
                }
            }

            this.players.Add(player);
        }

        public IPlayer Find(string username)
        {
            foreach (var player in players)
            {
                if (player.Username == username)
                {
                    playerToFind = player;
                }
            }

            return playerToFind;
        }

        public bool Remove(IPlayer player)
        {
            if (player == null|| !this.players.Contains(player))
            {
                throw new ArgumentException("Player cannot be null");
            }

            foreach (var playerToFind in players)
            {
                if (playerToFind.Username == player.Username)
                {
                    this.players.Remove(player);
                }
            }

            remove = true;

            return remove;
        }
    }
}
