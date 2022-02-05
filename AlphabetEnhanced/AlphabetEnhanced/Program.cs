using System;
using System.Collections.Generic;
using System.Text;

namespace AlphabetEnhanced
{
    class Program
    {
        static void Main(string[] args)
        {
            DateTime startTime = DateTime.Now;

            bool quit = false;
            do
            {
                Console.Clear();

                List<KeyValuePair<string, string>> menu = new List<KeyValuePair<string, string>>();
                menu.Add(new KeyValuePair<string, string>("A", "Print the alphabet"));
                menu.Add(new KeyValuePair<string, string>("Z", "Print the alphabet backwards"));
                menu.Add(new KeyValuePair<string, string>("S", "Print the alphabet with some letters skipped"));
                menu.Add(new KeyValuePair<string, string>("Q", "Quit"));

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
                    bool continueRunning = PromptYesNo("\nDo you want to continue with the Alphabet app (Y or N)?");
                    quit = !continueRunning;
                }

                
            } while (!quit);

            DateTime endTime = DateTime.Now;
            Console.WriteLine($"\nYou spent {CreateTimeSpentString(startTime, endTime)} playing the Alphabet game.");
            Console.WriteLine("I hope you enjoyed it and will come back again.");
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
            for (char alpha = 'A'; alpha <= 'Z'; )
            {
                alphabetSkipped += alpha;
                for(int i = 0; i < skip; i++)
                {
                    alpha++;
                }

            }
            return alphabetSkipped;
        }

        static string Prompt4MenuItem(string prompt, List<KeyValuePair<string, string>> menu)
        {
            Console.WriteLine(prompt);
            // this is the menu
            foreach(KeyValuePair<string, string> menuItem in menu)
            {
                Console.WriteLine($"\t{menuItem.Key.ToString()}: {menuItem.Value}");
            }
            Console.Write("Selection: ");
            string userSelection = Console.ReadLine();

            foreach(KeyValuePair<string, string> menuitem in menu)
            {
                if (menuitem.Key.ToUpper() == userSelection.ToUpper())
                    return menuitem.Key;
            }

            return "";
        }

        static int Prompt4Integer(string prompt)
        {
            int value;

            do
            {
                Console.Write(prompt);
            }
            while (!int.TryParse(Console.ReadLine(), out value));
            
            return value;
        }

        static bool PromptYesNo(string prompt)
        {
            string userInput = "";

            do
            {
                Console.Write(prompt);
                userInput = Console.ReadLine();
            } while (userInput.ToUpper() != "Y" && userInput.ToUpper() != "N");

            return userInput.ToUpper() == "Y";
        }

        static string CreateTimeSpentString(DateTime startTime, DateTime endTime)
        {
            TimeSpan timeSpent = endTime - startTime;

            List<string> timeSpentStringParts = new List<string>();
            if(timeSpent.Days > 0)
                timeSpentStringParts.Add($"{timeSpent.Days} Day{(timeSpent.Days > 1 ? "s" : "")}");
            if(timeSpent.Hours > 0)
                timeSpentStringParts.Add($"{timeSpent.Hours} Hour{(timeSpent.Hours > 1 ? "s" : "")}");
            if(timeSpent.Minutes > 0)
                timeSpentStringParts.Add($"{timeSpent.Minutes} Minute{(timeSpent.Minutes > 1 ? "s" : "")}");
            if (timeSpent.Seconds > 0)
                timeSpentStringParts.Add($"{timeSpent.Seconds} Second{(timeSpent.Seconds > 1 ? "s" : "")}");
            if (timeSpent.Milliseconds > 0)
                timeSpentStringParts.Add($"{timeSpent.Milliseconds} Millisecond{(timeSpent.Milliseconds > 1 ? "s" : "")}");

            StringBuilder timeSpentString = new StringBuilder("");

            if (timeSpentStringParts.Count > 0)
            {
                timeSpentString.Append(timeSpentStringParts[0]);

                for(int i = 1; i < timeSpentStringParts.Count; i++)
                {
                    if(i == timeSpentStringParts.Count - 1) // if the last entry in the list
                        timeSpentString.Append($" and {timeSpentStringParts[i]}");
                    else
                        timeSpentString.Append($", {timeSpentStringParts[i]}");
                }     
            }
            return timeSpentString.ToString();
        }
    }
}
