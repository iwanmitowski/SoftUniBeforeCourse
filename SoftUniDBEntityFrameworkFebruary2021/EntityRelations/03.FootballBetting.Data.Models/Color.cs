using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace _03.FootballBetting.Data.Models
{
    public class Color
    {
        public Color()
        {
            this.PrimaryKitTeams = new HashSet<Team>();
            this.SecondaryKitTeams = new HashSet<Team>();
        }

        public int ColorId { get; set; }

        [Required]
        public string Name { get; set; }

        //Виж FootballBettingContext-a за допълнителните настройки
        [InverseProperty(nameof(Team.PrimaryKitColor))]
        public virtual ICollection<Team> PrimaryKitTeams { get; set; }

        //Виж FootballBettingContext-a за допълнителните настройки
        [InverseProperty(nameof(Team.SecondaryKitColor))]
        public virtual ICollection<Team> SecondaryKitTeams { get; set; }
    }
}
