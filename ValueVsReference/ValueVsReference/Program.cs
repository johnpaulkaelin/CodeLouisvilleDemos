using System;
//using ValueVsReference.Structs;
using ValueVsReference.Classes;

namespace ValueVsReference
{
    class Program
    {
        static void Main(string[] args)
        {
            Person p = new Person();

            p.Age = 30;

            Console.WriteLine($"p.Age = {p.Age}");

            Person pCopy = p;

            Console.WriteLine($"pCopy.Age = {pCopy.Age}");

            pCopy.Age = 50;

            Console.WriteLine($"pCopy.Age = {pCopy.Age}");

            // what will this be?
            Console.WriteLine($"p.Age = {p.Age}");
        }
    }
}
