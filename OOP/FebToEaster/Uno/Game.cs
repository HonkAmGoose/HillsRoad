using CardClasses;
using PlayerClasses;

namespace Uno
{
    /// <summary>
    /// Class containing everything to play a game of uno
    /// </summary>
    class Game
    {
        /// <summary>
        /// Number of human players in the game
        /// </summary>
        private int humans;

        /// <summary>
        /// Number of computer players in the game
        /// </summary>
        private int computers;

        /// <summary>
        /// Array to store the players in - length is assigned in class constructor
        /// </summary>
        private Player[] players;

        /// <summary>
        /// Pack to store the deal and discard pile
        /// </summary>
        private Pack pack;

        /// <summary>
        /// Class constructor
        /// </summary>
        /// <param name="humans">Number of required human players</param>
        /// <param name="computers">Number of required computer players</param>
        public Game(int humans, int computers)
        {
            this.humans = humans;
            this.computers = computers;
            CreatePlayers();

            ShuffleAndDeal();
        }

        /// <summary>
        /// Method to play the game
        /// </summary>
        public void Play()
        {
            Console.ResetColor();
            Console.Clear();

            Player player;
            int selected;
            Card played;
            string message;

            for (int i = 0; i < players.Length; i++)
            {
                player = players[i];

                Console.ForegroundColor = player.Colour;
                Helpers.PressEnterTo($"take the turn for player {player.ID}: {player.Name}");

                selected = player.TakeTurn(pack.GetTopDiscard());
                if (selected == -1)
                {
                    player.Cards.AddCard(pack.DealCard());
                    message = "had to draw a card";
                }
                else
                {
                    played = player.Cards.RemoveCard(selected);
                    pack.AddCard(played);
                    message = $"played {played.GetNameAs2Char()}";
                }

                Console.ResetColor();
                Console.Clear();

                Console.WriteLine($"Player {player.ID}: {player.Name} {message}");
            }
        }

        /// <summary>
        /// Method to create as many players as needed
        /// </summary>
        private void CreatePlayers()
        {
            players = new Player[humans + computers];

            for (int i = 0; i < humans; i++)
            {
                players[i] = new HumanPlayer();
            }
            for (int i = humans; i < computers; i++)
            {
                players[i] = new ComputerPlayer();
            }
        }

        /// <summary>
        /// Method to create the pack, shuffle and deal
        /// </summary>
        private void ShuffleAndDeal()
        {
            pack = new Pack();
            pack.Shuffle();

            for (int player = 0; player < players.Length; player++)
            {
                for (int i = 0; i < 7; i++)
                {
                    players[player].Cards.AddCard(pack.DealCard());
                }
            }
        }
    }
}
