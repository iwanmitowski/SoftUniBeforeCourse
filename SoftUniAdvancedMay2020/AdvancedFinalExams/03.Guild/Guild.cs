using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Guild
{
    public class Guild
    {
        private List<Player> roaster;

        public Guild(string name, int capacity)
        {
            Name = name;
            Capacity = capacity;
            roaster = new List<Player>();
        }

        public string Name { get; set; }
        public int Capacity { get; set; }
        public int Count => this.roaster.Count;

        public void AddPlayer(Player player)
        {
            if (Count<Capacity)
            {
                roaster.Add(player);
            }
        }

        public bool RemovePlayer(string name)
        {
            Player searched = this.roaster.FirstOrDefault(x => x.Name == name);
            if (searched==null)
            {
                return false;
            }
            return true;
        }

        public void PromotePlayer(string name)
        {
            Player searched = this.roaster.FirstOrDefault(x => x.Name == name);
            int indexOfPlayer = this.roaster.IndexOf(searched);
            if (searched != null)
            {
                this.roaster[indexOfPlayer].Rank = "Member";
            }
        }

        public void DemotePlayer(string name)
        {
            Player searched = this.roaster.FirstOrDefault(x => x.Name == name);
            int indexOfPlayer = this.roaster.IndexOf(searched);
            if (searched != null)
            {
                this.roaster[indexOfPlayer].Rank = "Trial";
            }
        }

        public Player[] KickPlayersByClass(string @class)
        {
            Player[] arr = this.roaster.Where(x => x.Class == @class).ToArray();

            this.roaster = this.roaster.Where(x => x.Class != @class).ToList();
            return arr;
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Players in the guild: {this.Name}");
            foreach (Player player in roaster)
            {
                sb.AppendLine(player.ToString());
            }

            return sb.ToString().Trim();
        }
        
    }
}
