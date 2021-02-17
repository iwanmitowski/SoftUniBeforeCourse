using System;
using System.Collections.Generic;
using System.Text;

namespace MilitaryElite
{
    class SpecialisedSoldier : Private, ISpecialisedSoldier
    {
        private string corps;
        public SpecialisedSoldier(int id, string firstName, string lastName, decimal salary,string corps) : base(id, firstName, lastName, salary)
        {
            this.Corps = corps;
        }

        public string Corps
        {
            get
            {
                return this.corps;
            }
            set
            {
                if (value == "Airforces" || value == "Marines")
                {
                    this.corps = value;
                }
                else
                {
                    throw new InvalidCorpsException();
                }
            }
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(base.ToString());
            sb.AppendLine($"Corps: {this.corps}");
            return sb.ToString().Trim(); 
        }
    }
}
