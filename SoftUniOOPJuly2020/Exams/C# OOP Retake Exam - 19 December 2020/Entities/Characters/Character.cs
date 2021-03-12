using System;

using WarCroft.Constants;
using WarCroft.Entities.Inventory;
using WarCroft.Entities.Items;
using System.Linq;

namespace WarCroft.Entities.Characters.Contracts
{
    public abstract class Character
    {
        private string name;
        private double health;
        private double armor;

        protected Character(string name,
            double baseHealth,
            double baseArmor,
            double abilityPoints
            , IBag bag)
        {
            Name = name;
            BaseHealth = baseHealth;
            Health = BaseHealth;
            BaseArmor = baseArmor;
            Armor = BaseArmor;
            AbilityPoints = abilityPoints;
            Bag = bag;
        }

        public string Name
        {
            get
            {
                return this.name;
            }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.CharacterNameInvalid);
                }
                this.name = value;
            }
        }

        public double BaseHealth { get; private set; }

        public double Health
        {
            get
            {
                return this.health;
            }
            set
            {
                if (value > BaseHealth)
                {
                    this.health = BaseHealth;
                }
                else if (value < 0)
                {
                    this.health = 0;
                }
                else
                {
                    health = value;
                }
            }
        }
        public double BaseArmor { get; private set; }

        public double Armor
        {
            get
            {
                return this.armor;
            }
            set
            {

                if (value < 0)
                {
                    this.armor = 0;
                }
                else
                {
                    armor = value;
                }
            }
        }

        public double AbilityPoints { get; private set; }

        public IBag Bag { get; private set; }

        public bool IsAlive { get; set; } = true;

        protected void EnsureAlive()
        {
            if (!this.IsAlive)
            {
                throw new InvalidOperationException(ExceptionMessages.AffectedCharacterDead);
            }
        }

        public virtual void TakeDamage(double hitPoints)
        {
            if (this.IsAlive)
            {
                double armorLeft = this.Armor - hitPoints;
                if (armorLeft < 0)
                {
                    this.Health -= Math.Abs(armorLeft);
                    if (this.health <= 0)
                    {
                        this.IsAlive = false;
                    }
                }
                this.Armor -= hitPoints;

            }
        }

        public virtual void UseItem(Item item)
        {
            if (this.IsAlive)
            {
                var itemToUse = this.Bag.Items.FirstOrDefault(x => x == item);
                itemToUse.AffectCharacter(this);
            }
        }

        public override string ToString()
        {
            string alive = "Alive";
            string dead = "Dead";
            return $"{this.Name} - HP: {this.Health}/{this.BaseHealth}, AP: {this.Armor}/{this.BaseArmor}, Status:{(this.IsAlive == true ? alive : dead)}";
        }
    }
}