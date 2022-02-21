using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shapes.Interfaces
{
    interface IShape
    {
        public string Name { get; }

        public string Description { get; }

        public double Area { get;  }

        public double Perimiter { get; }


    }
}
