using System;
using System.Collections.Generic;
using System.Text;

namespace _08.CarSalesman
{
    public class Car
    {
        public Car(string model, Engine engine)
        {
            this.Model = model;
            this.Engine = engine;
            this.Weight = 0;
            this.Color = "n/a";
        }
        public Car(string model, Engine engine, int weight) : this(model, engine)
        {
            this.Weight = weight;
        }
        public Car(string model, Engine engine, string color) : this(model, engine)
        {
            this.Color = color;
        }

        public Car(string model, Engine engine, int weight, string Color) : this(model, engine)
        {
            this.Weight = weight;
            this.Color = Color;
        }
        public string Model { get; set; }
        public Engine Engine { get; set; }
        public int Weight { get; set; }
        public string Color { get; set; }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"{this.Model}:");
            sb.AppendLine($"  {this.Engine}");
            if (this.Weight != 0)
            {
                sb.AppendLine($"  Weight: {this.Weight}");
            }
            else
            {
                sb.AppendLine($"  Weight: n/a");
            }
            if (this.Color != "n/a")
            {
                sb.AppendLine($"  Color: {this.Color}");
            }
            else
            {
                sb.AppendLine($"  Color: n/a");
            }

            return sb.ToString().Trim();
        }
    }
}
