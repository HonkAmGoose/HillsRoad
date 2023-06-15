using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Othello
{
    internal abstract class Board
    {
        public Tile[,] Tiles { get; protected set; }

        public char PlayerTurn { get; protected set; }

        public List<Coordinate> ValidMoves { get; protected set; }
        public List<Coordinate> TurningTiles { get; protected set; }

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

        public bool SearchValidMoves(Coordinate Location)
        {
            foreach(Coordinate c in ValidMoves)
            {
                if (c.x == Location.x && c.y == Location.y)
                {
                    return true;
                }
            }
            return false;
        }

        protected bool IsValidMove(Coordinate proposedLocation)
        {
            char currentPlayer = PlayerTurn;
            char otherPlayer = (PlayerTurn == 'B') ? 'W' : 'B';
            int incrementValue;
            Tile checkingTile;

            for (int xIncrement = -1; xIncrement <= 1; xIncrement++)
            {
                for (int yIncrement = -1; yIncrement <= 1; yIncrement++)
                {
                    if (!(xIncrement == 0 && yIncrement == 0))
                    {
                        incrementValue = 1;
                        while (true)
                        {
                            try
                            {
                                checkingTile = Tiles[proposedLocation.x + (xIncrement * incrementValue), proposedLocation.y + (yIncrement * incrementValue)];
                            }
                            catch (IndexOutOfRangeException)
                            {
                                break;
                            }

                            if (checkingTile.Status != 'C') // There is a gap
                            {
                                break;
                            }
                            else if (checkingTile.CounterColour == otherPlayer) // Tile would turn if sandwiched
                            {
                                incrementValue++;
                            }
                            else if (checkingTile.CounterColour == currentPlayer) // There is a tile to sandwich
                            {
                                if (incrementValue > 1) // There is a sandwich filling
                                {
                                    return true;
                                }
                                else // There is no sandwich filling
                                {
                                    break;
                                }
                            }
                            else
                            {
                                throw new Exception("Invalid tile status");
                            }
                        }
                    }
                }
            }
            return false;
        }

        public void AssignTurningTiles(Coordinate proposedLocation)
        {
            TurningTiles.Clear();
            char currentPlayer = PlayerTurn;
            char otherPlayer = (PlayerTurn == 'B') ? 'W' : 'B';
            int incrementValue;
            Coordinate checkingLocation;
            Tile checkingTile;
            List<Coordinate> singleDirectionTurningTiles = new List<Coordinate>();

            for (int xIncrement = -1; xIncrement <= 1; xIncrement++)
            {
                for (int yIncrement = -1; yIncrement <= 1; yIncrement++)
                {
                    if (xIncrement != 0 || yIncrement != 0)
                    {
                        incrementValue = 1;
                        while (true)
                        {
                            checkingLocation = new Coordinate(proposedLocation.x + (xIncrement * incrementValue), proposedLocation.y + (yIncrement * incrementValue));
                            checkingTile = Tiles[checkingLocation.x, checkingLocation.y];

                            if (checkingTile.Status == 'N') // There is a gap
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
        }
    }
}
