using System;
using System.Data;

namespace Connect4
{
    internal class Game
    {
        /// <summary>
        /// The number of human players
        /// </summary>
        private readonly int humans;

        /// <summary>
        /// The number of computer players
        /// </summary>
        private readonly int computers;

        /// <summary>
        /// The privately accessible player array
        /// </summary>
        private Player[] players;

        /// <summary>
        /// The colours of all the players
        /// </summary>
        private ConsoleColor[] ColourArr;

        /// <summary>
        /// The privately accessible board array
        /// </summary>
        private Board board;

        /// <summary>
        /// Constructor for the game to assign values and initialise the players and board
        /// </summary>
        /// <param name="humans">Number of human players</param>
        /// <param name="computers">Number of computer players</param>
        /// <param name="rows">Number of board rows</param>
        /// <param name="columns">Number of board columns</param>
        public Game(int humans, int computers, int rows, int columns)
        {
            // Assign values
            this.humans = humans;
            this.computers = computers;

            // Initialise players
            players = new Player[humans + computers];
            InitPlayers();

            // Initialise board
            board = new Board(rows, columns);
        }

        /// <summary>
        /// Private method to initialise the player array
        /// </summary>
        private void InitPlayers()
        {
            // Variables to store which colours have been used
            List<ConsoleColor> Colours = new List<ConsoleColor>(new ConsoleColor[] { ConsoleColor.Red, ConsoleColor.Green, ConsoleColor.Blue, ConsoleColor.Cyan, ConsoleColor.Yellow, ConsoleColor.Magenta });
            List<string> ColourNames = new List<string>(new string[] { "Red", "Green", "Blue", "Cyan", "Yellow", "Magenta" });
            string[] Names = new string[] { "Sam", "Alex", "Jo", "Dan", "Charlie", "Rowan"};
            int colourInt;
            
            // Iterate through human creation
            for (int i = 0; i < humans; i++)
            {
                Console.WriteLine($"---- Player {i} ----\n\n");
                
                // Get player colour
                colourInt = Helpers.DisplayMenu("Choose a colour", "Enter your integer choice", "Enter an integer", "Enter a number within the bounds", ColourNames.ToArray());
                string colourStr = ColourNames[colourInt];
                ConsoleColor colour = Colours[colourInt];
                Console.ForegroundColor = colour;

                // Get player name
                string name = Helpers.GetStrInput("Enter your name");

                // Create player
                players[i] = new Player(colour, name, true);

                // Remove colour from list
                Colours.RemoveAt(colourInt);
                ColourNames.RemoveAt(colourInt);

                // Confirm player creation
                Console.WriteLine($"\n---- Created ----\nColour: {colourStr}\nName: {name}\n\nPress enter to continue\n");
                Console.ReadLine();
                Console.ResetColor();
                Console.Clear();
            }

            colourInt = 0;
            for (int i = 0; i < computers; i++)
            {
                Console.WriteLine($"---- Computer {i + humans} ----\n\n");

                // Get computer name
                string name = Names[i];

                // Set computer colour
                Console.ForegroundColor = Colours[colourInt];

                // Create computer player
                players[i + humans] = new Player(Colours[colourInt], name, false);

                // Remove colour from list
                Colours.RemoveAt(colourInt);
                ColourNames.RemoveAt(colourInt);

                // Confirm coomputer player creation
                Console.WriteLine($"---- Created ----\nColour: {ColourNames[colourInt]}\nName: {name}\n\nPress enter to continue");
                Console.ReadLine();
                Console.ResetColor();
                Console.Clear();
            }

            // Initialise ColourArr to contain the correct colours
            ColourArr = new ConsoleColor[players.Length];
            for (int i = 0; i < players.Length; i++)
            {
                ColourArr[i] = players[i].Colour;
            }
        }

        /// <summary>
        /// Play the game until won and display end game screen
        /// </summary>
        public void Play()
        {
            int won = -1;
            while (won == -1)
            {
                for (int i = 0; i < players.Length; i++)
                {
                    if (PlayTurn(players[i]))
                    {
                        won = i;
                        break;
                    }
                }
            }

            // TODO: add end game screen
        }

        /// <summary>
        /// Private method to play the turn for a player
        /// </summary>
        /// <param name="player">Instance of player for turn to be played</param>
        /// <returns>Whether the game has been won</returns>
        private bool PlayTurn(Player player)
        {
            board.PrintBoard(ColourArr);

            Console.ForegroundColor = player.Colour;

            int[] coordinate;
            if (player.IsHuman)
            {
                Console.WriteLine($"---- Player {player.Token}: {player.Name} to play ----");
                coordinate = HumanCoordinate(player.Token);
            }
            else
            {
                Console.WriteLine($"---- Computer {player.Token}: {player.Name} to play ----");
                coordinate = ComputerCoordinate(player.Token);
            }
            Console.WriteLine($"Token played in column {coordinate[0]}\n\nPress enter to continue");
            Console.ReadLine();
            Console.ResetColor();
            Console.Clear();

            return board.CheckForWin(coordinate[0], coordinate[1], player.Token);
        }

        /// <summary>
        /// Private method to get coordinate input from human and place on the board
        /// </summary>
        /// <param name="playerToken">Token of player to do this with</param>
        /// <returns>The coordinate the token was placed at</returns>
        private int[] HumanCoordinate(int playerToken)
        {
            int[] coordinate = new int[2];
            do
            {
                // Get column
                coordinate[0] = Helpers.GetIntInput("Enter the column number to place a token", "Enter an integer", "Enter a number between the bounds", 0, board.columns);
                
                // Get row
                coordinate[1] = board.AddToken(coordinate[0], playerToken);
            } while (coordinate[1] == -1); // TODO: tidy this up so reprompts if a column is full

            return coordinate;
        }

        /// <summary>
        /// Private method to generate random coordinate for computer and place on board
        /// </summary>
        /// <param name="playerToken">Token of player to do this for</param>
        /// <returns>The coordinate the token was placed at</returns>
        private int[] ComputerCoordinate(int playerToken)
        {
            // TODO: If I can be bothered later; currently returns invalid coordinates that would cause an error
            return new int[] { -1, -1 };
        }
    }
}
