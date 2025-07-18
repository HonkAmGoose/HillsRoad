using System;

namespace Queue
{
    class Program
    {
        static void Main(string[] args)
        {
            var watch = System.Diagnostics.Stopwatch.StartNew();
            WarGame game = new WarGame();
            game.PlayAndDisplay(10000);
            watch.Stop();
            Console.WriteLine($"It took {watch.ElapsedMilliseconds} milliseconds");
        }
    }
}
