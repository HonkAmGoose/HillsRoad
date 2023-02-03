using System;
using System.Data;

namespace Connect4
{
    internal class Game
    {
        private readonly int humans;
        private readonly int computers;
        private readonly int rows;
        private readonly int columns;

        private Player[] players;
        public Player[] Players
        {
            get { return players; }
            set { throw new NotSupportedException("public Players cannot be written to"); }
        }

        private Board board;

        private List<ConsoleColor> Colours = new List<ConsoleColor>(new ConsoleColor[] {ConsoleColor.Red, ConsoleColor.Green, ConsoleColor.Blue, ConsoleColor.Cyan, ConsoleColor.Yellow, ConsoleColor.Magenta});
        private List<string> ColourNames = new List<string>(new string[] { "Red", "Green", "Blue", "Cyan", "Yellow", "Magenta" });
        private string[] Names = new string[] { "Sam", "Alex", "Jo", "Dan", }; // TODO: think of more agendered namess

        public Game(int humans, int computers, int rows, int columns)
        {
            this.humans = humans;
            this.computers = computers;
            players = new Player[humans + computers];
            InitPlayers();

            this.rows = rows;
            this.columns = columns;
            board = new Board(rows, columns);
        }

        private void InitPlayers()
        {
            for (int i = 0; i < humans; i++)
            {
                Console.WriteLine($"---- Player {i} ----\n\n");
                int colourInt = Helpers.DisplayMenu("Choose a colour", "Enter your integer choice", "Enter an integer", "Enter an integer within the bounds", ColourNames.ToArray());
                string colourStr = ColourNames[colourInt];
                ConsoleColor colour = Colours[colourInt];
                Console.ForegroundColor = colour;
                string name = Helpers.GetStrInput("Enter your name");

                players[i] = new Player(colour, name, true);
                Colours.RemoveAt(colourInt);
                ColourNames.RemoveAt(colourInt);

                Console.WriteLine($"\n---- Created ----\nColour: {colourStr}\nName: {name}\nPress enter to continue\n");
                Console.ReadLine();
                Console.ResetColor();
                Console.Clear();
            }
            for (int i = 0; i < computers; i++)
            {
                Console.WriteLine($"---- Computer {i + humans} ----\n\n");
                int colour = 0;
                string name = Names[i];
                Console.ForegroundColor = Colours[colour];

                players[i + humans] = new Player(Colours[colour], name, false);

                Console.WriteLine($"---- Created ----\nColour: {ColourNames[colour]}\nName: {name}\nPress enter to continue");
                Console.ReadLine();
                Console.ResetColor();
                Console.Clear();
            }
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
            else
            {
                PlayComputerTurn(player);
            }
        }

        private void PlayHumanTurn(Player player)
        {

        }

        private void PlayComputerTurn(Player computer)
        {

        }
    }
}
