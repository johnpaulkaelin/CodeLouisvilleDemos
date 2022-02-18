using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace AsyncDemo
{
    class Program
    {
        private static object lockObject = new object();

        static async Task Main(string[] args)
        {
            Console.CursorVisible = false;

            Console.SetCursorPosition(10, 2);
            Console.Write("Press any key to watch me count 1-10 and 10-20 synchronously: ");
            Console.ReadKey();
            Console.Clear();
           
            // call synchronously
            Task1();
            Task2();

            Console.SetCursorPosition(10, 2);
            Console.Write("Press any key to continue: ");
            Console.ReadKey();
            Console.Clear();

            Console.SetCursorPosition(10, 2);
            Console.Write("Press any key to watch me count 1-10 and 10-20 asynchronously using the exact same methods: ");
            Console.ReadKey();
            Console.Clear();

            // now call the same methods asynchronously
            List<Task> tasks = new List<Task>();
            tasks.Add(Task.Run(Task1));
            tasks.Add(Task.Run(Task2));
            Task.WaitAll(tasks.ToArray());

            Console.SetCursorPosition(10, 2);
            Console.Write("Press any key to continue: ");
            Console.ReadKey();
            Console.Clear();

            Console.SetCursorPosition(10, 2);
            Console.Write("Press any key to watch me count 1-10 and 10-20 asynchronously using asynchronous versions of the methods: ");
            Console.ReadKey();
            Console.Clear();

            // now call the asynchronous version of the methods
            Task task1 = Task1Async();
            Task task2 = Task2Async();

            await task1;
            await task2;

            Console.SetCursorPosition(10, 2);
            Console.Write("Press any key to quit: ");
            Console.ReadKey();
            Console.Clear();
        }

        static void Task1()
        {
            for (int i = 1; i <= 10; i++)
            {
                // this lock is needed when running
                // asynchronously because both
                // tasks are competing for the console
                lock (lockObject)
                {
                    Console.SetCursorPosition(10, 5);
                    Console.Write(i);
                }
                Thread.Sleep(500);
            }
        }

        static void Task2()
        {
            for (int i = 11; i <= 20; i++)
            {
                // this lock is needed when running
                // asynchronously because both
                // tasks are competing for the console
                lock (lockObject)
                {
                    Console.SetCursorPosition(10, 7);
                    Console.WriteLine(i);
                }
                Thread.Sleep(500);
            }
        }

        static async Task Task1Async()
        {
            for (int i = 1; i <= 10; i++)
            {
                // this lock is needed when running
                // asynchronously because both
                // tasks are competing for the console
                lock (lockObject)
                {
                    Console.SetCursorPosition(10, 5);
                    Console.Write(i);
                }
                await Task.Delay(500);
            }
        }

        static async Task Task2Async()
        {
            for (int i = 11; i <= 20; i++)
            {
                // this lock is needed when running
                // asynchronously because both
                // tasks are competing for the console
                lock (lockObject)
                {
                    Console.SetCursorPosition(10, 7);
                    Console.WriteLine(i);
                }
                await Task.Delay(500);
            }
        }

    }
}
