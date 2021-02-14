using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FootballTeamGenerator
{
    public class Team
    {
        private List<Player> team;
        private string name;

        public Team(string name)
        {
            Name = name;
            this.team = new List<Player>();
        }

        public int Rating
        {

            get
            {
                if (this.TeamCount==0)
                {
                    return 0;
                }
                return (int)(Math.Round(team.Select(x => x.OveralSkillLevel).Average(),0));
            }
        }
        public int TeamCount { get => this.team.Count; }
        public string Name
        {
            get { return name; }
            set
            {
                if (string.IsNullOrEmpty(value) || string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("A name should not be empty.");
                }
                name = value;
            }
        }
        public IReadOnlyList<Player> Roaster
        {
            get
            {
                return this.team.AsReadOnly();
            }
        }
        public void AddPlayer(Player player)
        {
            this.team.Add(player);
        }
        public void RemovePlayer(string playerName)
        {
            Player playerToRemove = this.team.FirstOrDefault(x => x.Name == playerName);

            if (this.team.Count == 0 || playerToRemove == null)
            {
                throw new ArgumentException($"Player {playerName} is not in {this.Name} team.");
            }
            
            this.team.Remove(playerToRemove);
        }
    }
}
