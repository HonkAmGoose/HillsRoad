using System;

namespace Othello
{
    internal class GameBoard : Board
    {
        /// <summary>
        /// Creates a board and calls setup
        /// </summary>
        public GameBoard() : base()
        {
            Setup();

            CounterNumbers = new int[] { 2, 2 };
        }

        /// <summary>
        /// Creates a board with bonus tiles and calls setup
        /// </summary>
        /// <param name="bonusPlayer">Player to give the bonus</param>
        /// <param name="bonusNumber">Number of bonus tiles</param>
        /// <exception cref="ArgumentException">Thrown when arguments are invalid</exception>
        public GameBoard(Colour bonusPlayer, int bonusNumber) : base()
        {
            Setup();

            AssignBonuses(bonusPlayer, bonusNumber);

            CounterNumbers = new int[] { 2 + bonusNumber * (bonusPlayer == Colour.Black ? 1 : 0), 2 + bonusNumber * (bonusPlayer == Colour.White ? 1 : 0) };
        }

        /// <summary>
        /// Sets up the beginning pieces in the centre of the board
        /// </summary>
        protected void Setup()
        {
            PlayerTurn = Colour.White; // Will be changed by StartTurn() to black
            Tiles[3, 3] = new Tile(3, 3, Colour.Black);
            Tiles[4, 4] = new Tile(4, 4, Colour.Black);
            Tiles[3, 4] = new Tile(3, 4, Colour.White);
            Tiles[4, 3] = new Tile(4, 3, Colour.White);
        }

        private void AssignBonuses(Colour bonusPlayer, int bonusNumber)
        {
            if (bonusPlayer != Colour.None && bonusNumber >= 1 && bonusNumber <= 4)
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

        /// <summary>
        /// Changes valid moves to hinted status
        /// </summary>
        public  void HintMoves()
        {
            UndisplayTurners();
            foreach (Coordinate location in ValidMoves)
            {
                Tiles[location.x, location.y].CounterStatus = Status.Hinted;
                Tiles[location.x, location.y].CounterColour = PlayerTurn;
            }
        }

        /// <summary>
        /// Changes valid moves back to none status
        /// </summary>
        public void UnhintMoves()
        {
            foreach (Coordinate location in ValidMoves)
            {
                Tiles[location.x, location.y].CounterStatus = Status.None;
                Tiles[location.x, location.y].CounterColour = Colour.None;
            }
        }

        /// <summary>
        /// Changes turning tiles to turning status
        /// </summary>
        protected void DisplayTurners()
        {
            foreach (Coordinate location in TurningTiles)
            {
                Tiles[location.x, location.y].CounterStatus = Status.Turning;
                Tiles[location.x, location.y].CounterColour = PlayerTurn;
            }
        }

        /// <summary>
        /// Changes turning tiles back to none status
        /// </summary>
        protected void UndisplayTurners()
        {
            ChangeTurners(PlayerTurn == Colour.White ? Colour.Black : Colour.White);
        }

        /// <summary>
        /// Turns tiles for the current player
        /// </summary>
        protected void TurnTurners()
        {
            ChangeTurners(PlayerTurn);
        }

        /// <summary>
        /// Used by UndisplayTurners and TurnTurners to change all turning tiles to a certain player with confirmed status
        /// </summary>
        /// <param name="player">Which player to change the TurningTiles to</param>
        public void ChangeTurners(Colour player)
        {
            foreach (Coordinate location in TurningTiles)
            {
                Tiles[location.x, location.y].CounterStatus = Status.Confirmed;
                Tiles[location.x, location.y].CounterColour = player;
            }
            TurningTiles.Clear();
        }

        /// <summary>
        /// Change statuses of tiles for proposing a move
        /// </summary>
        /// <param name="location">Proposed location</param>
        /// <exception cref="ArgumentException">If proposed location is not a valid move</exception>
        public bool ProposeMove(Coordinate location)
        {
            if (SearchValidMoves(location))
            {
                ProposedMove = location;
                IsMoveProposed = true;
                UnhintMoves();
                AssignTurningTiles(location);
                DisplayTurners();
                Tiles[location.x, location.y].CounterStatus = Status.Proposed;
                Tiles[location.x, location.y].CounterColour = PlayerTurn;
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Change statuses of tiles for cancelling a proposed move
        /// </summary>
        public void CancelMove()
        {
            Coordinate location = ProposedMove;

            Tiles[location.x, location.y].CounterStatus = Status.None;
            Tiles[location.x, location.y].CounterColour = Colour.None;
            IsMoveProposed = false;
            UndisplayTurners();

            ProposedMove = null;
        }

        /// <summary>
        /// Change statuses of tiles for confirming a proposed move
        /// </summary>
        public void ConfirmMove()
        {
            Coordinate location = ProposedMove;

            Tiles[location.x, location.y].CounterStatus = Status.Confirmed;
            Tiles[location.x, location.y].CounterColour = PlayerTurn;
            IsMoveProposed = false;
            CounterNumbers[(PlayerTurn == Colour.Black) ? 0 : 1] += TurningTiles.Count + 1;
            CounterNumbers[(PlayerTurn == Colour.Black) ? 1 : 0] -= TurningTiles.Count;
            TurnTurners();

            ProposedMove = null;
        }
    }
}
