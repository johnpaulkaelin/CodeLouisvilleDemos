using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shapes.Interfaces;

namespace Shapes.Classes
{
    public abstract class Shape : IShape
    {
        public Shape(ConsoleColor borderColor, ConsoleColor fillColor)
        {
            BorderColor = borderColor;
            FillColor = fillColor;
        }

        public ConsoleColor BorderColor { get; set; }
        public ConsoleColor FillColor { get; set; }
        public abstract double Area();
        public abstract double Perimiter();
    }
}
