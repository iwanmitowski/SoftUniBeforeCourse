using System;
using System.Collections.Generic;
using System.Text;

namespace PlayersAndMonsters.Models.Cards
{
    class MagicCard : Card
    {
        private const int CardDamagePoints = 5;
        private const int CardHealthPoints = 80;
        public MagicCard(string name) : base(name, CardDamagePoints, CardHealthPoints)
        {
        }
    }
}
