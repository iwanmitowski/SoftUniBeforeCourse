using System;
using System.Collections.Generic;
using System.Text;

namespace Shapes
{
    class Rectangle : Shape
    {
        private double height;
        private double width;

        public Rectangle(double height, double width)
        {
            this.Height = height;
            this.Width = width;
        }



        public double Height
        {
            get { return this.height; }
            set
            {
                ValidateSide(value, nameof(this.Height));
                this.height = value;

            }
        }
        public double Width
        {
            get { return this.width; }
            set
            {
                ValidateSide(value, nameof(this.Width));

                this.width = value;
            }
        }

        public override double CalculateArea()
        {
            return this.height * this.width;
        }

        public override double CalculatePerimeter()
        {
            return 2 * (this.height + this.width);
        }

        public override string Draw()
        {
            return base.Draw() + this.GetType().Name;
        }
        private void ValidateSide(double side, string sideName)
        {
            if (side<=0)
            {
                throw new InvalidInputException(sideName);
            }
        }
    }
}
