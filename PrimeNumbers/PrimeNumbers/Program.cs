using System;
using System.Collections.Generic;

namespace PrimeNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int maxNumber = 0;

            while (true)
            {
                Console.Write("Find Prime Numbers <=: ");
                string userInput = Console.ReadLine();
                if (!int.TryParse(userInput, out maxNumber))
                    break;

                DateTime startTime = DateTime.Now;
                int primeNumberCount = 0;

                for (int i = 2; i <= maxNumber; i++)
                {
                    bool bDivisibleByLower = false;
                    int j = 2;
                    while (j < i && !bDivisibleByLower)
                    {
                        bDivisibleByLower = bDivisibleByLower || (i % j == 0);
                        j++;
                    }

                    if (!bDivisibleByLower)
                    {
                        primeNumberCount++;
                        Console.Write($"{i},");
                    }
                }

                Console.WriteLine("\n");

                DateTime endTime = DateTime.Now;

                TimeSpan timeSpent = endTime - startTime;
                Console.WriteLine($"It took {timeSpent.TotalMilliseconds} milliseconds to find {primeNumberCount} prime numbers <= {maxNumber}.");

                Console.WriteLine("\n");
            }
        }
    }
}
