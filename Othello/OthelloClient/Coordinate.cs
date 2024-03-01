using System;

namespace Othello
{
    /// <summary>
    /// Coordinate class to store locations on the board - enforces maximum values for the size of the board
    /// </summary>
    internal class Coordinate
    {
        public int x;
        public int y;
        public const int maxX = 7; // One less than number of columns - must be strictly less than 26
        public const int maxY = 7; // One less than number of rows - must be strictly less than 26

        /// <summary>
        /// Makes a coordinate from two ints
        /// </summary>
        /// <param name="x">X-coordinate</param>
        /// <param name="y">Y-coordinate</param>
        public Coordinate(int x, int y)
        {
            Construct(x, y);
        }

        /// <summary>
        /// Makes a coordinate from a string representation
        /// </summary>
        /// <param name="coord">String representation in format [1 letter][1-2 numbers]</param>
        /// <exception cref="ArgumentException">If input string is not in correct format</exception>
        public Coordinate(string coord)
        {
            // Format is AD or ADD where A is an alpha and D is a digit
            if ((coord.Length == 2) || (coord.Length == 3  && char.IsNumber(coord[2]))
                && char.IsLetter(coord[0]) 
                && char.IsNumber(coord[1])
                )
            {
                int x = coord[0] - 'A';
                int y = Convert.ToInt32(coord.Substring(1)) - 1;
                Construct(x, y);
            }
            else
            {
                throw new ArgumentException("Should be in format AD or ADD where A is a letter and D is a digit");
            }    
        }

        /// <summary>
        /// Assigns the values based on either of the constructors
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        private void Construct(int x, int y)
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

        /// <summary>
        /// Gets the string representation of the coordinate 
        /// </summary>
        /// <returns>The string representation formatted as [1 letter][1-2 numbers]</returns>
        public override string ToString()
        {
            return $"{char.ConvertFromUtf32('A' + x)}{y + 1}";
        }
    }
}
