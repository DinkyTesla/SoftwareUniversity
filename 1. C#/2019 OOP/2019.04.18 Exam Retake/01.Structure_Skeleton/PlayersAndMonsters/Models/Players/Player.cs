
using PlayersAndMonsters.Models.Players.Contracts;
using PlayersAndMonsters.Repositories;
using PlayersAndMonsters.Repositories.Contracts;
using System;

namespace PlayersAndMonsters.Models.Players
{
    public abstract class Player : IPlayer
    {
        private string name;
        private int health;
        private ICardRepository cardRepository;
        private bool isDead;

        protected Player(ICardRepository cardRepository, string name, int health)
        {
            this.Username = name;
            this.Health = health;
            this.cardRepository = new CardRepository();
            this.IsDead = false;
        }

        public ICardRepository CardRepository { get => this.cardRepository; }

        public string Username
        {
            get => this.name;
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Player's username cannot be null or an empty string. ");
                }

                this.name = value;
            }
        }

        public int Health
        {
            get => this.health;
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Player's health bonus cannot be less than zero. ");
                }

                this.health = value;
            }
        }

        public bool IsDead
        {
            get => this.isDead;
            set
            {
                if (this.health <= 0)
                {
                    this.health = 0;
                    isDead = true;
                }
            }
        }

        public void TakeDamage(int damagePoints)
        {
            if (damagePoints < 0)
            {
                throw new ArgumentException("Damage points cannot be less than zero.");
            }

            this.health -= damagePoints;

            if (this.health <= 0)
            {
                this.health = 0;
                isDead = true;
            }
        }
    }
}
