using System;
using System.Collections.Generic;
using System.Text;

namespace PlayersAndMonsters.Models.Cards
{
    class TrapCard:Card
    {
        private const int CardDamagePoints = 120;
        private const int CardHealthPoints = 5;
        public TrapCard(string name) : base(name, CardDamagePoints, CardHealthPoints)
        {
        }
    }
}
