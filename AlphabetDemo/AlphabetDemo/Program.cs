using System;

namespace AlphabetDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            PrintAlphabet();

            PrintAlphabetBackwards();

            PrintAlphabetSkipOneLetter();
        }

        static void PrintAlphabet()
        {
            string alphabet = string.Empty;
            for(char alpha = 'A'; alpha <= 'Z'; alpha++)
            {
                alphabet += alpha;
            }

            Console.WriteLine(alphabet);
        }

        static void PrintAlphabetBackwards()
        {
            string alphabet = string.Empty;
            for(char alpha = 'Z'; alpha >= 'A'; alpha--)
            {
                alphabet += alpha;
            }

            Console.WriteLine(alphabet);
        }

        static void PrintAlphabetSkipOneLetter()
        {
            string alphabet = string.Empty;
            for(char alpha = 'A'; alpha <= 'Z'; alpha = (char) (alpha + 2))
            {
                alphabet += alpha;
            }

            Console.WriteLine(alphabet);
        }
    }
}
