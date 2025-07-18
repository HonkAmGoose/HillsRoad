using System;

namespace Connect4
{
    internal class Player
    {
        /// <summary>
        /// The colour to be used when printing text to do with this player
        /// </summary>
        public readonly ConsoleColor Colour;

        /// <summary>
        /// The name of the player to be used when printing text
        /// </summary>
        public readonly string Name;

        /// <summary>
        /// Whether the player is human or not (eg computer)
        /// </summary>
        public readonly bool IsHuman;

        /// <summary>
        /// The token number of the player to be stored in the board array
        /// </summary>
        public readonly int Token;

        /// <summary>
        /// A rolling number to keep track of the number of players
        /// </summary>
        static int NumberOfPlayers = 0;

        /// <summary>
        /// Constructor for the player to assign values
        /// </summary>
        /// <param name="colour">Colour for printing text</param>
        /// <param name="name">Name for printing text</param>
        /// <param name="isHuman">Whether player is human</param>
        public Player(ConsoleColor colour, string name, bool isHuman)
        {
            // Assign values to the instance
            Colour = colour;
            Name = name;
            IsHuman = isHuman;

            // Keep a rolling tally of the player number
            Token = NumberOfPlayers;
            NumberOfPlayers++;
        }
    }
}
