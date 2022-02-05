using System;
using System.Collections.Generic;
using System.Text;

namespace AlphabetClasses.Classes
{
    class CodeLouUserInput
    {
        public string AppName { get; set; }

        public CodeLouUserInput(string appName)
        {
            AppName = appName;
        }

        public void Welcome()
        {
            Console.Write($"Welcome to {AppName}!  Press any key to continue...");
            Console.ReadKey();
        }

        public void Goodbye(DateTime startTime, DateTime endTime)
        {
            Console.WriteLine($"\nYou spent {CreateTimeSpentString(startTime, endTime)} playing {AppName}.");
            Console.WriteLine("I hope you enjoyed it and will come back again.");
        }

        private string CreateTimeSpentString(DateTime startTime, DateTime endTime)
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
                timeSpentString.Append(timeSpentStringParts[0]);

                for (int i = 1; i < timeSpentStringParts.Count; i++)
                {
                    if (i == timeSpentStringParts.Count - 1) // if the last entry in the list
                        timeSpentString.Append($" and {timeSpentStringParts[i]}");
                    else
                        timeSpentString.Append($", {timeSpentStringParts[i]}");
                }
            }
            return timeSpentString.ToString();
        }

        public static int Prompt4Integer(string prompt)
        {
            int value;

            do
            {
                Console.Write(prompt);
            }
            while (!int.TryParse(Console.ReadLine(), out value));

            return value;
        }

        public static string Prompt4MenuItem(string prompt, List<KeyValuePair<string, string>> menu)
        {
            Console.WriteLine(prompt);
            // this is the menu
            foreach (KeyValuePair<string, string> menuItem in menu)
            {
                Console.WriteLine($"\t{menuItem.Key.ToString()}: {menuItem.Value}");
            }
            Console.Write("Selection: ");
            string userSelection = Console.ReadLine();

            foreach (KeyValuePair<string, string> menuitem in menu)
            {
                if (menuitem.Key.ToUpper() == userSelection.ToUpper())
                    return menuitem.Key;
            }

            return "";
        }

        public static bool PromptYesNo(string prompt)
        {
            string userInput = "";

            do
            {
                Console.Write(prompt);
                userInput = Console.ReadLine();
            } while (userInput.ToUpper() != "Y" && userInput.ToUpper() != "N");

            return userInput.ToUpper() == "Y";
        }
    }
}
