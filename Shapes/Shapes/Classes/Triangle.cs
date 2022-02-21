using Shapes.AbstractClasses;
using System;
namespace Shapes.Classes
{
    public class Triangle : ShapeBase
    {
        public override double Area
        {
            get
            {
                double s = (Side1 + Side2 + Side3) / 2;
                return Math.Sqrt(s * (s - Side1) * (s - Side2) * (s - Side3));
            }
        }

        public override double Perimiter
        {
            get
            {
                return Side1 + Side2 + Side3;
            }
        }
        public override string Description
        {
            get
            {
                return $"Side lengths ({Side1}, {Side2}, {Side3})";
            }
        }

        public double Side1 { get; }
        public double Side2 { get; }
        public double Side3 { get; }

        public Triangle(double side1, double side2, double side3) : base("Triangle")
        {
            Side1 = side1;
            Side2 = side2;
            Side3 = side3;

            if (!CheckSides())
                throw new ArgumentException($"These 3 sides do NOT make a triangle ({side1},{side2},{side3})");
        }

        private bool CheckSides()
        {
            return Side1 + Side2 > Side3 && Side2 + Side3 > Side1 && Side1 + Side3 > Side2;
        }
    }
}
