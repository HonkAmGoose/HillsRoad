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

            Helpers.WriteBox("Welcome to this Uno game!");

            Helpers.DisplayMenu("Would you like to read the rules?", "Enter the corresponding number", "Enter an integer", "Enter a number in the bounds", new string[] { "Yes", "No" });
        }

        public void Setup()
        {
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
            List<string> messages = new();
            messages.Add("The game has started");
            int won = -1;

            while (won == -1)
            {
                for (int i = 0; i < players.Length; i++)
                {
                    player = players[i];

                    PlayTurn(player, ref messages);

                    if (player.Cards.IsEmpty())
                    {
                        won = i;
                        break;
                    }
                }
            }

            DisplayWinner(won);
        }

        private void DisplayWinner(int winner)
        {
            Console.ForegroundColor = players[winner].Colour;
            Helpers.WriteBox($"Well done player {players[winner].ID}: {players[winner].Name}. You won!");
            Console.ResetColor();
            Console.WriteLine();

            for (int i = 0; i < players.Length; i++)
            {
                if (i != winner)
                {
                    Console.ForegroundColor = players[i].Colour;
                    Console.WriteLine($"Player {players[i].ID}: {players[i].Name} finished with score {players[i].CalculateScore()}");
                    Console.ResetColor();
                }
            }
        }

        /// <summary>
        /// Method to play the turn of a player
        /// </summary>
        /// <param name="player">Player to have their turn played</param>
        /// <param name="messages">Messages of the game so far</param>
        private void PlayTurn(Player player, ref List<string> messages)
        {
            for (int j = 0; j < messages.Count; j++)
            {
                Console.WriteLine(messages[j]);
            }
            Console.WriteLine();

            Console.ForegroundColor = player.Colour;
            Helpers.PressEnterTo($"take the turn for player {player.ID}: {player.Name}");

            int selected = player.TakeTurn(pack.GetTopDiscard());

            if (messages.Count >= players.Length)
            {
                messages.RemoveAt(0);
            }
            if (selected == -1)
            {
                player.Cards.AddCard(pack.DealCard());
                messages.Add($"Player {player.ID}: {player.Name} had to draw a card");
            }
            else
            {
                Card played = player.Cards.RemoveCard(selected);
                pack.AddCard(played);
                messages.Add($"Player {player.ID}: {player.Name} played {played.GetNameAs2Char()}");
            }

            Helpers.PressEnterTo("finish your turn");

            Console.ResetColor();
            Console.Clear();
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
                Console.Clear();
            }
            for (int i = humans; i < computers; i++)
            {
                players[i] = new ComputerPlayer();
                Console.Clear();
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
