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

            // these are just examples of same thing 
            // using while loops instead of for loops

            PrintAlphabetUsingWhileLoop();

            PrintAlphabetBackwardsUsingWhileLoop();

            PrintAlphabetSkipOneLetterUsingWhileLoop();

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

        static void PrintAlphabetUsingWhileLoop()
        {
            string alphabet = string.Empty;
            char alpha = 'A';
            while(alpha <= 'Z')
            {
                alphabet += alpha++;

                // above line in same as this.  C# programmers like to cram as much into one line as possible :)
                //alphabet += alpha;
                //alpha++;

                // it's also the same as.  but you have that ugly cast operation
                //alphabet = alphabet + alpha;
                //alpha = (char)(alpha + 1);
            }

            Console.WriteLine(alphabet);
        }

        static void PrintAlphabetBackwardsUsingWhileLoop()
        {
            string alphabet = string.Empty;
            char alpha = 'Z';
            while(alpha >= 'A')
            {
                alphabet += alpha--;

                // same as
                //alphabet += alpha;
                //alpha--;

                //and
                //alphabet = alphabet + alpha;
                //alpha = (char)(alpha - 1);
            }

            Console.WriteLine(alphabet);
        }

        static void PrintAlphabetSkipOneLetterUsingWhileLoop()
        {
            string alphabet = string.Empty;
            char alpha = 'A';
            while (alpha <= 'Z')
            {
                alphabet += alpha;
                alpha = (char)(alpha + 2);
            }

            Console.WriteLine(alphabet);
        }
    }
}
