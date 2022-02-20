using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using CodeLouisvilleLibrary;

namespace RandomNumberDemo
{
    public class RandomNumberDemoApp : CodeLouisvilleAppBase
    {
        // you want to use one instance of random class because it makes numbers more random
        private Random random = new Random();

        // this is just so value of 0 shows as "Heads", 1 as "Tails"
        private string[] coinSides = new string[] { "Heads", "Tails" };

        // the number of times each option was selected
        private int[] optionCounts = new int[3];

        // these are so we can keep tallies on the various random results
        private int[] randomNumberCounts = new int[10];
        private int[] dieValueCounts = new int[6];
        private int[] coinValueCounts = new int[2];

        public RandomNumberDemoApp() : base("Random Number Demo App")
        {

        }

        protected override bool Main()
        {
            Console.Clear();

            Menu<char> menu = new Menu<char>();
            menu.AddMenuItem('1', "Generate a Random Number between 1-10");
            menu.AddMenuItem('2', "Roll a dice");
            menu.AddMenuItem('3', "Flip a coin");

            int userSelection = Prompt4MenuItem("Please pick an option: ", menu);

            Console.WriteLine();

            switch(userSelection)
            {
                case '1':
                    // keep track of number of times option selected
                    optionCounts[0]++;

                    // this is just for show
                    Console.Write("Thinking ");
                    Animate(new string[] { "/", "--", "\\", "|" }, pause: 200, repeat: 4);

                    // ask the computer to generate a random number between 1 and 10
                    // the second parameter to Random.Next is one more than the max number
                    // that you want
                    int numberToGuess = random.Next(1, 11);
                    Console.WriteLine($"The random number is {numberToGuess}");

                    // keep counts of the number of times the random number was a 1 or a 2 or a 3 or a....10
                    // randomNumberCounts[0] will be the number of times that 1 was the random number
                    // randomNumberCounts[9] will be the number of times that 10 was the random number
                    randomNumberCounts[numberToGuess-1]++;
                    break;
                case '2':
                    // keep track of number of times option selected
                    optionCounts[1]++;

                    // this is just for show
                    List<string> rolling = new List<string>();
                    for(int i = 0; i < 8; i++)
                    {
                        rolling.Add(random.Next(1, 7).ToString());
                    }
                    Animate(rolling.ToArray(), pause: 250, slide: true);

                    // ask the computer to simulate rolling a dice by generating a random number between 1 and 6
                    int diceValue = random.Next(1, 7);
                    Console.WriteLine($"You rolled a {diceValue}");

                    // keep counts of the number of times a 1 was rolled, a 2 was rolled, a 3 was rolled, ... a 6 was rolled
                    dieValueCounts[diceValue-1]++;
                    break;
                case '3':
                    // keep track of number of times option selected
                    optionCounts[2]++;

                    // this is just for show
                    Console.SetCursorPosition(5, Console.CursorTop);
                    Animate(new string[] { "/", "--", "\\", "|" }, pause: 200, repeat: 3);
                    Console.SetCursorPosition(0, Console.CursorTop);

                    // ask the computer to simulate rolling a dice by randomly generating either a 0 (we'll call that Heads) or a 1 (we'll call that Tails)
                    int coinValue = random.Next(0, 2);
                    Console.WriteLine($"The coin landed on {coinSides[coinValue]}");

                    // keep count of the number of times a 0 (heads) was generated and the number of times a 1 (tails) was generated
                    coinValueCounts[coinValue]++;
                    break;
                default:
                    Console.WriteLine("Invalid option selected.  Next time, please select one of the available options. ");
                    break;
            }

            return Prompt4YesNo("\nDo you want to go again? ");
        }

        // override the Goodbye method to show stats before exiting
        protected override void Goodbye()
        {
            Console.Clear();
            string newLine = "";

            // before we say goodbye, display the counts
            if (optionCounts[0] > 0)
            {
                string header = $"The user chose option #1 {optionCounts[0]} time(s)";
                Console.WriteLine(header);
                Console.WriteLine("_".PadLeft(header.Length, '_'));
                for(int i =0; i < randomNumberCounts.Length; i++)
                {
                    if(randomNumberCounts[i] > 0)
                    {
                        Console.WriteLine($"\t{i + 1} was the random number {randomNumberCounts[i]} time(s)");
                    }

                }
                newLine = "\n";
            }

            if (optionCounts[1] > 0)
            {
                string header = $"{newLine}The user chose option #2 {optionCounts[1]} time(s)";
                Console.WriteLine(header);
                Console.WriteLine("_".PadLeft(header.Length, '_'));
                for (int i =0; i < dieValueCounts.Length; i++)
                {
                    if(dieValueCounts[i] > 0)
                    {
                        Console.WriteLine($"\t{i + 1} was rolled {dieValueCounts[i]} time(s)");
                    }
                }
                newLine = "\n";
            }

            if (optionCounts[2] > 0)
            {
                string header = $"{newLine}The user chose option #3 {optionCounts[2]} time(s)";
                Console.WriteLine(header);
                Console.WriteLine("_".PadLeft(header.Length, '_'));
                for (int i = 0; i < coinValueCounts.Length; i++)
                {
                    if (coinValueCounts[i] > 0)
                    {
                        Console.WriteLine($"\t{coinSides[i]} was rolled {coinValueCounts[i]} time(s)");
                    }
                }
            }

            Console.Write("\nPress any key to exit.");
            Console.ReadKey();
            Console.Clear();

            // call the base class Goodbye to get the "standard goodbye" message
            base.Goodbye();
        }

        // i have added some functionality to the Animate method in CodeLouisvilleAppBase.  But to keep you
        // from having to download a new version, I am "replacing" your CodeLouisvilleAppBase with the updated
        // version here.  That's what the "new" after private means
        private new static void Animate(string[] parts, int pause = 500, int repeat = 1, bool clearWhenComplete = true, bool slide = false)
        {
            int Left = Console.CursorLeft;
            bool isCursorVisible = Console.CursorVisible;
            Console.CursorVisible = false;
            try
            {
                string prev = "";
                for (int r = 0; r < repeat; r++)
                {
                    for (int i = 0; i < parts.Length; i++)
                    {
                        Console.SetCursorPosition(Console.CursorLeft - prev.Length, Console.CursorTop);
                        if (slide && prev.Length > 0)
                        {
                            Console.Write(" ".PadLeft(prev.Length));
                            Console.SetCursorPosition(Console.CursorLeft + prev.Length, Console.CursorTop);
                        }
                        Console.Write(parts[i].PadRight(prev.Length));
                        prev = parts[i].PadRight(prev.Length);

                        Thread.Sleep(pause);
                    }
                }

                if (clearWhenComplete)
                {
                    Console.SetCursorPosition(Console.CursorLeft - prev.Length, Console.CursorTop);
                    Console.Write(" ".PadLeft(prev.Length));
                    Console.SetCursorPosition(Left, Console.CursorTop);
                }
            }
            finally
            {
                Console.CursorVisible = isCursorVisible;
            }
        }
    }
}
