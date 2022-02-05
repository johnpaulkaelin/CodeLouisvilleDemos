using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace AlphabetEnhancedRobust
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

                string menuSelection;
                bool validInput = false;
                if (validInput = TryPrompt4MenuItem<string>("Please select one of the following options:", menu, out menuSelection, 5))
                {
                    switch (menuSelection)
                    {
                        case "A":
                            Console.WriteLine($"Here's the alphabet: {CreateAlphabet()}");
                            break;
                        case "Z":
                            Console.WriteLine($"Here's the alphabet backwards: {CreateAlphabetBackwards()}");
                            break;
                        case "S":
                            int numberToSkip;
                            if (validInput = TryPrompt4Integer(out numberToSkip, "What would you like the skip index to be: ", 5, 2, 25))
                                Console.WriteLine($"Here's the alphabet with a skip index of {numberToSkip}: {CreateAlphabetSkip(numberToSkip)}");
                            break;
                        case "Q":
                            quit = true;
                            break;
                    }
                }

                if (!validInput)
                    Console.WriteLine("\nSorry your input was not valid.  Maybe you can try again.");

                if (!quit)
                {
                    bool shouldContinue = false;
                    validInput = TryPromptYesNo("\nDo you want to continue with the Alphabet app?", out shouldContinue, 5);
                    if (!validInput)
                        Console.WriteLine("Sorry, your input was invalid.  You will be exiting the Alphabet app.");
                    quit = !validInput || !shouldContinue;
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

        // maxAttempts = 0 means unlimited
        static bool TryPrompt4MenuItem<T>(string prompt, List<KeyValuePair<T, string>> menu, out T menuSelection, uint maxAttempts = 0)
        {
            if (string.IsNullOrWhiteSpace(prompt))
                prompt = "Please select one of the following options:";

            bool success = false;
            uint attempt = 0;
            bool quit = false;
            menuSelection = default(T);

            do
            {
                if (maxAttempts > 0) // if user has a limited number of attempts
                {
                    attempt++;
                    WriteRetryPrompt(attempt, maxAttempts);
                }

                Console.WriteLine(prompt);
                // this is the menu
                foreach (KeyValuePair<T, string> menuItem in menu)
                {
                    Console.WriteLine($"\t{menuItem.Key.ToString()}: {menuItem.Value}");
                }
                Console.Write("Selection: ");
                string userSelection = Console.ReadLine();

                if (menu.Any(mi => mi.Key.ToString().ToUpper() == userSelection.ToUpper()))
                {
                    success = true;
                    menuSelection = menu.FirstOrDefault(mi => mi.Key.ToString() == userSelection.ToUpper()).Key;
                }
                else
                    Console.WriteLine($"{userSelection} is not an available option");

                // quit when they've selected a menu option like we've asked
                // OR they've exceeded the maximum number of allowed attempts
                quit = success || attempt >= maxAttempts;

                if (!quit) Console.WriteLine();

            } while (!quit);

            return success;
        }

        // maxAttempts = 0 means unlimited
        static bool TryPrompt4Integer(out int value, string prompt = "", uint maxAttempts = 0, int minValue = int.MinValue, int maxValue = int.MaxValue)
        {
            if (minValue > maxValue)
                throw new ArgumentException("minValue must be <= maxValue");

            if (string.IsNullOrWhiteSpace(prompt))
            {
                StringBuilder newPrompt = new StringBuilder("Enter a number");
                if (minValue != int.MinValue)
                    newPrompt.Append($" >= {minValue}");
                if (minValue != int.MinValue && maxValue != int.MaxValue)
                    newPrompt.Append(" and");
                if (maxValue != int.MaxValue)
                    newPrompt.Append($" <= {maxValue}");
                if (maxAttempts > 0)
                    newPrompt.Append($" (You will get {maxAttempts} tries)");
                newPrompt.Append(": ");
                prompt = newPrompt.ToString();
            }

            bool success = false;
            uint attempt = 0;
            bool quit = false;

            do
            {
                if (maxAttempts > 0) // if user has a limited number of attempts
                {
                    attempt++;
                    WriteRetryPrompt(attempt, maxAttempts);
                }

                Console.Write(prompt);

                success = int.TryParse(Console.ReadLine(), out value);
                if (!success)
                    Console.WriteLine("Entry is not a number.");
                else if (value < minValue || value > maxValue)
                {
                    // they entered a number but it's outside of the range
                    // we wanted
                    success = false;
                    Console.WriteLine($"Input must be between {minValue} and {maxValue}");
                }

                // quit when they've entered a number like we've asked
                // OR they've exceeded the maximum number of allowed attempts
                quit = success || attempt >= maxAttempts;

                if (!quit) Console.WriteLine();

            } while (!quit);

            return success;
        }

        // maxAttempts = 0 means unlimited
        static bool TryPromptYesNo(string prompt, out bool response, uint maxAttempts = 0, string yesResponse = "Y", string noResponse = "N")
        {
            if (string.IsNullOrWhiteSpace(prompt))
                prompt = $"Please answer Yes ({yesResponse}) or No ({noResponse}): ";

            bool success = false;
            uint attempt = 0;
            bool quit = false;
            response = false;

            do
            {
                if (maxAttempts > 0) // if user has a limited number of attempts
                {
                    attempt++;
                    WriteRetryPrompt(attempt, maxAttempts);
                }
                Console.Write(prompt);
                string userInput = Console.ReadLine();
                if (userInput.ToUpper() == yesResponse.ToUpper() || userInput.ToUpper() == noResponse.ToUpper())
                {
                    success = true;
                    response = (userInput.ToUpper() == yesResponse.ToUpper());
                }
                else
                {
                    Console.WriteLine($"Invalid input.  Please enter {yesResponse} (Yes) or {noResponse} (No).");
                }

                // quit when they've selected a menu option like we've asked
                // OR they've exceeded the maximum number of allowed attempts
                quit = success || attempt >= maxAttempts;

                if (!quit) Console.WriteLine();

            } while (!quit);

            return success;
        }

        static void WriteRetryPrompt(uint attempt, uint maxAttempts)
        {
            if (maxAttempts > 0 && attempt <= maxAttempts)
            {
                if (maxAttempts == 1)
                    Console.WriteLine("You only get one try.");
                else if (attempt > 1)
                {
                    if (maxAttempts - attempt == 0)
                        Console.WriteLine("This is your last try.");
                    else
                        Console.WriteLine($"You have {maxAttempts - attempt + 1} attempts remaining.");
                }
            }
        }

        static string CreateTimeSpentString(DateTime startTime, DateTime endTime)
        {
            TimeSpan timeSpent = endTime - startTime;

            List<string> timeSpentStringParts = new List<string>();
            if (timeSpent.Days > 0)
                timeSpentStringParts.Add($"{timeSpent.Days} Day{(timeSpent.Days > 1 ? "s" : "")}");
            if (timeSpent.Hours > 0)
                timeSpentStringParts.Add($"{timeSpent.Hours} Hour{(timeSpent.Hours > 1 ? "s" : "")}");
            if (timeSpent.Minutes > 0)
                timeSpentStringParts.Add($"{timeSpent.Minutes} Minute{(timeSpent.Minutes > 1 ? "s" : "")}");
            if (timeSpent.Seconds > 0)
                timeSpentStringParts.Add($"{timeSpent.Seconds} Second{(timeSpent.Seconds > 1 ? "s" : "")}");
            if (timeSpent.Milliseconds > 0)
                timeSpentStringParts.Add($"{timeSpent.Milliseconds} Millisecond{(timeSpent.Milliseconds > 1 ? "s" : "")}");

            StringBuilder timeSpentString = new StringBuilder("");

            if (timeSpentStringParts.Count > 0)
            {
                if (timeSpentStringParts.Count == 1)
                    timeSpentString.Append(timeSpentStringParts[0]);
                else
                {
                    timeSpentString.Append(string.Join(", ", timeSpentStringParts.Take(timeSpentStringParts.Count - 1).ToArray()));
                    timeSpentString.Append($" and {timeSpentStringParts[timeSpentStringParts.Count - 1]}");
                }

            }
            return timeSpentString.ToString();
        }
    }
}
