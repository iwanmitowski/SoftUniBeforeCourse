using System;
using System.Collections.Generic;
using System.Text;

namespace MilitaryElite
{
    class LieutenantGeneral : Private, ILieutenantGeneral
    {
        private List<ISoldier> privates;
        public LieutenantGeneral(int id, string firstName, string lastName, decimal salary) : base(id, firstName, lastName, salary)
        {
            this.privates = new List<ISoldier>();
        }

        public IReadOnlyCollection<ISoldier> Privates { get; }

        public void AddPrivate(ISoldier @private)
        {
            this.privates.Add(@private);
        }
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(base.ToString());
            sb.AppendLine("Privates:");

            foreach (var @private in privates)
            {
                sb.AppendLine($"  {@private}");
            }
            return sb.ToString().Trim();
        }
    }
}
