using System;
using System.Collections.Generic;
using System.Text;
using WarCroft.Entities.Characters.Contracts;

namespace WarCroft.Core.Factories.Contracts
{
    public interface IPriestFactory
    {
        Character CreatePriest(string name);
    }
}
