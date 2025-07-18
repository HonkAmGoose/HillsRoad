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
            // Store properties
            this.humans = humans;
            this.computers = computers;

            // Display welcome and rules if needed
            Helpers.WriteBox("Welcome to this Uno game!");

            int rules = Helpers.
                DisplayMenu
                (
                "Would you like to read the rules?", 
                "Enter the corresponding number", 
                "Enter an integer", 
                "Enter a number in the bounds", 
                new string[] { "Yes", "No" }
                );

            if (rules == 0)
            {
                DisplayRules();
            }

            Console.Clear();
        }

        /// <summary>
        /// Method to setup the game
        /// </summary>
        public void Setup()
        {
            CreatePlayers();
            ShuffleAndDeal();
        }

        /// <summary>
        /// Method to reset the game
        /// </summary>
        public void Reset()
        {
            // Remove cards from players
            for (int i = 0; i < players.Length; i++)
            {
                players[i].Cards.Clear();
            }

            // Recreate pack and deal
            ShuffleAndDeal();
        }

        /// <summary>
        /// Method to play the game
        /// </summary>
        public void Play()
        {
            // Make console empty
            Console.ResetColor();
            Console.Clear();

            // Variables
            Player player;
            List<string> messages = new() {"The game has started"};
            List<string> allMessages = new() { "The game has started" };
            int won = -1;
            bool skip = false;

            // Loop until a player has won
            while (won == -1)
            {
                // Loop through all players
                for (int i = 0; i < players.Length; i++)
                {
                    // If skipping, let next player play
                    if (skip)
                    {
                        skip = false;
                    }
                    // Otherwise, take turn, passing refs for variables
                    else
                    {
                        player = players[i];

                        PlayTurn(player, ref messages, ref allMessages, ref skip);

                        // If won, store in variable and break out of for loop (while loop will break as well)
                        if (player.Cards.IsEmpty())
                        {
                            won = i;
                            break;
                        }
                    }
                }
            }

            // Display nice winning message
            DisplayWinner(won);
        }

        /// <summary>
        /// Method to display rules to the user
        /// </summary>
        private void DisplayRules()
        {
            // Display rules and wait for confirmation
            Console.WriteLine
                    (
                    "Each turn, play a card that matches the rank or suit of the top card on the discard pile.\n" +
                    "If you have no valid cards, you must draw a new card to add to your hand.\n" +
                    "\n" +
                    "If you have one card left, the game will tell other players by adding \"***** UNO *****\" to the end of your turn message.\n" +
                    "The game ends when one player has no cards left.\n" +
                    "Every other player gets a score based on the ranks of the cards left in their hands.\n" +
                    "\n" +
                    "Some cards have special abilities (which score 25 instead of the rank at the end of the game):\n" +
                    "\tKings make the next player pick up two cards\n" +
                    "\tQueens can have their rank changed when they are played\n" +
                    "\tJacks make the next player skip their turn\n" +
                    "\n"
                    );
            Helpers.PressEnterTo("continue");
        }

        /// <summary>
        /// Method to display the winner
        /// </summary>
        /// <param name="winner">The postition in players[] and ID of the winner</param>
        private void DisplayWinner(int winner)
        {
            // Big box to show who won
            Console.ForegroundColor = players[winner].Colour;
            Helpers.WriteBox($"Well done player {players[winner].ID}: {players[winner].Name}. You won!");
            Console.ResetColor();
            Console.WriteLine();

            // Display score for other players
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
        private void PlayTurn(Player player, ref List<string> messages, ref List<string> allMessages, ref bool skip)
        {
            // Display previous turns
            for (int j = 0; j < messages.Count; j++)
            {
                Console.WriteLine(messages[j]);
            }
            Console.WriteLine();

            // Wait for player to make the hand private
            Console.ForegroundColor = player.Colour;
            if (player.IsHuman) Helpers.PressEnterTo($"take the turn for player {player.ID}: {player.Name}");

            // Get the card to be played
            int selected = player.TakeTurn(pack.GetTopDiscard());
            string message = $"Player {player.ID}: {player.Name}";

            // Only remove messages when too long
            if (messages.Count >= players.Length)
            {
                messages.RemoveAt(0);
            }

            // No valid cards in hand
            if (selected == -1)
            {
                player.Cards.AddCard(pack.DealCard());
                message += " had to draw a card. ";
            }
            // Card selected
            else
            {
                Card played = player.Cards[selected];

                // Add to message and deal with special cards
                message += $" played {played.GetNameAs2Char()}. ";
                DealWithSpecials(ref played, ref message, player, ref skip);

                // Play card from hand into the deck
                player.Cards.RemoveCard(selected);
                pack.AddCard(played);

                // Add uno message
                if (player.Cards.IsUno())
                {
                    message += "***** UNO *****";
                }
            }

            // Add message to messages
            messages.Add(message);
            allMessages.Add(message);

            if(player.IsHuman) Helpers.PressEnterTo("finish your turn");

            // Reset console
            Console.ResetColor();
            Console.Clear();
        }

        /// <summary>
        /// Method to deal with special ability cards
        /// </summary>
        /// <param name="played">Reference to the played card</param>
        /// <param name="message">Reference to the current message</param>
        /// <param name="player">Current player taking the turn</param>
        private void DealWithSpecials(ref Card played, ref string message, Player player, ref bool skip)
        {
            // Jack skips next turn
            if (played.GetRank() == 11)
            {
                skip = true;
                message += "The next player's turn was skipped. ";
            }
            // Queen changes suit
            else if (played.GetRank() == 12)
            {
                int suit;
                // Human gets to choose
                if (player.IsHuman)
                {
                    suit = Helpers.DisplayMenu
                        (
                        "You have played a queen, choose a suit to play it as:",
                        "Type in the corresponding number:",
                        "Type in an integer",
                        "Type in a number in range",
                        new string[] { "Hearts", "Clubs", "Diamonds", "Spades" }
                        );
                }
                // Computer is randomly selected
                else
                {
                    Random rnd = new();
                    suit = rnd.Next(4);
                }

                int rank = played.GetRank();

                played = new Card(rank, suit);

                message += $"The suit was changed to {played.GetSuitAsString().ToLower()} so the top card is {played.GetNameAs2Char()}. ";
            }
            // King makes the next player draw two extra cards
            else if (played.GetRank() == 13)
            {
                for (int i = 0; i < 2; i++)
                {
                    players[(player.ID + 1) % players.Length].Cards.AddCard(pack.DealCard());
                }
                message += "The next player had to pick up two cards.";
            }
        }

        /// <summary>
        /// Method to create as many players as needed
        /// </summary>
        private void CreatePlayers()
        {
            // Create array of correct length
            players = new Player[humans + computers];

            // Create human players
            for (int i = 0; i < humans; i++)
            {
                players[i] = new HumanPlayer();
                Console.Clear();
            }
            // Create computer players
            for (int i = humans; i < humans + computers; i++)
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
            // Create pack and shuffle
            pack = new Pack();
            pack.Shuffle();

            // Deal 7 cards to each player
            for (int i = 0; i < players.Length; i++)
            {
                for (int j = 0; j < 7; j++)
                {
                    players[i].Cards.AddCard(pack.DealCard());
                }
            }
        }
    }
}
