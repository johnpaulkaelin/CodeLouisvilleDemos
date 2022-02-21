using Shapes.AbstractClasses;
using System;

namespace Shapes.Classes
{
    public class Circle : ShapeBase
    {
        public override double Area
        {
            get
            { 
                return Math.PI * Math.Pow(Radius, 2);
            }
        }

        public override double Perimiter
        {
            get
            {
                return 2 * Math.PI * Radius;
            }
        }

        public override string Description
        {
            get
            {
                return $"Radius {Radius}, Diameter {Diameter}";
            }
        }

        public double Radius { get;  }

        public double Diameter { get { return 2 * Radius; } }

        public Circle(double radius) : base("Circle")
        {
            if (radius < 0) throw new ArgumentOutOfRangeException("radius", "Radius must be greater than zero.");
            Radius = radius;
        }

    }
}
