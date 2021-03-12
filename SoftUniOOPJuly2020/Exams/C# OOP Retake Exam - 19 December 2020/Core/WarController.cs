using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WarCroft.Constants;
using WarCroft.Core.Factories.Contracts;
using WarCroft.Entities.Characters.Contracts;
using WarCroft.Entities.Items;

namespace WarCroft.Core
{
    public class WarController
    {
        private readonly IWarriorFactory warriorFactory;
        private readonly IPriestFactory priestFactory;
        private readonly IFirePotionFactory firePotionFactory;
        private readonly IHealthPotionFactory healthPotionFactory;

        private readonly List<Character> party;
        private readonly List<Item> itemPool;


        public WarController(
        IWarriorFactory warriorFactory,
        IPriestFactory priestFactory,
        IFirePotionFactory firePotionFactory,
        IHealthPotionFactory healthPotionFactory
            )
        {
            party = new List<Character>();
            itemPool = new List<Item>();
            this.warriorFactory = warriorFactory;
            this.priestFactory = priestFactory;
            this.firePotionFactory = firePotionFactory;
            this.healthPotionFactory = healthPotionFactory;
        }

        public string JoinParty(string[] args)
        {
            string characterType = args[0];
            string name = args[1];

            Character currentCharacter;

            switch (characterType)
            {
                case "Warrior":
                    currentCharacter = warriorFactory.CreateWarrior(name);
                    break;

                case "Priest":
                    currentCharacter = priestFactory.CreatePriest(name);
                    break;

                default:
                    throw new ArgumentException(string.Format(ExceptionMessages.InvalidCharacterType, characterType));
            }

            party.Add(currentCharacter);

            return string.Format(SuccessMessages.JoinParty, name);
        }

        public string AddItemToPool(string[] args)
        {
            string itemName = args[0];
            Item currentItem;

            switch (itemName)
            {
                case "FirePotion":
                    currentItem = firePotionFactory.CreateFirePotion();
                    break;

                case "HealthPotion":
                    currentItem = healthPotionFactory.CreateHealthPotion();
                    break;

                default:
                    throw new ArgumentException(string.Format(ExceptionMessages.InvalidItem, itemName));
            }

            itemPool.Add(currentItem);
            return string.Format(SuccessMessages.AddItemToPool, itemName);
        }

        public string PickUpItem(string[] args)
        {
            string characterName = args[0];
            Character currentCharacter = this.party.FirstOrDefault(x => x.Name == characterName);

            if (currentCharacter == null)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.CharacterNotInParty, characterName));
            }

            if (this.itemPool.Count == 0)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.ItemPoolEmpty));
            }

            Item currentItem = this.itemPool.Last();

            currentCharacter.Bag.AddItem(currentItem);

            return string.Format(SuccessMessages.PickUpItem, characterName, currentItem.GetType().Name);
        }

        public string UseItem(string[] args)
        {
            string characterName = args[0];
            string itemName = args[1];

            Character currentCharacter = this.party.FirstOrDefault(x => x.Name == characterName);

            if (currentCharacter == null)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.CharacterNotInParty, characterName));
            }

            Item item = currentCharacter.Bag.GetItem(itemName);
            currentCharacter.UseItem(item);

            return string.Format(SuccessMessages.UsedItem, characterName, itemName);
        }

        public string GetStats()
        {
            StringBuilder sb = new StringBuilder();

            foreach (var player in this.party.OrderByDescending(x=>x.IsAlive).ThenBy(x=>x.Health))
            {
                sb.AppendLine(player.ToString());
            }

            return sb.ToString().Trim();
        }

        public string Attack(string[] args)
        {
            string attackerName = args[0];
            string receiverName = args[1];

            Character attacker = party.FirstOrDefault(x => x.Name == attackerName);
            Character receiver = party.FirstOrDefault(x => x.Name == receiverName);

            if (attacker==null || receiver==null)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.CharacterNotInParty, attacker == null ? attackerName : receiverName));
            }

            if (attacker.GetType().Name != "Warrior")
            {
                throw new ArgumentException(string.Format(ExceptionMessages.AttackFail, attackerName));
            }

            receiver.TakeDamage(attacker.AbilityPoints);

            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"{attackerName} attacks {receiverName} for {attacker.AbilityPoints} hit points! ");
            sb.Append($"{receiverName} has {receiver.Health}/{receiver.BaseHealth} HP and ");
            sb.Append($"{receiver.Armor}/{receiver.BaseArmor} AP left!");

            if (receiver.IsAlive==false)
            {
                sb.AppendLine($"{receiverName} is dead!");
            }

            return sb.ToString().Trim();


        }

        public string Heal(string[] args)
        {
            string healerName = args[0];
            string receiverName = args[1];

            Character healer = party.FirstOrDefault(x => x.Name == healerName);
            Character receiver = party.FirstOrDefault(x => x.Name == receiverName);

            if (healer == null || receiver == null)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.CharacterNotInParty, healer == null ? healerName : receiverName));
            }

            if (healer.GetType().Name != "Priest")
            {
                throw new ArgumentException(string.Format(ExceptionMessages.HealerCannotHeal, healerName));
            }

            receiver.Health += healer.AbilityPoints;

            return $"{healer.Name} heals {receiver.Name} for {healer.AbilityPoints}! {receiver.Name} has {receiver.Health} health now!";
        }
    }
}
