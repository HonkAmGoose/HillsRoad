﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Othello
{
    internal class Test
    {
        public static void Main(string[] args)
        {
            GameBoard gb = new GameBoard();
            Console.WriteLine(gb.FindValidMoves());
            foreach(Coordinate c in gb.ValidMoves)
            {
                Console.WriteLine(c.ToString());
            }
        }
    }
}
