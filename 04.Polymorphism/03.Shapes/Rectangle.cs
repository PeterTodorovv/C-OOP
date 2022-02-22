using System;
using System.Collections.Generic;
using System.Text;

namespace Shapes
{
    internal class Rectangle : Shape
    {
        private double height;
        private double width;

        public Rectangle(double height, double width)
        {
            this.height = height;
            this.width = width;
        }
        public double Height { get { return height; } set { height = value; } }
        public double Width { get { return width; } set { width = value; } }
        public override double CalculateArea()
        {
            throw new NotImplementedException();
        }

        public override double CalculatePerimeter()
        {
            throw new NotImplementedException();
        }
    }
}
