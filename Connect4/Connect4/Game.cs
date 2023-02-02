using System;

namespace Connect4
{
    internal class Game
    {
        private readonly int humans;
        private readonly int computers;

        private Player[] players;
        public Player[] Players 
        { 
            get { return players; } 
            set { throw new NotSupportedException("public Players cannot be written to"); } 
        }

        private Board _Board;

        public Game(int humans, int computers)
        {
            this.humans = humans;
            this.computers = computers;
            players = new Player[humans + computers];

            _Board = new Board();
        }

        public void Play()
        {
            for (int i = 0; i < players.Length; i++)
            {
                PlayTurn(players[i]);
            }
        }

        private void PlayTurn(Player player)
        {
            if (player.IsHuman)
            {
                PlayHumanTurn(player);
            }
        }

        private void PlayHumanTurn(Player player)
        {

        }
    }
}
