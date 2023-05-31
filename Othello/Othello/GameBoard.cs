﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Othello
{
    internal class GameBoard : Board
    {
        public bool MoveProposed { get; protected set; }

        public GameBoard() : base()
        {
            PlayerTurn = 'B';
            Tiles[3, 3] = new Tile(3, 3, 'B');
            Tiles[4, 4] = new Tile(4, 4, 'B');
            Tiles[3, 4] = new Tile(3, 4, 'W');
            Tiles[4, 3] = new Tile(4, 3, 'W');
        }

        public GameBoard(char bonusPlayer, int bonusNumber) : base()
        {
            PlayerTurn = 'B';
            Tiles[3, 3] = new Tile(3, 3, 'B');
            Tiles[4, 4] = new Tile(4, 4, 'B');
            Tiles[3, 4] = new Tile(3, 4, 'W');
            Tiles[4, 3] = new Tile(4, 3, 'W');

            if ((bonusPlayer == 'W' || bonusPlayer == 'B') && bonusNumber >= 1 && bonusNumber <= 4)
            {
                for (int i = 0; i < bonusNumber; i++)
                {
                    int x = i % 2 * (Coordinate.maxX - 1);
                    int y = i / 2 * (Coordinate.maxY - 1);
                    Tiles[x, y] = new Tile(x, y, bonusPlayer);
                }
            }
            else
            {
                throw new ArgumentException("bonusPlayer must be 'W' or 'B' and bonusNumber >= 1 and <= 4");
            }
        }

        public void HintMoves()
        {
            foreach (Coordinate location in ValidMoves)
            {
                Tiles[location.x, location.y].Status = 'H';
                Tiles[location.x, location.y].CounterColour = PlayerTurn;
            }
        }

        public void UnhintMoves()
        {
            foreach (Coordinate location in ValidMoves)
            {
                Tiles[location.x, location.y].Status = 'N';
                Tiles[location.x, location.y].CounterColour = 'N';
            }
        }

        public void HintTurns()
        {
            foreach (Coordinate location in TurningTiles)
            {
                Tiles[location.x, location.y].Status = 'T';
                Tiles[location.x, location.y].CounterColour = PlayerTurn;
            }
        }

        public void UnhintTurns()
        {
            foreach (Coordinate location in TurningTiles)
            {
                Tiles[location.x, location.y].Status = 'N';
                Tiles[location.x, location.y].CounterColour = 'N';
            }
        }

        public void ProposeMove(Coordinate location)
        {
            if (ValidMoves.Contains(location))
            {
                Tiles[location.x, location.y].Status = 'P';
                Tiles[location.x, location.y].CounterColour = PlayerTurn;
                MoveProposed = true;
                UnhintMoves();
                AssignTurningTiles(location);
                HintTurns();
            }
            else
            {
                throw new ArgumentException("Location must be a valid move");
            }
        }
    }
}