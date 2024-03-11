using System;
using System.Collections.Generic;

namespace Othello
{
    /// <summary>
    /// Class to store the board currently in play
    /// </summary>
    internal abstract class Board
    {
        /// <summary>
        /// Array of tiles representing the board
        /// </summary>
        public Tile[,] Tiles { get; protected set; }
        
        /// <summary>
        /// Stores which player's turn it is
        /// </summary>
        public Colour PlayerTurn { get; protected set; }

        /// <summary>
        /// Stores how many counters each player has on the board
        /// </summary>
        public int[] CounterNumbers { get; protected set; }

        /// <summary>
        /// Stores a list of valid moves for the current player
        /// </summary>
        public List<Coordinate> ValidMoves { get; protected set; }

        /// <summary>
        /// Stores a list of tiles that would turn for the currently proposed move
        /// </summary>
        public List<Coordinate> TurningTiles { get; protected set; }

        /// <summary>
        /// Stores whether a move is currently being proposed
        /// </summary>
        public bool IsMoveProposed { get; protected set; }

        /// <summary>
        /// Stores the currently proposed move
        /// </summary>
        public Coordinate ProposedMove { get; protected set; }


        /// <summary>
        /// Creates board with empty tiles
        /// </summary>
        public Board()
        {
            Tiles = new Tile[Coordinate.maxX + 1, Coordinate.maxY + 1];
            for (int x = 0; x <= Coordinate.maxX; x++)
            {
                for (int y = 0; y <= Coordinate.maxY; y++)
                {
                    Tiles[x, y] = new Tile(x, y);
                }
            }
            ValidMoves = new List<Coordinate>();
            TurningTiles = new List<Coordinate>();
        }

        /// <summary>
        /// Changes player and finds valid moves
        /// </summary>
        /// <returns>Whether there are valid moves</returns>
        public bool StartTurn()
        {
            PlayerTurn = PlayerTurn == Colour.White ? Colour.Black : Colour.White;
            return FindValidMoves();
        }

        /// <summary>
        /// Looks for valid moves on the board for the current player
        /// </summary>
        /// <returns>Whether there are any</returns>
        public bool FindValidMoves()
        {
            ValidMoves.Clear();

            Coordinate location;
            for (int x = 0; x <= Coordinate.maxX; x++)
            {
                for (int y = 0; y <= Coordinate.maxY; y++)
                {
                    location = new Coordinate(x, y);
                    if (IsValidMove(location))
                    {
                        ValidMoves.Add(location);
                    }
                }
            }

            if (ValidMoves.Count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        
        /// <summary>
        /// Searches for a location in the list of valid moves - must have run FindValidMoves beforehand
        /// </summary>
        /// <param name="Location">Location to check</param>
        /// <returns>Whether it is a valid move</returns>
        public bool SearchValidMoves(Coordinate Location)
        {
            foreach (Coordinate c in ValidMoves)
            {
                if (c.x == Location.x && c.y == Location.y)
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Used by FindValidMoves to check a single location to see if it is a valid move
        /// </summary>
        /// <param name="proposedLocation">Location to check</param>
        /// <returns>Whether it is a valid move</returns>
        protected bool IsValidMove(Coordinate proposedLocation)
        {
            if (Tiles[proposedLocation.x, proposedLocation.y].CounterStatus != Status.Confirmed)
            {
                Colour currentPlayer = PlayerTurn;
                Colour otherPlayer = (PlayerTurn == Colour.Black) ? Colour.White : Colour.Black;

                for (int xDirection = -1; xDirection <= 1; xDirection++)
                {
                    for (int yDirection = -1; yDirection <= 1; yDirection++)
                    {
                        if (!(xDirection == 0 && yDirection == 0))
                        {
                            if (CheckDirection(proposedLocation, currentPlayer, otherPlayer, xDirection, yDirection)) return true;
                        }
                    }
                }
            }
            return false;
        }

        /// <summary>
        /// Checks a single direction to see if a move could be valid - if xDirection and yDirection are both non-zero, it is a diagonal
        /// </summary>
        /// <param name="proposedLocation">The move location</param>
        /// <param name="currentPlayer">The colour of the current player</param>
        /// <param name="otherPlayer">The colour of the other player</param>
        /// <param name="xDirection">The x direction to go</param>
        /// <param name="yDirection">The y direction to go</param>
        /// <returns>Whether or not the direction contains a valid set of tiles</returns>
        private bool CheckDirection(Coordinate proposedLocation, Colour currentPlayer, Colour otherPlayer, int xDirection, int yDirection)
        {
            int incrementValue = 1;
            Tile checkingTile;

            while (true)
            {
                try
                {
                    checkingTile = Tiles[proposedLocation.x + (xDirection * incrementValue), proposedLocation.y + (yDirection * incrementValue)];
                }
                catch (IndexOutOfRangeException)
                {
                    break;
                }

                if (checkingTile.CounterStatus != Status.Confirmed) // There is a gap
                {
                    break;
                }
                else if (checkingTile.CounterColour == otherPlayer) // Tile would turn if sandwiched
                {
                    incrementValue++;
                }
                else if (checkingTile.CounterColour == currentPlayer && incrementValue > 1) // There is a tile to sandwich and enough filling
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Checks for tiles that turn in a single location and assignes them to TurningTiles
        /// </summary>
        /// <param name="proposedLocation">Location to check</param>
        public void AssignTurningTiles(Coordinate proposedLocation)
        {
            TurningTiles.Clear();
            Colour currentPlayer = PlayerTurn;
            Colour otherPlayer = (PlayerTurn == Colour.Black) ? Colour.White : Colour.Black;

            for (int xDirection = -1; xDirection <= 1; xDirection++)
            {
                for (int yDirection = -1; yDirection <= 1; yDirection++)
                {
                    if (!(xDirection == 0 && yDirection == 0))
                    {
                        AssignDirection(proposedLocation, currentPlayer, otherPlayer, xDirection, yDirection);
                    }
                }
            }
        }

        /// <summary>
        /// Assigns turning tiles in a single direction - if xDirection and yDirection are both non-zero, it is a diagonal
        /// </summary>
        /// <param name="proposedLocation">The move location</param>
        /// <param name="currentPlayer">The colour of the current player</param>
        /// <param name="otherPlayer">The colour of the other player</param>
        /// <param name="xDirection">The x direction to go</param>
        /// <param name="yDirection">The y direction to go</param>
        private void AssignDirection(Coordinate proposedLocation, Colour currentPlayer, Colour otherPlayer, int xDirection, int yDirection)
        {
            int incrementValue;
            Coordinate checkingLocation;
            Tile checkingTile;
            incrementValue = 1;
            List<Coordinate> singleDirectionTurningTiles = new List<Coordinate>();

            while (true)
            {
                try
                {
                    checkingLocation = new Coordinate(proposedLocation.x + (xDirection * incrementValue), proposedLocation.y + (yDirection * incrementValue));
                }
                catch (ArgumentOutOfRangeException)
                {
                    break;
                }
                checkingTile = Tiles[checkingLocation.x, checkingLocation.y];

                if (checkingTile.CounterStatus == Status.None) // There is a gap
                {
                    break;
                }
                else if (checkingTile.CounterColour == otherPlayer) // Tile would turn if sandwiched
                {
                    singleDirectionTurningTiles.Add(checkingLocation);
                    incrementValue++;
                }
                else if (checkingTile.CounterColour == currentPlayer) // There is a tile to sandwich - no need to check for filling because if there is none, then singleDirectionTurningTiles will be empty
                {
                    TurningTiles.AddRange(singleDirectionTurningTiles);
                    break;
                }
            }
        }
    }
}
