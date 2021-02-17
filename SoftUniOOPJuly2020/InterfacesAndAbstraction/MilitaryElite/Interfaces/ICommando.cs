using System;
using System.Collections.Generic;
using System.Text;

namespace MilitaryElite
{
    interface ICommando:ISpecialisedSoldier
    {
        IReadOnlyCollection<IMission> Missions { get; }
        void AddMission(IMission mission);
    }
}
