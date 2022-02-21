using Shapes.AbstractClasses;
using System;

namespace Shapes.Classes
{
    public class Rectangle : ShapeBase
    {
        public override double Area
        {
            get
            {
                return Length * Width;
            }
        }

        public override double Perimiter
        {
            get
            {
                return 2 * Length + 2 * Width;
            }
        }

        public double Length { get; }

        public double Width { get; }

        public override string Description
        {
            get
            {
                return $"Length {Length}, Width {Width}";
            }
        }

        public Rectangle(double length, double width) : base("Rectangle")
        {
            if (length <= 0) throw new ArgumentOutOfRangeException("length", "Length must be greater than zero.");
            if (width < 0) throw new ArgumentOutOfRangeException("width", "Width must be greater than zero.");
            Length = length;
            Width = width;
        }

    }
}
