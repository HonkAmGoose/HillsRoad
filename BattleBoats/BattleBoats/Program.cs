﻿using System;

namespace BattleBoats
{
    public class Program
    {
        static char[,] PlayerFleetGrid = new char[8,8];
        static char[,] PlayerTargetTracker = new char[8, 8];
        static char[,] ComputerFleetGrid = new char[8, 8];
        static char[,] ComputerTargetTracker = new char[8, 8];

        public static void Main(String[] args)
        {
            // Setting up constants
            string[] menuOptions =
            {
                "Create new game",
                "Resume game from save",
                "Read instructions",
                "Quit game"
            }; // MAKE SURE TO UPDATE SWITCH CASE STATEMENT WHEN UPDATING MENUoPTIONS
            const string WelcomePrompt = "Welcome to this Battle Boats game!";
            const string MenuEnterPrompt = "Please select what you would like to do:";
            const string MenuFormatErrorPrompt = "Sorry, you need to enter an integer";
            const string MenuOutOfBoundErrorPrompt = "Sorry, you need to enter a menu option";
            const string ExitPrompt = "Thank you for playing, come back again soon!\nPress any key to close this window...";

            // Setting up variables
            bool cont = true;

            // Main loop until user wants to quit
            while (cont)
            {
                switch (Menu(WelcomePrompt, MenuEnterPrompt, MenuFormatErrorPrompt, MenuOutOfBoundErrorPrompt, menuOptions))
                {
                    case 1:
                        PlayNewGame();
                        break;

                    case 2:
                        ResumeSavedGame();
                        break;

                    case 3:
                        ReadInstructions();
                        break;

                    case 4:
                        cont = false; // User wants to quit
                        break;

                    default:
                        throw new ArgumentOutOfRangeException("This should be unreachable (GetIntInput() within Menu() should ensure return value is within constraints)");
                }// MAKE SURE TO UPDATE MENUOPTIONS WHEN UPDATING SWITCH CASE STATEMENT
            }
            Console.WriteLine(ExitPrompt);
            Console.ReadKey(); // Wait for user to press a key to exit
        }
        static void OutputGrid(char[,] grid) // Function to output grid in a pretty format
        {
            Console.WriteLine("   | A | B | C | D | E | F | G | H");
            for (int i = 0; i < grid.GetLength(0); i++)
            {
                Console.WriteLine("---+---+---+---+---+---+---+---+---");
                Console.Write($" {i} ");
                for (int j = 0; j < grid.GetLength(1); j++)
                {
                    Console.Write($"| {grid[i, j]} ");
                }
                Console.WriteLine("");
            }
            Console.WriteLine();
        }
        static int ConvertXCoord(char coord) // Function to convert a letter X coordinate to number, throwing FormatException if not between A and H
        {
            if ('A' <= coord && coord <= 'H')
            {
                return (int)coord - 65;
            }
            else
            {
                throw new FormatException("This function only takes in a char between A and H");
            }
        }
        static int[] GetCoordinateInput(string enterPrompt, string formatErrorPrompt, string alreadyExistsErrorPrompt, char[,] toCheck) // Function to get coordinate input between A1 and H8 if not already on grid
        {
            Console.WriteLine(enterPrompt);
            string response;
            int row, col;
            while (true)
            {
                response = Console.ReadLine().ToUpper();
                try
                {
                    if (response.Length != 2)
                    {
                        throw new FormatException();
                    }
                    col = ConvertXCoord(response[0]); // Throws FormatException if not between A and H
                    row = Convert.ToInt32(response[1]); // Throws FormatException if not integer
                }
                catch (FormatException) // Prompt to try again
                {
                    Console.WriteLine(formatErrorPrompt);
                    continue;
                }
                if (col < 1 | col > 8) // Prompt to try again if not within bounds
                {
                    Console.WriteLine(formatErrorPrompt);
                    continue;
                }
                if (toCheck[col,row] != ' ')
                {
                    Console.WriteLine(alreadyExistsErrorPrompt);
                    continue;
                }
                break; // If it makes it to this point, the input is valid so break out of loop
            }
            int[] value = { col, row };
            return value;
        }
        static int GetIntInput(string enterPrompt, string formatErrorPrompt, string outOfBoundErrorPrompt, int lowerBound, int upperBound) // Function to get inclusive bounded integer input
        {
            Console.WriteLine(enterPrompt);
            int response;
            while (true)
            {
                try // Attempt conversion to integer
                {
                    response = Convert.ToInt32(Console.ReadLine());
                }
                catch (FormatException) // If not integer, prompt to try again
                {
                    Console.WriteLine(formatErrorPrompt);
                    continue;
                }
                if (response > upperBound | response < lowerBound) // Check whether it is outside of the bounds, if not, prompt to try again
                {
                    Console.WriteLine(outOfBoundErrorPrompt);
                    continue;
                }
                break; // If it makes it to this point, the input is valid so break out of loop
            }
            Console.WriteLine();
            return response; // Return the integer representation of the input
        }
        static int Menu(string beforePrompt, string afterPrompt, string formatErrorPrompt, string outOfBoundErrorPrompt, string[] options) // Function to display menu and return input using GetIntInput()
        {
            int length = options.Length;
            Console.WriteLine(beforePrompt);
            for (int i = 0; i < length; i++) // Output options from array
            {
                Console.WriteLine($"\t{i + 1}. {options[i]}");
            }
            Console.WriteLine();
            return GetIntInput(afterPrompt, formatErrorPrompt, outOfBoundErrorPrompt, 1, length); // Get integer input corresponding to a menu item and return it
        }
        static void PlayNewGame() // Function to play a completely new game 
        {
            SetupNewGame();
            PlayGame();
        }
        static void SetupNewGame() 
        {
            const string PlaceEnterPrompt = "Please enter the coordinate to place a boat";
            const string CoordinateFormatErrorPrompt = "Sorry, enter a coordinate between A1 and H8";
            const string AlreadyExistsErrorPrompt = "Sorry, a boat already exists at that coordinate";
            List<int[]> allCoords = new List<int[]>();

            // Initialise all char[] to contain spaces and coords to contain each coordinate
            int[] coord = new int[2];
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    PlayerFleetGrid[i, j] = ' ';
                    PlayerTargetTracker[i, j] = ' ';
                    ComputerFleetGrid[i, j] = ' ';
                    ComputerTargetTracker[i, j] = ' ';

                    coord[0] = i;
                    coord[1] = j;
                    allCoords.Append(coord);
                }
            }

