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

            Console.Write($"Welcome to The Alphabet App!  Press any key to continue...");
            Console.ReadKey();

            bool quit = false;
            do
            {
                Console.Clear();

                List<KeyValuePair<char, string>> menuChar = new List<KeyValuePair<char, string>>();
                menuChar.Add(new KeyValuePair<char, string>('A', "Print the alphabet"));
                menuChar.Add(new KeyValuePair<char, string>('Z', "Print the alphabet backwards"));
                menuChar.Add(new KeyValuePair<char, string>('S', "Print the alphabet with some letters skipped"));
                menuChar.Add(new KeyValuePair<char, string>('Q', "Quit"));

                char menuCharSelection = Prompt4MenuItem("Please select one of the following options:", menuChar);

                List<KeyValuePair<int, string>> menuInt = new List<KeyValuePair<int, string>>();
                menuInt.Add(new KeyValuePair<int, string>(1, "Print the alphabet"));
                menuInt.Add(new KeyValuePair<int, string>(2, "Print the alphabet backwards"));
                menuInt.Add(new KeyValuePair<int, string>(3, "Print the alphabet with some letters skipped"));
                menuInt.Add(new KeyValuePair<int, string>(99, "Quit"));

                int menuIntSelection = Prompt4MenuItem("Please select one of the following options:", menuInt);

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

        static T Prompt4MenuItem<T>(string prompt, List<KeyValuePair<T, string>> menu)
        {
            Console.WriteLine(prompt);
            // this is the menu
            foreach(KeyValuePair<T, string> menuItem in menu)
            {
                Console.WriteLine($"\t{menuItem.Key.ToString()}: {menuItem.Value}");
            }
            Console.Write("Selection: ");
            string userSelection = Console.ReadLine();

            foreach(KeyValuePair<T, string> menuitem in menu)
            {
                if (menuitem.Key.ToString().ToUpper() == userSelection.ToUpper())
                    return menuitem.Key;
            }

            return default(T);
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

            //return timeSpent.ToString();

            return $"{timeSpent.Days} Day(s), {timeSpent.Hours} Hour(s), {timeSpent.Minutes} Minute(s), {timeSpent.Seconds} Second(s), and {timeSpent.Milliseconds} Millisecond(s)";

            //List<string> timeSpentStringParts = new List<string>();
            //if(timeSpent.Days > 0)
            //    timeSpentStringParts.Add($"{timeSpent.Days} Day{(timeSpent.Days > 1 ? "s" : "")}");
            //if(timeSpent.Hours > 0)
            //    timeSpentStringParts.Add($"{timeSpent.Hours} Hour{(timeSpent.Hours > 1 ? "s" : "")}");
            //if(timeSpent.Minutes > 0)
            //    timeSpentStringParts.Add($"{timeSpent.Minutes} Minute{(timeSpent.Minutes > 1 ? "s" : "")}");
            //if (timeSpent.Seconds > 0)
            //    timeSpentStringParts.Add($"{timeSpent.Seconds} Second{(timeSpent.Seconds > 1 ? "s" : "")}");
            //if (timeSpent.Milliseconds > 0)
            //    timeSpentStringParts.Add($"{timeSpent.Milliseconds} Millisecond{(timeSpent.Milliseconds > 1 ? "s" : "")}");

            //StringBuilder timeSpentString = new StringBuilder("");

            //if (timeSpentStringParts.Count > 0)
            //{
            //    timeSpentString.Append(timeSpentStringParts[0]);

            //    for(int i = 1; i < timeSpentStringParts.Count; i++)
            //    {
            //        if(i == timeSpentStringParts.Count - 1) // if the last entry in the list
            //            timeSpentString.Append($" and {timeSpentStringParts[i]}");
            //        else
            //            timeSpentString.Append($", {timeSpentStringParts[i]}");
            //    }     
            //}
            //return timeSpentString.ToString();
        }
    }
}
