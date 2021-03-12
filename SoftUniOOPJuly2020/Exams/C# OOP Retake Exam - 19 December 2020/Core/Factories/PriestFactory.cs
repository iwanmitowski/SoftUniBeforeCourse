using System;
using System.Collections.Generic;
using System.Text;
using WarCroft.Core.Factories.Contracts;
using WarCroft.Entities.Characters;
using WarCroft.Entities.Characters.Contracts;

namespace WarCroft.Core.Factories
{
    class PriestFactory : IPriestFactory
    {
        public Character CreatePriest(string name)
        {
            return new Priest(name);
        }
    }
}
