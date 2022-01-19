using System;
using System.Text;

namespace StringBuilderExample
{
    class Program
    {
        static void Main(string[] args)
        {
            StringBuilder alphabet = new StringBuilder();
            for(char alpha = 'A'; alpha <= 'Z'; alpha++)
            {
                alphabet.Append(alpha);
            }

            Console.WriteLine(alphabet.ToString());
        }
    }
}
