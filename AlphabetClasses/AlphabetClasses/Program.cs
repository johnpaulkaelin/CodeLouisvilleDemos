using System;
using System.Collections.Generic;
using System.Text;
using AlphabetClasses.Classes;

namespace AlphabetClasses
{
    class Program
    {
        static void Main(string[] args)
        {
            DateTime startTime = DateTime.Now;

            CodeLouUserInput alphabetApp = new CodeLouUserInput("The Alphabet App");
            alphabetApp.Welcome();

            bool quit = false;
            do
            {
                Console.Clear();

                List<KeyValuePair<string, string>> menu = new List<KeyValuePair<string, string>>();
                menu.Add(new KeyValuePair<string, string>("A", "Print the alphabet"));
                menu.Add(new KeyValuePair<string, string>("Z", "Print the alphabet backwards"));
                menu.Add(new KeyValuePair<string, string>("S", "Print the alphabet with some letters skipped"));
                menu.Add(new KeyValuePair<string, string>("Q", "Quit"));

                string menuSelection = CodeLouUserInput.Prompt4MenuItem("Please select one of the following options:", menu);

                switch (menuSelection)
                {
                    case "A":
                        Console.WriteLine($"Here's the alphabet: {CreateAlphabet()}");
                        break;
                    case "Z":
                        Console.WriteLine($"Here's the alphabet backwards: {CreateAlphabetBackwards()}");
                        break;
                    case "S":
                        int numberToSkip = CodeLouUserInput.Prompt4Integer("What would you like the skip index to be (between 2 and 25): ");
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
                    bool continueRunning = CodeLouUserInput.PromptYesNo("\nDo you want to continue with the Alphabet app (Y or N)?");
                    quit = !continueRunning;
                }


            } while (!quit);

            DateTime endTime = DateTime.Now;
            alphabetApp.Goodbye(startTime, endTime);
        }

        static string CreateAlphabet()
        {
            StringBuilder alphabet = new StringBuilder();
            for (char alpha = 'A'; alpha <= 'Z'; alpha++)
            {
                alphabet.Append(alpha);
            }
            return alphabet.ToString();
        }

        static string CreateAlphabetBackwards()
        {
            string alphabetBackwards = "";
            for (char alpha = 'Z'; alpha >= 'A'; alpha--)
            {
                alphabetBackwards += alpha;
            }
            return alphabetBackwards;
        }

        static string CreateAlphabetSkip(int skip)
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
