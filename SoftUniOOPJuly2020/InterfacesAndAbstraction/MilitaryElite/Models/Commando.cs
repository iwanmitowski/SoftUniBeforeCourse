using System;
using System.Collections.Generic;
using System.Text;

namespace MilitaryElite
{
    class Commando : SpecialisedSoldier, ICommando
    {
        private List<IMission> missions;
        public Commando(int id, string firstName, string lastName, decimal salary, string corps) : base(id, firstName, lastName, salary, corps)
        {
            this.missions = new List<IMission>();
        }

        public IReadOnlyCollection<IMission> Missions { get; }

        public void AddMission(IMission mission)
        {
            this.missions.Add(mission);
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(base.ToString());
            sb.AppendLine("Missions:");
            foreach (var mission in this.missions)
            {
                sb.AppendLine($"  {mission}");
            }
            return sb.ToString().Trim();
        }
    }
}
