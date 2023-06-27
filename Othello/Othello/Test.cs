using System;

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
            GameBoard gb = new GameBoard();
            Console.WriteLine(gb.FindValidMoves());
            foreach (Coordinate c in gb.ValidMoves)
            {
                Console.WriteLine(c.ToString());
            }
        }
    }
}
