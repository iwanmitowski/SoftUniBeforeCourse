using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.FootballBetting.Data.Models
{
    public class Position
    {
        public int PositionId { get; set; }

        [Required]
        public string Name { get; set; }

        public virtual ICollection<Player> Players { get; set; }
    }
}
