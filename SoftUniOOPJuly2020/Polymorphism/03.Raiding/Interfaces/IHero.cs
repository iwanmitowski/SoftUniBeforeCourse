using System;
using System.Collections.Generic;
using System.Text;

namespace _03.Raiding
{
    interface IHero
    {
        string Name { get; }
        int Power { get; }
        string CastAbility();

    }
}
