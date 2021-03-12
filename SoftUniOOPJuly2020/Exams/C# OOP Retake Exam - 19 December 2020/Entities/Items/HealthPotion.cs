using System;
using System.Collections.Generic;
using System.Text;
using WarCroft.Entities.Characters.Contracts;

namespace WarCroft.Entities.Items
{
    class HealthPotion : Item
    {
        private const int PotWeight = 5;
        public HealthPotion() : base(PotWeight)
        {
        }

        public override void AffectCharacter(Character character)
        {
            character.Health += 20;
        }
    }
}
