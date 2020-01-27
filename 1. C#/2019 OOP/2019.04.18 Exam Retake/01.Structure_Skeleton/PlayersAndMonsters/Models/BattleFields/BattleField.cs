
using PlayersAndMonsters.Models.BattleFields.Contracts;
using PlayersAndMonsters.Models.Players.Contracts;
using System;

namespace PlayersAndMonsters.Models.BattleFields
{
    public class BattleField : IBattleField
    {
        public void Fight(IPlayer attackPlayer, IPlayer enemyPlayer)
        {

            if (attackPlayer.IsDead == true || enemyPlayer.IsDead == true)
            {
                throw new ArgumentException("Player is dead!");
            }
            //Chech if player is a beginner
            //If the player is a beginner, increase his health with 40 points 
            //and increase all damage points of all cards for the user with 30.
            var attackPlayerType = attackPlayer.GetType().Name;
            var enemyPlayerType = enemyPlayer.GetType().Name;

            if (attackPlayerType == "Beginner")
            {
                attackPlayer.Health += 40;

                foreach (var card in attackPlayer.CardRepository.Cards)
                {
                    card.DamagePoints += 30;
                }
            }

            if (enemyPlayerType == "Beginner")
            {
                enemyPlayer.Health += 40;

                foreach (var card in enemyPlayer.CardRepository.Cards)
                {
                    card.DamagePoints += 30;
                }
            }

            //Before the fight, both players get bonus health points from their deck.
            foreach (var card in attackPlayer.CardRepository.Cards)
            {
                attackPlayer.Health += card.HealthPoints;
            }

            foreach (var card in enemyPlayer.CardRepository.Cards)
            {
                enemyPlayer.Health += card.HealthPoints;
            }

            int attackPlayerDamage = 0;

            foreach (var card in attackPlayer.CardRepository.Cards)
            {
                attackPlayerDamage += card.DamagePoints;
            }

            int enemyPlayerDamage = 0;

            foreach (var card in enemyPlayer.CardRepository.Cards)
            {
                enemyPlayerDamage += card.DamagePoints;
            }

            while (true)
            {
                enemyPlayer.TakeDamage(attackPlayerDamage);

                if (attackPlayer.IsDead || enemyPlayer.IsDead)
                {
                    return;
                }

                attackPlayer.TakeDamage(enemyPlayerDamage);

                if (attackPlayer.IsDead || enemyPlayer.IsDead)
                {
                    return;
                }
            }
        }
    }
}
