using PlayersAndMonsters.Core.Factories.Contracts;
using PlayersAndMonsters.Models.Players.Contracts;
using PlayersAndMonsters.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace PlayersAndMonsters.Core.Factories
{
    class PlayerFactory : IPlayerFactory
    {
        public IPlayer CreatePlayer(string type, string username)
        {
            var playerType = Assembly
                .GetCallingAssembly()
                .GetTypes()
                .Where(x => x.Name == type && !x.IsAbstract)
                .FirstOrDefault();

            IPlayer player = null;

            try
            {
                player = (IPlayer)Activator.CreateInstance(playerType, new CardRepository(), username);
            }
            catch (Exception ex)
            {

                throw new ArgumentException(ex.InnerException.Message);
            }

            return player;
        }
    }
}
