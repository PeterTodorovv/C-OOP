using System;
using System.Collections.Generic;
using System.Text;

namespace Shapes
{
    internal class Circle : Shape
    {
        public Circle(double radius)
        {
            Radius = radius;
        }

        public double Radius { get; private set; }
        public override double CalculateArea()
        {
            return Radius * Radius * Math.PI;
        }

        public override double CalculatePerimeter()
        {
            return 2 * Radius * Math.PI;
        }
    }
}
