using System;
using System.Collections.Generic;
using System.Text;

namespace Shapes
{
    class Circle : Shape
    {
        private double radius;

        public Circle(double radius)
        {
            this.Radius = radius;
        }

        public double Radius
        {
            get { return radius; }
            set
            {
                if (value <= 0)
                {
                    throw new InvalidInputException("Radius must be positive number!");
                }
                radius = value;
            }
        }

        public override double CalculateArea()
        {
            return Math.PI * this.radius * this.radius;
        }

        public override double CalculatePerimeter()
        {
            return Math.PI * (this.radius * 2);
        }

        public override string Draw()
        {
            return base.Draw()+this.GetType().Name;
        }
    }
}
