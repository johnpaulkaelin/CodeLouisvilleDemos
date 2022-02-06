using System;
using AlphabetUltimate.Classes;

namespace AlphabetUltimate
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter 1 to run the Simple Alphabet Game, 2 to run the Advanced: ");
            int selection;
            if (int.TryParse(Console.ReadLine(), out selection) && (selection == 1 || selection == 2))
            {
                CodeLouisvilleLibrary.CodeLouisvilleAppBase alphabetGame = null;
                switch(selection)
                {
                    case 1:
                        alphabetGame = new AlphabetGame();
                        break;
                    case 2:
                        alphabetGame = new AlphabetGameAdvanced();
                        break;
                }

                Console.Clear();
                alphabetGame.Run();
            }
            else
                Console.WriteLine("Invalid selection");
        }
    }
}
