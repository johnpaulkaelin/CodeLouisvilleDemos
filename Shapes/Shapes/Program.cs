using System;
using Shapes.Classes;

namespace Shapes
{
    class Program
    {
        static void Main(string[] args)
        {
            Circle c1 = new Circle(2.5, ConsoleColor.Black, ConsoleColor.DarkRed);
            Console.WriteLine($"c1's circumference is {c1.Perimiter()}. c1's area is {c1.Area()}");

            Rectangle r1 = new Rectangle(5.25, 8.75, ConsoleColor.DarkMagenta, ConsoleColor.DarkCyan);
            Console.WriteLine($"r1's perimiter is {r1.Perimiter()}. r1's area is {r1.Area()}");

            Triangle t1 = new Triangle(2, 3, 4, ConsoleColor.Gray, ConsoleColor.DarkCyan);
            Console.WriteLine($"t1's perimiter is {t1.Perimiter()}. t1's area is {t1.Area()}");
        }
    }
}
