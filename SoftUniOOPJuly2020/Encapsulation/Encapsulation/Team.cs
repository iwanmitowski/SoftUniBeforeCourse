using System;
using System.Collections.Generic;
using System.Text;

namespace PersonsInfo
{
    class Team
    {
        private string name;
        private List<Person> firstTeam;
        private List<Person> reserveTeam;

        public Team(string name)
        {
            this.name = name;
            this.firstTeam = new List<Person>();
            this.reserveTeam = new List<Person>();
        }

        public IReadOnlyCollection<Person> FirstTeam { get=> this.firstTeam.AsReadOnly();}
        public IReadOnlyCollection<Person> ReserveTeam { get => this.reserveTeam.AsReadOnly();}

        public void AddPlayer(Person person)
        {
            if (person.Age<40)
            {
                firstTeam.Add(person);
            }
            else
            {
                reserveTeam.Add(person);
            }
        }
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"First team has {this.firstTeam.Count} players");
            sb.AppendLine($"Reserve team has {this.reserveTeam.Count} players");
            return sb.ToString();
        }
    }
}
