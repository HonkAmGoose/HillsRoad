using System;
using System.Diagnostics;
using System.Linq;

namespace Othello
{
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

        public static void MultipleTestRun(Action method)
        {
            long[] times = new long[5];
            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine(times[i] = SingleTestRun(method));
            }
            Console.WriteLine(times.Skip(1).Take(times.Length - 1).Average() + "\n");
        }

        public static long SingleTestRun(Action method)
        {
            Stopwatch watch = Stopwatch.StartNew();
            method();
            watch.Stop();
            return watch.ElapsedMilliseconds;
        }

        public static void NewOne()
        {
            Tile[,] Tiles = new Tile[,]
            {
                { new Tile(0, 0), new Tile(0, 1), new Tile(0, 2), new Tile(0, 3), new Tile(0, 4), new Tile(0, 5), new Tile(0, 6), new Tile(0, 7), },
                { new Tile(1, 0), new Tile(1, 1), new Tile(1, 2), new Tile(1, 3), new Tile(1, 4), new Tile(1, 5), new Tile(1, 6), new Tile(1, 7), },
                { new Tile(2, 0), new Tile(2, 1), new Tile(2, 2), new Tile(2, 3), new Tile(2, 4), new Tile(2, 5), new Tile(2, 6), new Tile(2, 7), },
                { new Tile(3, 0), new Tile(3, 1), new Tile(3, 2), new Tile(3, 3), new Tile(3, 4), new Tile(3, 5), new Tile(3, 6), new Tile(3, 7), },
                { new Tile(4, 0), new Tile(4, 1), new Tile(4, 2), new Tile(4, 3), new Tile(4, 4), new Tile(4, 5), new Tile(4, 6), new Tile(4, 7), },
                { new Tile(5, 0), new Tile(5, 1), new Tile(5, 2), new Tile(5, 3), new Tile(5, 4), new Tile(5, 5), new Tile(5, 6), new Tile(5, 7), },
                { new Tile(6, 0), new Tile(6, 1), new Tile(6, 2), new Tile(6, 3), new Tile(6, 4), new Tile(6, 5), new Tile(6, 6), new Tile(6, 7), },
                { new Tile(7, 0), new Tile(7, 1), new Tile(7, 2), new Tile(7, 3), new Tile(7, 4), new Tile(7, 5), new Tile(7, 6), new Tile(7, 7), },
            };
        }
        public static void OldOne()
        {
            Tile[,] Tiles = new Tile[Coordinate.maxX + 1, Coordinate.maxY + 1];
            for (int x = 0; x <= Coordinate.maxX; x++)
            {
                for (int y = 0; y <= Coordinate.maxY; y++)
                {
                    Tiles[x, y] = new Tile(x, y);
                }
            }
        }
    }
}
