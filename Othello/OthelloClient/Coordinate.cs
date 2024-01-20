﻿using System;

namespace Othello
{
    /// <summary>
    /// Coordinate class to store locations on the board - enforces maximum values for the size of the board
    /// </summary>
    internal class Coordinate
    {
        public int x;
        public int y;
        public const int maxX = 7;
        public const int maxY = 7;

        public Coordinate(int x, int y)
        {
            if (x >= 0 && x <= maxX && y >= 0 && y <= maxY) // Enforce max size of board
            {
                this.x = x;
                this.y = y;
            }
            else
            {
                throw new ArgumentOutOfRangeException($"x should be >= 0 and <= {maxX} and y should be >= 0 and <= {maxY}");
            }
        }

        public override string ToString()
        {
            return $"({x},{y})";
        }
    }
}