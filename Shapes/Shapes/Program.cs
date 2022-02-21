using System;
using System.Collections.Generic;
using Shapes.Classes;
using Shapes.Interfaces;

namespace Shapes
{
    class Program
    {
        static void Main(string[] args)
        {
            var shapes = new List<IShape>();

            shapes.Add(new Circle(2.5));
            shapes.Add(new Rectangle(2.3, 4.75));
            shapes.Add(new Circle(.75));
            shapes.Add(new Triangle(2, 3, 4));
            shapes.Add(new Triangle(7, 9, 11));
            shapes.Add(new Triangle(2.5, 3.25, 5.5));
            shapes.Add(new Rectangle(23, 75));
            shapes.Add(new Circle(53));

            foreach(IShape shape in shapes)
            {
                Console.WriteLine(shape.ToString() + $" has Area = {shape.Area} and Perimiter = {shape.Perimiter}");
            }
        }
    }
}
