using System;

namespace StringExample
{
    class Program
    {
        static void Main(string[] args)
        {
            string alphabet = string.Empty; // ""
            for(char alpha = 'A'; alpha <= 'Z'; alpha++)
            {
                //alphabet += alpha;
                alphabet = new string(alphabet + alpha);
            }

            Console.WriteLine(alphabet);
        }
    }
}
