using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shapes.Classes
{
    public class Rectangle : Shape
    {
        public double Length { get; }
        public double Width { get; }

        public Rectangle(double length, double width, ConsoleColor borderColor, ConsoleColor fillColor) : base(borderColor, fillColor)
        {
            if (length <= 0) throw new ArgumentOutOfRangeException("length", "Length must be greater than zero.");
            if (width < 0) throw new ArgumentOutOfRangeException("width", "Width must be greater than zero.");
            Length = length;
            Width = width;
        }

        public override double Area()
        {
            return Length * Width;
        }

        public override double Perimiter()
        {
            return 2 * Length + 2 * Width;
        }
    }
}
