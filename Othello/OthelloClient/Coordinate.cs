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
        public const int maxX = 7; // One less than number of columns
        public const int maxY = 7; // One less than number of rows

        public Coordinate(int x, int y)
        {
            Construct(x, y);
        }

        public Coordinate(string coord)
        {
            // Format is AD or ADD where A is an alpha and D is a digit
            if ((coord.Length == 2) || (coord.Length == 3  && char.IsNumber(coord[2]))
                && char.IsLetter(coord[0]) 
                && char.IsNumber(coord[1])
                )
            {
                int x = coord[0] - 'A';
                int y = Convert.ToInt32(coord.Substring(1));
                Construct(x, y);
            }
            else
            {
                throw new ArgumentException("Should be in format AD or ADD where A is a letter and D is a digit");
            }    
        }

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

        public override string ToString()
        {
            return $"{char.ConvertFromUtf32('A' + x)}{y}";
        }
    }
}
