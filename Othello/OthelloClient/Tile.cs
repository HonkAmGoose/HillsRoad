using System;

namespace Othello
{
    internal class Tile
    {
        public Colour CounterColour = Colour.None;
        public Status CounterStatus = Status.None;
        public Coordinate Location { get; private set; }

        /// <summary>
        /// Creates a blank/empty tile
        /// </summary>
        /// <param name="x">x coordinate</param>
        /// <param name="y">y coordinate</param>
        public Tile(int x, int y)
        {
            Location = new Coordinate(x, y);
        }

        /// <summary>
        /// Creates a tile of a certain colour
        /// </summary>
        /// <param name="x">x coordinate</param>
        /// <param name="y">y coordinate</param>
        /// <param name="player">player colour</param>
        public Tile(int x, int y, Colour player)
        {
            Location = new Coordinate(x, y);
            CounterColour = player;
            CounterStatus = Status.Confirmed;
        }
    }
}
