using System;
using System.Collections.Generic;
using System.Text;

namespace MilitaryElite
{
    interface IEngineer:ISpecialisedSoldier
    {
        IReadOnlyCollection<IRepair> Repairs { get; }
        void AddRepair(IRepair repair);
    }
}
