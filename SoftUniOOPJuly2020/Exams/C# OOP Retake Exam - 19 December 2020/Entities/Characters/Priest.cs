using System;
using System.Collections.Generic;
using System.Text;
using WarCroft.Entities.Characters.Contracts;
using WarCroft.Entities.Inventory;

namespace WarCroft.Entities.Characters
{
    class Priest : Character, IHealer
    {
        private const double PriestBaseHealth = 50;
        private const double PriestBaseArmor = 25;
        private const double PriestAbilityPoints = 40;
        public Priest(string name) : base(name, PriestBaseHealth, PriestBaseArmor, PriestAbilityPoints, new Backpack())
        {
        }

        public void Heal(Character character)
        {
            if (this.IsAlive&&character.IsAlive)
            {
                character.Health += AbilityPoints;
            }
        }
    }
}
