using Shapes.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shapes.AbstractClasses
{
    public abstract class ShapeBase : IShape
    {
        public string Name { get; protected set; }

        public abstract string Description { get; }

        public abstract double Area { get; }

        public abstract double Perimiter { get; }

        public ShapeBase(string name)
        {
            Name = name;
        }

        public override string ToString()
        {
            return $"{Name}: {Description}";
        }
    }
}
