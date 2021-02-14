using System;
using System.Collections.Generic;
using System.Text;

namespace FootballTeamGenerator
{
   public class Player
    {
        private string name;
        private int endurance;
        private int sprint;
        private int dribble;
        private int passing;
        private int shooting;

        public Player(string name, int endurance, int sprint, int dribble, int passing, int shooting)
        {
            Name = name;
            Endurance = endurance;
            Sprint = sprint;
            Dribble = dribble;
            Passing = passing;
            Shooting = shooting;
        }

        public string Name
        {
            get { return name; }
            private set
            {
                if (string.IsNullOrEmpty(value)||string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("A name should not be empty.");
                }
                name = value;
            }
        }


        public int Endurance
        {
            get { return endurance; }
            private set
            {
                ValidateStats(value, nameof(this.Endurance));

                endurance = value;
            }
        }

        public int Sprint
        {
            get { return sprint; }
            private set
            {
                ValidateStats(value, nameof(this.Sprint));

                sprint = value;
            }
        }

        public int Dribble
        {
            get { return dribble; }
            private set
            {
                ValidateStats(value, nameof(this.Dribble));

                dribble = value;
            }
        }


        public int Passing
        {
            get { return passing; }
            private set
            {
                ValidateStats(value, nameof(this.Passing));

                passing = value;
            }
        }

        public int Shooting
        {
            get { return shooting; }
            private set
            {
                ValidateStats(value, nameof(this.Shooting));

                shooting = value;
            }
        }

        public double OveralSkillLevel
        {
            get
            {
                double calcs = (this.Endurance + this.Sprint + this.Dribble + this.Passing + this.Shooting) / 5.0;
                return calcs;
            }
        }

        private void ValidateStats(int value, string stat)
        {
            if (value < 0 || value > 100)
            {
                throw new ArgumentException($"{stat} should be between 0 and 100.");
            }
        }
    }
}
