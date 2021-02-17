using System;
using System.Collections.Generic;
using System.Text;

namespace MilitaryElite
{
    class Engineer : SpecialisedSoldier, IEngineer
    {
        private List<IRepair> repairs;

        public Engineer(int id, string firstName, string lastName, decimal salary, string corps) : base(id, firstName, lastName, salary, corps)
        {
            this.repairs = new List<IRepair>();
        }

        public IReadOnlyCollection<IRepair> Repairs { get; }

        
        public void AddRepair(IRepair repair)
        {
            this.repairs.Add(repair);
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(base.ToString());
            sb.AppendLine($"Repairs:");
            foreach (var repair in this.repairs)
            {
                sb.AppendLine($"  {repair}");
            }
            return sb.ToString().Trim();
        }
    }
}
