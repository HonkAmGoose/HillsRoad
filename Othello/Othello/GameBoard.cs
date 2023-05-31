using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Othello
{
    internal class GameBoard : Board
    {
        public bool IsMoveProposed { get; protected set; }

        protected Coordinate ProposedMove;

        public GameBoard() : base()
        {
            Setup();
        }

        public GameBoard(char bonusPlayer, int bonusNumber) : base()
        {
            Setup();

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

        private void Setup()
        {
            PlayerTurn = 'B';
            Tiles[3, 3] = new Tile(3, 3, 'B');
            Tiles[4, 4] = new Tile(4, 4, 'B');
            Tiles[3, 4] = new Tile(3, 4, 'W');
            Tiles[4, 3] = new Tile(4, 3, 'W');
        }

        public void Reset()
        {
            for (int x = 0; x <= Coordinate.maxX; x++)
            {
                for (int y = 0; y <= Coordinate.maxY; y++)
                {
                    Tiles[x, y] = new Tile(x, y);
                }
            }
            ValidMoves.Clear();
            TurningTiles.Clear();

            Setup();
        }

        public void Reset(char bonusPlayer, int bonusNumber)
        {
            Reset();

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
            UndisplayTurners();
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

        public void DisplayTurners()
        {
            foreach (Coordinate location in TurningTiles)
            {
                Tiles[location.x, location.y].Status = 'T';
                Tiles[location.x, location.y].CounterColour = PlayerTurn;
            }
        }

        public void UndisplayTurners()
        {
            char otherPlayer = PlayerTurn == 'W' ? 'B' : 'W';
            foreach (Coordinate location in TurningTiles)
            {
                Tiles[location.x, location.y].Status = 'C';
                Tiles[location.x, location.y].CounterColour = otherPlayer;
            }
            TurningTiles.Clear();
        }

        public void ProposeMove(Coordinate location)
        {
            if (SearchValidMoves(location))
            {
                ProposedMove = location;
                Tiles[location.x, location.y].Status = 'P';
                Tiles[location.x, location.y].CounterColour = PlayerTurn;
                IsMoveProposed = true;
                UnhintMoves();
                AssignTurningTiles(location);
                DisplayTurners();
            }
            else
            {
                throw new ArgumentException("Location must be a valid move");
            }
        }

        public void CancelMove()
        {
            Coordinate location = ProposedMove;

            Tiles[location.x, location.y].Status = 'N';
            Tiles[location.x, location.y].CounterColour = 'N';
            IsMoveProposed = false;
            UndisplayTurners();
            TurningTiles.Clear();

            ProposedMove = null;
        }
    }
}
