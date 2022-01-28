using System;
using AlphabetDemoUsingExtension.StringExtensions;

namespace AlphabetDemoUsingExtension
{
    class Program
    {
        static void Main(string[] args)
        {
            string alphabet = BuildAlphabet();

            // alphabet
            Console.WriteLine(alphabet);

            // alphabet reversed using extension method
            Console.WriteLine(alphabet.Reverse());

            // alphabet every other using extension method
            Console.WriteLine(alphabet.Skip(2));

            // some other examples
            Console.WriteLine(alphabet.Skip(-2));
            Console.WriteLine(alphabet.Skip(4));
        }

        static string BuildAlphabet()
        {
            string alphabet = string.Empty;
            for (char alpha = 'A'; alpha <= 'Z'; alpha++)
            {
                alphabet += alpha;
            }

            return alphabet;
        }
    }
}
