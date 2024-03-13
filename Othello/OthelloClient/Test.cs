using System;
using System.Diagnostics;
using System.Linq;

namespace Othello
{
    /// <summary>
    /// Program to test certain things
    /// </summary>
    internal class Test
    {
        /// <summary>
        /// Testing Main method
        /// </summary>
        /// <param name="args"></param>
        public static void Main(string[] args)
        {
            MultipleTestRun(OldOne);
            MultipleTestRun(NewOne);
            Console.ReadLine();
        }

        /// <summary>
        /// Tests multiple runs of the same method and take an average of all but the first one
        /// </summary>
        /// <param name="method"></param>
        public static void MultipleTestRun(Action method)
        {
            long[] times = new long[5];
            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine(times[i] = SingleTestRun(method));
            }
            Console.WriteLine(times.Skip(1).Take(times.Length - 1).Average() + "\n");
        }

        /// <summary>
        /// Runs a single test and return the time that it took
        /// </summary>
        /// <param name="method"></param>
        /// <returns></returns>
        public static long SingleTestRun(Action method)
        {
            Stopwatch watch = Stopwatch.StartNew();
            method();
            watch.Stop();
            return watch.ElapsedMilliseconds;
        }

        public static void NewOne()
        {
            // Old code to test here
        }
        public static void OldOne()
        {
            // New code to test here
        }
    }
}