using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shapes.Classes
{
    public class Circle : Shape
    {
        public double Radius { get;  }

        public Circle(double radius, ConsoleColor borderColor, ConsoleColor fillColor) : base(borderColor, fillColor)
        {
            if (radius < 0) throw new ArgumentOutOfRangeException("radius", "Radius must be greater than zero.");
            Radius = radius;
        }

        public double Diameter { get { return 2 * Radius; } }

        public override double Area()
        {
            return 2 * Math.PI * Radius;
        }

        public override double Perimiter()
        {
            return Math.PI * Math.Pow(Radius, 2);
        }
    }
}
