using PlayersAndMonsters.Core.Factories.Contracts;
using PlayersAndMonsters.Models.Cards.Contracts;
using PlayersAndMonsters.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace PlayersAndMonsters.Core.Factories
{
    class CardFactory : ICardFactory
    {
        public ICard CreateCard(string type, string name)
        {
            var cardType = Assembly
                .GetCallingAssembly()
                .GetTypes()
                .Where(x => x.Name == $"{type}Card" && !x.IsAbstract)
                .FirstOrDefault();

            ICard card = null;

            try
            {
                card = (ICard)Activator.CreateInstance(cardType, name);
            }
            catch (Exception ex)
            {

                throw new ArgumentException(ex.InnerException.Message);
            }

            return card;
        }
    }
}
