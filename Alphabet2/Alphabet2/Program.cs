using System;
using System.Collections.Generic;
using CodeLouisvilleLibrary;

namespace Alphabet2
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {

                var menuItem1 = new KeyValuePair<string, string>("A", "Display Alphabet");
                var menuItem2 = new KeyValuePair<string, string>("Z", "Display Alphabet Backwards");
                var menuItem3 = new KeyValuePair<string, string>("S", "Display Alphabet Skipping Letters");

                var menu = new List<KeyValuePair<string, string>>();
                menu.Add(menuItem1);
                menu.Add(menuItem2);
                menu.Add(menuItem3);

                string userInput = CodeLouisvilleProjectBase.Prompt4MenuItem("What would you like to do?", menu);

                switch (userInput.ToUpper())
                {
                    case "A":
                        Console.WriteLine(CreateAlphabet());
                        break;
                    case "Z":
                        Console.WriteLine(CreateAlphabetBackwards());
                        break;
                    case "S":
                        int nSkip = CodeLouisvilleProjectBase.Prompt4Integer("How many would you like to skip: ");
                        Console.WriteLine(CreateAlphabetSkipOneLetter(nSkip));
                        break;
                    default:
                        Console.WriteLine("Invalid menu selection!");
                        break;
                }

                bool didEnjoy = CodeLouisvilleProjectBase.Prompt4YesNo("\nDid you enjoy playing? (Y)es or (N)o:");           
                if (didEnjoy)
                    Console.WriteLine("\nGreat!");
                else
                    Console.WriteLine("\nSorry (:.");
            }
            catch(Exception e)
            {
                Console.WriteLine($"Error occurred {e.Message}.  Next time please follow instructions.");
            }
        }


        static string CreateAlphabet()
        {
            string alphabet = string.Empty;
            for (char alpha = 'A'; alpha <= 'Z'; alpha++)
            {
                alphabet += alpha;
            }
            return alphabet;
        }

        static string CreateAlphabetBackwards()
        {
            string alphabetBackwards = string.Empty;
            for (char alpha = 'Z'; alpha >= 'A'; alpha--)
            {
                alphabetBackwards += alpha;
            }
            return alphabetBackwards;
        }

        static string CreateAlphabetSkipOneLetter(int numberToSkip)
        {
            string alphabetSkip = string.Empty;
            for (char alpha = 'A'; alpha <= 'Z'; alpha = (char)(alpha + numberToSkip))
            {
                alphabetSkip += alpha;
            }
            return alphabetSkip;
        }
    }

}
