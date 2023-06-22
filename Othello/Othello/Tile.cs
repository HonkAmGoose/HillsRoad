using System;

namespace Othello
{
    internal class Tile
    {
        public char CounterColour = 'N';
        public char Status = 'N';
        public Coordinate Location { get; private set; }

        public Tile(Coordinate location)
        {
            Location = location;
        }

        public Tile(Coordinate location, char player)
        {
            Location = location;
            CounterColour = player;
            Status = 'C';
        }

        public Tile(int x, int y)
        {
            Location = new Coordinate(x, y);
        }

        public Tile(int x, int y, char player)
        {
            Location = new Coordinate(x, y);
            CounterColour = player;
            Status = 'C';
        }

        public void Place(char player)
        {
            if (player == 'W' || player == 'B')
            {
                CounterColour = player;
                Status = 'P';
            }
            else
            {
                throw new ArgumentException("Player must be 'W' or 'B'");
            }
        }

        public void Turn()
        {
            if (CounterColour == 'N')
            {
                throw new Exception("Counter not placed");
            }
            else
            {
                if (CounterColour == 'W')
                {
                    CounterColour = 'B';
                }
                else if (CounterColour == 'B')
                {
                    CounterColour = 'W';
                }
                else
                {
                    throw new Exception("Invalid counter colour");
                }
            }
        }

        public void Confirm()
        {
            if (Status == 'T' || Status == 'P')
            {
                Status = 'C';
            }
            else
            {
                throw new Exception("Invalid status for confirmation");
            }
        }

        public void Cancel()
        {
            if (Status == 'T' || Status == 'P')
            {
                CounterColour = 'N';
                Status = 'N';
            }
            else
            {
                throw new Exception("Invalid status for cancellation");
            }
        }

        public override string ToString()
        {
            return $"{Location}, C:{CounterColour}, S:{Status}";
        }
    }
}
