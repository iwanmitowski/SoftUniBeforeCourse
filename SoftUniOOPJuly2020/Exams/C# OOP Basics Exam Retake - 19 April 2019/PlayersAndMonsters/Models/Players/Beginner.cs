using PlayersAndMonsters.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace PlayersAndMonsters.Models.Players
{
    class Beginner : Player
    {
        private const int PlayerHealth = 50;
        public Beginner(ICardRepository cardRepository, string username) : base(cardRepository, username, PlayerHealth)
        {
        }
    }
}
