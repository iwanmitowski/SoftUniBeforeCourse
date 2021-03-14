using PlayersAndMonsters.Models.BattleFields.Contracts;
using PlayersAndMonsters.Models.Players.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PlayersAndMonsters.Models.BattleFields
{
    class BattleField : IBattleField
    {
        public void Fight(IPlayer attackPlayer, IPlayer enemyPlayer)
        {
            if (attackPlayer.IsDead == true || enemyPlayer.IsDead == true)
            {
                throw new ArgumentException("Player is dead!");
            }

            CheckIfItsBeginner(attackPlayer);
            CheckIfItsBeginner(enemyPlayer);
            GetBonusHPFromDeck(attackPlayer);
            GetBonusHPFromDeck(enemyPlayer);

            while (true)
            {
                int attackerDmg = CalculateDamage(attackPlayer);

                enemyPlayer.TakeDamage(attackerDmg);

                if (enemyPlayer.IsDead == true)
                {
                    break;
                }

                int enemyDmg = CalculateDamage(enemyPlayer);

                attackPlayer.TakeDamage(enemyDmg);

                if (attackPlayer.IsDead == true)
                {
                    break;
                }
            }

        }
        private int CalculateDamage(IPlayer player)
        {
            int dmg = player.CardRepository.Cards.Select(c => c.DamagePoints).Sum();
            
            return dmg;
        }
        private void CheckIfItsBeginner(IPlayer player)
        {
            if (player.GetType().Name == "Beginner")
            {
                player.Health += 40;
                foreach (var card in player.CardRepository.Cards)
                {
                    card.DamagePoints += 30;
                }
            }
        }

        private void GetBonusHPFromDeck(IPlayer player)
        {
            foreach (var card in player.CardRepository.Cards)
            {
                player.Health += card.HealthPoints;
            }
        }
    }
}