            // Get 5 boat spaces for the player
            for (int i = 0; i < 5; i++)
            {
                OutputGrid(PlayerFleetGrid);
                coord = GetCoordinateInput(PlaceEnterPrompt, CoordinateFormatErrorPrompt, AlreadyExistsErrorPrompt, PlayerFleetGrid);
                PlayerFleetGrid[coord[0], coord[1]] = 'B';
            }

            Random rand = new();
            for (int i = 0; i < 5; i++)
            {
                coord = allCoords[rand.Next(allCoords.Count)];
                ComputerFleetGrid[coord[0], coord[1]] = 'B';
                allCoords.Remove(coord);
            }
            // FOR TESTING ONLY, output computer fleet grid
            OutputGrid(ComputerFleetGrid);

            return;
        }
        static void ResumeSavedGame()  // Function to play a game from a save file 
        {
            SetupGameFromFile();
            PlayGame();
        }
        static void SetupGameFromFile() { }
        static void PlayGame() // Function to play the game, taking turns and saving periodically 
        {
            int status = 1; // 1 for keep going, 2 for quit due to user input, 3 for quit due to player win, 4 for quit due to computer win
            while (status == 1)
            {
                PlayerTurn();
                ComputerTurn();
                SaveGameToFile();
                status = CheckForWin();
                if (status == 1) // Most likely status so optimised to keep going and not bother checking status code against other numbers
                {
                    continue; // Next set of turns
                }
                else if (status == 2) // User quit
                {
                    return; // Go back to menu
                }
                else if (status == 3 || status == 4) // Win
                {
                    DisplayEndGame(status); // Pass who won to display the end game screen
                    WipeFile();
                    return; // Go back to menu
                }
                else
                {
                    throw new Exception("This should be unreachable (status should always remain between 1 and 4 inclusive)");
                }
            }
        }
        static void PlayerTurn() { }
        static void ComputerTurn() { }
        static void SaveGameToFile() { }
        static int CheckForWin() { return 1; }
        static void DisplayEndGame(int status) { }
        static void WipeFile() { }
        static void ReadInstructions() { }
    }
}