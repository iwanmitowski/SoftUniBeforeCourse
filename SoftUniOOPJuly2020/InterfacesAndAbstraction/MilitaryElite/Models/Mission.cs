using System;
using System.Collections.Generic;
using System.Text;

namespace MilitaryElite
{
    class Mission : IMission
    {
        private string state;
        public Mission(string codeName, string state)
        {
            CodeName = codeName;
            State = state;
        }

        public string CodeName { get; private set; }

        public string State
        {
            get
            {
                return this.state;
            }
            private set
            {
                if (value == "inProgress" || value == "Finished")
                {
                    this.state = value;
                }
                else
                {
                    throw new InvalidStateException();
                }
                
            }

        }

        public void CompleteMission()
        {
            this.State = "Finished";
        }
        public override string ToString()
        {
            return $"Code Name: {this.CodeName} State: {this.State}";
        }
    }
}
