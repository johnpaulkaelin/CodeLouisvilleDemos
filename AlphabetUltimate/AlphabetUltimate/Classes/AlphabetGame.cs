using System;
using System.Collections.Generic;
using System.Text;
using CodeLouisvilleLibrary;

namespace AlphabetUltimate.Classes
{
    public class AlphabetGame : CodeLouisvilleAppBase
    {
        public AlphabetGame() : base("The Alphabet Game")
        {

        }

        public override bool PlayGame()
        {
            bool quit = false;

            Menu menu = new Menu();
            menu.AddMenuItem("A", "Print the alphabet");
            menu.AddMenuItem("Z", "Print the alphabet backwards");
            menu.AddMenuItem("S", "Print the alphabet with some letters skipped");
            menu.AddMenuItem("Q", "Quit");

            string menuSelection = Prompt4MenuItem("Please select one of the following options:", menu);

            switch (menuSelection)
            {
                case "A":
                    Console.WriteLine($"Here's the alphabet: {CreateAlphabet()}");
                    break;
                case "Z":
                    Console.WriteLine($"Here's the alphabet backwards: {CreateAlphabetBackwards()}");
                    break;
                case "S":
                    int numberToSkip = Prompt4Integer("What would you like the skip index to be (between 2 and 25): ");
                    if (numberToSkip < 2 || numberToSkip > 25)
                        Console.WriteLine("Invalid entry.  Next time, please enter a number between 2 and 25.");
                    else
                        Console.WriteLine($"Here's the alphabet with a skip index of {numberToSkip}: {CreateAlphabetSkip(numberToSkip)}");
                    break;
                case "Q":
                    quit = true;
                    break;
                default:
                    Console.WriteLine("Your selection was invalid.");
                    break;
            }

            if (!quit)
            {
                Console.Write("\nPress any key to continue.");
                Console.ReadKey();
                Console.Clear();
            }

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
