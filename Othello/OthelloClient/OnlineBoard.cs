using System;

namespace Othello
{
    internal class OnlineBoard : Board
    {
        /// <summary>
        /// Creates a board and calls setup
        /// </summary>
        public OnlineBoard() : base()
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
        public OnlineBoard(char bonusPlayer, int bonusNumber) : base()
        {
            Setup();

            if ((bonusPlayer == 'W' || bonusPlayer == 'B') && bonusNumber >= 1 && bonusNumber <= 4) 
            {
                // Adds bonus tiles to correct locations
                for (int i = 0; i < bonusNumber; i++)
                {
                    int x = i % 2 * (Coordinate.maxX - 2) + 1;
                    int y = i / 2 * (Coordinate.maxY - 2) + 1;
                    Tiles[x, y] = new Tile(x, y, bonusPlayer);
                }
            }
            else
            {
                throw new ArgumentException("bonusPlayer must be 'W' or 'B' and bonusNumber >= 1 and <= 4");
            }

            CounterNumbers = new int[] { 2 + bonusNumber * (bonusPlayer == 'B' ? 1 : 0), 2 + bonusNumber * (bonusPlayer == 'W' ? 1 : 0) };
        }

        /// <summary>
        /// Method to setup the beginning pieces in the centre of the board
        /// </summary>
        protected override void Setup()
        {
            PlayerTurn = 'W'; // Will be changed by StartTurn() to black
            Tiles[3, 3] = new Tile(3, 3, 'B');
            Tiles[4, 4] = new Tile(4, 4, 'B');
            Tiles[3, 4] = new Tile(3, 4, 'W');
            Tiles[4, 3] = new Tile(4, 3, 'W');

            Console.WriteLine("Online");
        }

        /// <summary>
        /// Method to reset the board to initial conditions
        /// </summary>
        public override void Reset()
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

        /// <summary>
        /// Method to reset the board to initial conditions with bonus tiles
        /// </summary>
        /// <param name="bonusPlayer">Player to give the bonus</param>
        /// <param name="bonusNumber">Number of bonus tiles</param>
        /// <exception cref="ArgumentException">Thrown when arguments are invalid</exception>
        public override void Reset(char bonusPlayer, int bonusNumber)
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

        /// <summary>
        /// Changes valid moves to 'H'inted status
        /// </summary>
        public override void HintMoves()
        {
            UndisplayTurners();
            foreach (Coordinate location in ValidMoves)
            {
                Tiles[location.x, location.y].Status = 'H';
                Tiles[location.x, location.y].CounterColour = PlayerTurn;
            }
        }

        /// <summary>
        /// Changes valid moves back to 'N'one status
        /// </summary>
        public override void UnhintMoves()
        {
            foreach (Coordinate location in ValidMoves)
            {
                Tiles[location.x, location.y].Status = 'N';
                Tiles[location.x, location.y].CounterColour = 'N';
            }
        }

        /// <summary>
        /// Changes turning tiles to 'T'urning status
        /// </summary>
        protected override void DisplayTurners()
        {
            foreach (Coordinate location in TurningTiles)
            {
                Tiles[location.x, location.y].Status = 'T';
                Tiles[location.x, location.y].CounterColour = PlayerTurn;
            }
        }

        /// <summary>
        /// Changes turning tiles back to 'N'one status
        /// </summary>
        protected override void UndisplayTurners()
        {
            ChangeTurners(PlayerTurn == 'W' ? 'B' : 'W');
        }

        /// <summary>
        /// Turns tiles for the current player
        /// </summary>
        protected override void TurnTurners()
        {
            ChangeTurners(PlayerTurn);
        }

        /// <summary>
        /// Used by UndisplayTurners and TurnTurners to change all turning tiles to a certain player with 'C'onfirmed status
        /// </summary>
        /// <param name="player">Which player to change the TurningTiles to</param>
        public override void ChangeTurners(char player)
        {
            foreach (Coordinate location in TurningTiles)
            {
                Tiles[location.x, location.y].Status = 'C';
                Tiles[location.x, location.y].CounterColour = player;
            }
            TurningTiles.Clear();
        }

        /// <summary>
        /// Change statuses of tiles for proposing a move
        /// </summary>
        /// <param name="location">Proposed location</param>
        /// <exception cref="ArgumentException">If proposed location is not a valid move</exception>
        public override bool ProposeMove(Coordinate location)
        {
            if (SearchValidMoves(location))
            {
                ProposedMove = location;
                IsMoveProposed = true;
                UnhintMoves();
                AssignTurningTiles(location);
                DisplayTurners();
                Tiles[location.x, location.y].Status = 'P';
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
        public override void CancelMove()
        {
            Coordinate location = ProposedMove;

            Tiles[location.x, location.y].Status = 'N';
            Tiles[location.x, location.y].CounterColour = 'N';
            IsMoveProposed = false;
            UndisplayTurners();

            ProposedMove = null;
        }

        /// <summary>
        /// Change statuses of tiles for confirming a proposed move
        /// </summary>
        public override void ConfirmMove()
        {
            Coordinate location = ProposedMove;

            Tiles[location.x, location.y].Status = 'C';
            Tiles[location.x, location.y].CounterColour = PlayerTurn;
            IsMoveProposed = false;
            CounterNumbers[(PlayerTurn == 'B') ? 0 : 1] += TurningTiles.Count + 1;
            CounterNumbers[(PlayerTurn == 'B') ? 1 : 0] -= TurningTiles.Count;
            TurnTurners();

            ProposedMove = null;
        }
    }
}
