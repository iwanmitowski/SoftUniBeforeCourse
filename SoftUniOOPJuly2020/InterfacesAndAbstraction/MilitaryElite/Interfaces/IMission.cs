using System;
using System.Collections.Generic;
using System.Text;

namespace MilitaryElite
{
    interface IMission
    {
        string CodeName { get; }
        string State { get; }
        void CompleteMission();
    }
}
