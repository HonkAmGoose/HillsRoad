using CardClasses;

namespace PlayerClasses
{
    /// <summary>
    /// Abstract class to create different types of player
    /// </summary>
    abstract class Player
    {
        /// <summary>
        /// Static int to keep track of IDs
        /// </summary>
        private static int nextID = 0;
        
        /// <summary>
        /// ID of the current player
        /// </summary>
        public int ID { get; protected set; }

        /// <summary>
        /// Whether the player is human
        /// </summary>
        public bool IsHuman;

        /// <summary>
        /// Public get, protected set access to the player's hand
        /// </summary>
        public Hand Cards { get; protected set; }

        /// <summary>
        /// Colour of this player's text
        /// </summary>
        public ConsoleColor Colour { get; protected set; }

        /// <summary>
        /// Static list of currently unused console colours
        /// </summary>
        protected static List<ConsoleColor> colours = new() { ConsoleColor.Red, ConsoleColor.Green, ConsoleColor.Blue, ConsoleColor.Cyan, ConsoleColor.Yellow, ConsoleColor.Magenta };

        /// <summary>
        /// Name of this player
        /// </summary>
        public string Name { get; protected set; }

        /// <summary>
        /// Static list of currently unused names
        /// </summary>
        protected static List<string> names = new() { "Sam", "Alex", "Jo", "Dan", "Charlie", "Rowan" };
        
        /// <summary>
        /// Constructor
        /// </summary>
        /// <exception cref="Exception"></exception>
        public Player()
        {
            // Check for maximum of 6 players
            if (nextID > 5)
            {
                throw new ArgumentOutOfRangeException("Cannot have more than six players");
            }
            ID = nextID;
            nextID++;

            // Create hands and other properties
            Cards = new Hand();

            Name = ChooseName();
            names.Remove(Name);

            Console.WriteLine();

            Colour = ChooseColour();
            colours.Remove(Colour);
        }

        /// <summary>
        /// Function to take turn
        /// </summary>
        /// <param name="top">Card on the top of the discard pile</param>
        /// <returns>The index of the card in the hand (-1 if has to draw card)</returns>
        public int TakeTurn(Card top)
        {
            // Display information for human players
            if (IsHuman) Console.Write($"\nThe current top card is {top.GetNameAs2Char()}\n\nYour hand consists of: ");

            // Create lists
            List<int> indexes = new List<int>();
            List<string> options = new List<string>();
            for (int i = 0; i < Cards.Size; i++)
            {
                // Display hand to human players
                if (IsHuman) Console.Write(" " + Cards[i].GetNameAs2Char());

                if (
                    top.GetSuit() == Cards[i].GetSuit() // Correct suit
                    ||
                    top.GetRank() == Cards[i].GetRank() // Correct rank
                    ||
                    Cards[i].GetRank() == 12 // Queens can be played whenever
                    )
                {
                    // Add card if valid
                    indexes.Add(i);
                    options.Add(Cards[i].GetNameAs2Char());
                }
            }

            Console.WriteLine("\n");

            // Some amount of valid cards so choose one
            if (options.Count > 0)
            {
                return ChooseCard(indexes.ToArray(), options.ToArray());
            }
            // No valid card so draw a new one
            else
            {
                Console.WriteLine("Your hand doesn't have any valid cards so you have to draw one...\n");
                return -1;
            }
            
        }

        /// <summary>
        /// Calculates the score of the current hand
        /// </summary>
        /// <returns>The score of the hand</returns>
        public int CalculateScore()
        {
            int score = 0;

            for (int i = 0; i < Cards.Size; i++)
            {
                int rank = Cards[i].GetRank();
                if (new int[] {11, 12, 13}.Contains(rank))
                {
                    score += 25;
                }
                else
                {
                    score += rank;
                }
            }

            return score;
        }

        /// <summary>
        /// Function to prompt player for or generate a card to play (used by TakeTurn())
        /// </summary>
        /// <param name="indexes">The indexes of the valid cards</param>
        /// <param name="options">The 2char representations of the valid cards</param>
        /// <returns>The index of the selected card</returns>
        protected abstract int ChooseCard(int[] indexes, string[] options);

        /// <summary>
        /// Function to prompt player for or generate a colour
        /// </summary>
        /// <returns>The ConsoleColor representation of the desired colour</returns>
        protected abstract ConsoleColor ChooseColour();

        /// <summary>
        /// Function to prompt the player for or generate a name
        /// </summary>
        /// <returns>The string representation of the desired name</returns>
        protected abstract string ChooseName();
    }
}
