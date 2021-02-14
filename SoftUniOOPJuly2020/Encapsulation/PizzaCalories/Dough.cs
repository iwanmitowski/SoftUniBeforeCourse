using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaCalories
{
    public class Dough
    {
        private const double BaseCalsPerGram = 2;
        private const int MinDough = 1;
        private const int MaxDough = 200;

        private readonly Dictionary<string, double> flourTypes = new Dictionary<string, double>()
        {
            {"white",1.5},
            {"wholegrain",1.0}
        };
        private readonly Dictionary<string, double> bakingTechniques = new Dictionary<string, double>()
        {
            {"crispy",0.9},
            {"chewy",1.1},
            {"homemade",1.0}
        };

        private string flourType;
        private string bakingTechnique;
        private int weight;

        public Dough(string flourType, string bakingTechnique, int weight)
        {
            FlourType = flourType;
            BakingTechnique = bakingTechnique;
            Weight = weight;
        }

        public string FlourType
        {
            get { return flourType; }
            private set
            {
                if (flourTypes.ContainsKey(value.ToLower()) == false)
                {
                    throw new ArgumentException("Invalid type of dough.");
                }
                flourType = value;
            }
        }

        public string BakingTechnique
        {
            get { return bakingTechnique; }
            set
            {
                if (bakingTechniques.ContainsKey(value.ToLower()) == false)
                {
                    throw new ArgumentException("Invalid type of dough.");
                }
                bakingTechnique = value;
            }
        }

        public int Weight
        {
            get { return weight; }
            set
            {
                if (value<MinDough||value>MaxDough)
                {
                    throw new ArgumentException($"Dough weight should be in the range [{MinDough}..{MaxDough}].");
                }
                weight = value;
            }
        }

        public double DoughCalories { get => BaseCalsPerGram * bakingTechniques[this.BakingTechnique.ToLower()] * flourTypes[this.FlourType.ToLower()] *this.Weight; }

    }

}
