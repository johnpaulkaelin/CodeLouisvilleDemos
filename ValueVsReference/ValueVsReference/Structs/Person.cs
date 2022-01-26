using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ValueVsReference.Structs
{
    public struct Person
    {
        public byte Age { get; set; }

        //private byte _age;
        //public byte Age { 
        //    get
        //    {
        //        return _age;
        //    }
        //    set
        //    {
        //        if (value > 120)
        //            throw new ArgumentException($"Invalid age {value}.  Age cannot be > 120.");

        //        _age = value;
        //    }         
        //}
    }
}
