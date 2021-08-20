using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.FootballBetting.Data.Models
{
    public class PlayerStatistic
    {
        public int GameId { get; set; }

        public Game Game { get; set; }

        public int PlayerId { get; set; }

        public Player Player { get; set; }

        public int ScoredGoals { get; set; }

        public int Assists { get; set; }

        public double MinutesPlayed { get; set; }
    }
}
