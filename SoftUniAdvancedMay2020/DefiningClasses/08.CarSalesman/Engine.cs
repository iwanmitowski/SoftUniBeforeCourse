using System;
using System.Collections.Generic;
using System.Text;

namespace _08.CarSalesman
{
    public class Engine
    {
        public Engine(string model, string power)
        {
            this.Model = model;
            this.Power = power;
            this.Displacement = 0;
            this.Efficiency = "n/a";
        }
        public Engine(string model, string power, int displacement) : this(model, power)
        {
            this.Displacement = displacement;
        
        }
        public Engine(string model, string power, string efficiency) : this(model, power)
        {
            this.Efficiency = efficiency;

        }

        public Engine(string model, string power, int displacement, string efficiency) : this(model, power)
        {
            this.Displacement = displacement;
            this.Efficiency = efficiency;
        }

        public string Model { get; set; }
        public string Power { get; set; }
        public int Displacement { get; set; }
        public string Efficiency { get; set; }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"{this.Model}:");
            sb.AppendLine($"    Power: {this.Power}");
            if (this.Displacement != 0)
            {
                sb.AppendLine($"    Displacement: {this.Displacement}");
            }
            else
            {
                sb.AppendLine($"    Displacement: n/a");

            }
            if (this.Efficiency != "n/a")
            {
                sb.AppendLine($"    Efficiency: {this.Efficiency}");
            }
            else
            {
                sb.AppendLine($"    Efficiency: n/a");

            }

            return sb.ToString().Trim();
        }
    }
}
