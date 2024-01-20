﻿using System;

namespace Othello
{
    internal class Tile
    {
        public char CounterColour = 'N'; // 'N'one, 'W'hite or 'B'lack
        public char Status = 'N'; // 'N'one, 'C'onfirmed, 'P'roposed, 'T'urning or 'H'inted
        public Coordinate Location { get; private set; }

        /// <summary>
        /// Used to create blank/empty tiles
        /// </summary>
        /// <param name="x">x coordinate</param>
        /// <param name="y">y coordinate</param>
        public Tile(int x, int y)
        {
            Location = new Coordinate(x, y);
        }

        /// <summary>
        /// Used for tiles that start with a certain colour
        /// </summary>
        /// <param name="x">x coordinate</param>
        /// <param name="y">y coordinate</param>
        /// <param name="player">player colour</param>
        public Tile(int x, int y, char player)
        {
            Location = new Coordinate(x, y);
            CounterColour = player;
            Status = 'C';
        }

        public override string ToString()
        {
            return $"{Location}, C:{CounterColour}, S:{Status}";
        }
    }
}