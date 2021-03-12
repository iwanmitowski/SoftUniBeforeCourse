using System;
using System.Collections.Generic;
using System.Text;
using WarCroft.Entities.Characters.Contracts;

namespace WarCroft.Entities.Items
{
    class FirePotion : Item
    {
        private const int PotWeight = 5;
        public FirePotion() : base(PotWeight)
        {
        }

        public override void AffectCharacter(Character character)
        {
            if (character.IsAlive)
            {
                character.Health -= 20;
                if (character.Health<=0)
                {
                    character.IsAlive = false;
                }
            }
        }
    }
}
