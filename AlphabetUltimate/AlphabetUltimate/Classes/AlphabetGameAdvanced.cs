using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CodeLouisvilleLibrary;

namespace AlphabetUltimate.Classes
{
    public class AlphabetGameAdvanced : CodeLouisvilleAppBase
    {
        public AlphabetGameAdvanced() : base("The Alphabet Game - Advanced")
        {

        }
        public override bool PlayGame()
        {

            bool quit = false;

            var menu = new Menu<char>();
            menu.AddMenuItem('A', "Print the alphabet");
            menu.AddMenuItem('Z', "Print the alphabet backwards");
            menu.AddMenuItem('S', "Print the alphabet with some letters skipped");
            menu.AddMenuItem('Q', "Quit");

            char menuSelection;
            bool validInput = false;
            if (validInput = TryPrompt4MenuItem<char>("Please select one of the following options:", menu, out menuSelection, 5))
            {
                switch (menuSelection)
                {
                    case 'A':
                        Console.WriteLine($"\nHere's the alphabet: {CreateAlphabet()}");
                        break;
                    case 'Z':
                        Console.WriteLine($"\nHere's the alphabet backwards: {CreateAlphabetBackwards()}");
                        break;
                    case 'S':
                        int numberToSkip;
                        if (validInput = TryPrompt4Integer(out numberToSkip, "\nWhat would you like the skip index to be: ", 5, 2, 25))
                            Console.WriteLine($"\nHere's the alphabet with a skip index of {numberToSkip}: {CreateAlphabetSkip(numberToSkip)}");
                        break;
                    case 'Q':
                        quit = true;
                        break;
                }
            }

            if (!validInput)
                Console.WriteLine("\nSorry your input was not valid.  Maybe you can try again.");

            return !quit;
        }


        private string CreateAlphabet()
        {
            StringBuilder alphabet = new StringBuilder();
            for (char alpha = 'A'; alpha <= 'Z'; alpha++)
            {
                alphabet.Append(alpha);
            }
            return alphabet.ToString();
        }

        private string CreateAlphabetBackwards()
        {
            string alphabetBackwards = "";
            for (char alpha = 'Z'; alpha >= 'A'; alpha--)
            {
                alphabetBackwards += alpha;
            }
            return alphabetBackwards;
        }

        private string CreateAlphabetSkip(int skip)
        {
            string alphabetSkipped = "";
            for (char alpha = 'A'; alpha <= 'Z';)
            {
                alphabetSkipped += alpha;
                for (int i = 0; i < skip; i++)
                {
                    alpha++;
                }

            }
            return alphabetSkipped;
        }
    }
}
