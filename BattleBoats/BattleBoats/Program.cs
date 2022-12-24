﻿using System;

namespace BattleBoats
{
    public class Program
    {
        /*  
         *  This program allows you to play the game Battle Boats against a random computer
         *  
         *  Random notes to self for programming:
         *  All global grids are referenced with grid[Y-coord (number), X-coord (letter)]
         *  Statuses are as follows:
         *      1 for keep going
         *      2 for quit due to user input
         *      3 for quit due to player win
         *      4 for quit due to computer win
         */

        //// Global Variables ////
        
        // Grids
        static char[,] PlayerFleetGrid = new char[8,8];
        static char[,] PlayerTargetTracker = new char[8, 8];
        static char[,] ComputerFleetGrid = new char[8, 8];
        static char[,] ComputerTargetTracker = new char[8, 8];
        const string SaveFile = "BattleBoats.save";

        // Hit counters and status
        static int playerHits = 0;
        static int computerHits = 0;
        static int turns = 0;


        //// Main function ////

        public static void Main(String[] args)
        {
            // Setting up constants
            string[] menuOptions =
            {
                "Create new game",
                "Resume game from save",
                "Read instructions",
                "Quit game"
            }; // MAKE SURE TO UPDATE SWITCH CASE STATEMENT WHEN UPDATING MENUOPTIONS
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


        //// Helper functions (used in multiple places) ////

        // Function to output grid in a pretty format
        static void OutputGrid(char[,] grid) 
        {
            // Output column headings
            Console.WriteLine("   | A | B | C | D | E | F | G | H");

            // Iterate through lines in the grid
            for (int i = 0; i < grid.GetLength(0); i++)
            {
                // Output line separator and row heading
                Console.WriteLine("---+---+---+---+---+---+---+---+---");
                Console.Write($" {i+1} ");

                // Iterate through the row and output the values
                for (int j = 0; j < grid.GetLength(1); j++)
                {
                    Console.Write($"| {grid[i, j]} ");
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }

        // Function to convert a letter X coordinate to number, throwing FormatException if not between A and H
        static int ConvertXCoord(char coord) 
        {
            if ('A' <= coord && coord <= 'H')
            {
                // Convert to ASCII and subtract 65 because 'A' has ASCII value 65
                return (int)coord - 65;
            }
            else
            {
                throw new FormatException("This function only takes in a char between A and H");
            }
        }

        // Function to get coordinate input between A1 and H8
        static int[] GetCoordinateInput(string enterPrompt, string formatErrorPrompt) 
        {
            // Variables
            string response;
            int Ynumber, Xletter;

            // Ask for input and get a response
            Console.WriteLine(enterPrompt);
            while (true)
            {
                response = Console.ReadLine().ToUpper();

                // Check for length of 2
                if (response.Length != 2)
                {
                    Console.WriteLine(formatErrorPrompt);
                    continue;
                }

                // Check whether characters are correct type
                try
                {
                    Xletter = ConvertXCoord(response[0]); // Throws FormatException if not between A and H
                    Ynumber = Convert.ToInt32(response[1].ToString()) - 1; // Throws FormatException if not integer
                }
                catch (FormatException) // Prompt to try again
                {
                    Console.WriteLine(formatErrorPrompt);
                    continue;
                }

                // Check if coordinate is within bounds
                if ((Xletter < 0 | Xletter > 7) | (Ynumber < 0 | Ynumber > 7))
                {
                    Console.WriteLine(formatErrorPrompt);
                    continue;
                }

                // If it makes it to this point, the input is valid so break out of loop
                break;
            }

            // Return the valid coordinate
            int[] value = { Ynumber, Xletter };
            return value;
        }

        // Function using GetCoordinateInput, checking against a grid for a blank space
        static int[] GetCheckedCoordinateInput(string enterPrompt, string formatErrorPrompt, string alreadyExistsErrorPrompt, char[,] toCheck)
        {
            // Variables
            int[] coord;

            // Use GetCoordinateInput to do the main checks
            while (true)
            {
                coord = GetCoordinateInput(enterPrompt, formatErrorPrompt);

                // Do additional check for if it already exists
                if (toCheck[coord[0], coord[1]] != ' ')
                {
                    Console.WriteLine(alreadyExistsErrorPrompt);
                    continue;
                }

                // If it makes it to this point, the input is valid so break out of loop
                break;
            }

            // Return the valid coordinate
            return coord;
        }

        // Function to get inclusive bounded integer input
        static int GetIntInput(string enterPrompt, string formatErrorPrompt, string outOfBoundErrorPrompt, int lowerBound, int upperBound) 
        {
            // Variables
            int response;

            // Get input and get a response
            Console.WriteLine(enterPrompt);
            while (true)
            {
                // Attempt conversion to integer
                try
                {
                    response = Convert.ToInt32(Console.ReadLine());
                }

                // If not integer, prompt to try again and restart the loop
                catch (FormatException) 
                {
                    Console.WriteLine(formatErrorPrompt);
                    continue;
                }

                // Check whether it is outside of the bounds, if not, prompt to try again and restart the loop
                if (response > upperBound | response < lowerBound) 
                {
                    Console.WriteLine(outOfBoundErrorPrompt);
                    continue;
                }

                // If it makes it to this point, the input is valid so break out of loop
                break; 
            }

            // Return the integer representation of the input
            Console.WriteLine();
            return response; 
        }


        //// Procedural functions (used once) ////

        // Function to display menu and return input using GetIntInput()
        static int Menu(string beforePrompt, string afterPrompt, string formatErrorPrompt, string outOfBoundErrorPrompt, string[] options) 
        {
            // Variables
            int length = options.Length;

            // Prompt user
            Console.WriteLine(beforePrompt);

            // Output options from array
            for (int i = 0; i < length; i++) 
            {
                Console.WriteLine($"\t{i + 1}. {options[i]}");
            }
            Console.WriteLine();

            // Get integer input corresponding to a menu item and return it
            return GetIntInput(afterPrompt, formatErrorPrompt, outOfBoundErrorPrompt, 1, length); 
        }

        // Function to play a completely new game
        static void PlayNewGame() 
        {
            SetupNewGame();
            PlayGame();
        }
        
        // Function to set up grids with user input and random computer coordinates
        static void SetupNewGame() 
        {
            // Variables
            // FOR TESTING ONLY currently unused, will be used in production
            const string PlaceEnterPrompt = "Please enter the coordinate to place a boat";
            const string CoordinateFormatErrorPrompt = "Sorry, enter a coordinate between A1 and H8";
            const string AlreadyExistsErrorPrompt = "Sorry, a boat already exists at that coordinate";
            const int Xsize = 8;
            const int Ysize = 8;
            const int NumberOfBoats = 5;
            int[] coord = new int[2];

            // Initialise all char[8,8] to contain spaces
            for (int i = 0; i < Ysize; i++)
            {
                for (int j = 0; j < Xsize; j++)
                {
                    PlayerFleetGrid[i, j] = ' ';
                    PlayerTargetTracker[i, j] = ' ';
                    ComputerFleetGrid[i, j] = ' ';
                    ComputerTargetTracker[i, j] = ' ';
                }
            }

            // Initialise other variables
            playerHits = 0;
            computerHits = 0;
            turns = 0;

            // Get 5 boat spaces for the player with input
            for (int i = 0; i < NumberOfBoats; i++)
            {
                // FOR TESTING ONLY, don't bother with prompting for player coords
                //OutputGrid(PlayerFleetGrid);
                //coord = GetCheckedCoordinateInput(PlaceEnterPrompt, CoordinateFormatErrorPrompt, AlreadyExistsErrorPrompt, PlayerFleetGrid);
                //PlayerFleetGrid[coord[0], coord[1]] = 'B';
                PlayerFleetGrid[0, 0] = 'B';
                PlayerFleetGrid[0, 7] = 'B';
                PlayerFleetGrid[7, 0] = 'B';
                PlayerFleetGrid[7, 7] = 'B';
                PlayerFleetGrid[4, 4] = 'B';
            }
            OutputGrid(PlayerFleetGrid);

            // Get 5 random boat spaces for the computer
            int Xletter, Ynumber;
            Random rand = new();
            for (int i = 0; i < NumberOfBoats; i++)
            {
                do
                {
                    Ynumber = rand.Next(Ysize);
                    Xletter = rand.Next(Xsize);
                } while (ComputerFleetGrid[Ynumber, Xletter] != ' ');
                ComputerFleetGrid[Ynumber, Xletter] = 'B';
            }
            // FOR TESTING ONLY, output computer fleet grid
            OutputGrid(ComputerFleetGrid);
        }
        
        
        // Function to play a game, resuming from a file
        static void ResumeSavedGame() 
        {
            // Variables
            const string FileNotFoundError = "No save file exists, please create a new game\n";
            const string FileCorruptError = "The save file seems to be corrupted, please create a new game\n";

            // Try to setup game from file
            try
            {
                SetupGameFromFile();
            }
            catch (FileNotFoundException)
            {
                // Alert user and don't go on to PlayGame() because no game has been initialised
                Console.WriteLine(FileNotFoundError);
                return; 
            }
            catch (EndOfStreamException)
            {
                Console.WriteLine(FileCorruptError);
                WipeFile();
                return;
            }

            PlayGame();
        }

        // Function to setup grids, resuming from a file
        static void SetupGameFromFile()
        {
            // Variables
            const int Xsize = 8;
            const int Ysize = 8;

            // Attempt to read from file (throws FileNotFound if it doesn't exist)
            using (BinaryReader br = new BinaryReader(File.Open(SaveFile, FileMode.Open)))
            {
                // Setup non-grid variables
                playerHits = br.ReadInt32();
                computerHits = br.ReadInt32();
                turns = br.ReadInt32();

                // Iterate through the grids
                for (int i = 0; i < Ysize; i++)
                {
                    for (int j = 0; j < Xsize; j++)
                    {
                        // Read a char for each grid (throws EndOfStream if file too short)
                        PlayerFleetGrid[i, j] = br.ReadChar();
                        PlayerTargetTracker[i, j] = br.ReadChar();
                        ComputerFleetGrid[i, j] = br.ReadChar();
                        ComputerTargetTracker[i, j] = br.ReadChar();
                    }
                }

                // Manually throw EndOfStream if file too long
                if (br.BaseStream.Position < br.BaseStream.Length)
                {
                    throw new EndOfStreamException();
                }
            }
        }


        // Function to play the game, taking turns and saving periodically
        static void PlayGame()  
        {
            // Variables
            const string ContinuePrompt = "Do you want to continue? (Y/n)";
            bool cont = true;

            // Loop until player exit
            while (cont)
            {
                // Take turns and save
                PlayerTurn();
                ComputerTurn();
                turns++;
                SaveGameToFile();

                // Check if either player has won
                if (playerHits == 5)
                {
                    DisplayEndGame(true);
                    WipeFile();
                    cont = false;
                }
                else if (computerHits == 5)
                {
                    DisplayEndGame(false);
                    WipeFile();
                    cont = false;
                }

                // Ask whether to continue
                else
                {
                    Console.WriteLine(ContinuePrompt);
                    if (Console.ReadLine().ToLower() == "n")
                    {
                        cont = false;
                    }
                    Console.WriteLine();
                }
            }
        }
        
        // Function to take a player turn with input coordinates
        static void PlayerTurn()
        {
            // Variables
            const string ShootEnterPrompt = "Please enter the coordinate to shoot at";
            const string CoordinateFormatErrorPrompt = "Sorry, enter a coordinate between A1 and H8";
            const string AlreadyTriedErrorPrompt = "Sorry, you have already tried shooting at that coordinate";
            const string HitMessage = "Boom! You hit an enemy boat and sunk it";
            const string MissMessage = "Splash... You missed";
            int[] coord;

            // Display grid and get coordinate input
            OutputGrid(PlayerTargetTracker);
            coord = GetCheckedCoordinateInput(ShootEnterPrompt, CoordinateFormatErrorPrompt, AlreadyTriedErrorPrompt, PlayerTargetTracker);
            Console.WriteLine();

            // Check hit or miss, update target tracker and hit counter and output to user
            if (ComputerFleetGrid[coord[0], coord[1]] == 'B')
            {
                Console.WriteLine(HitMessage);
                PlayerTargetTracker[coord[0], coord[1]] = 'H';
                playerHits++;
            }
            else if (ComputerFleetGrid[coord[0], coord[1]] == ' ')
            {
                Console.WriteLine(MissMessage);
                PlayerTargetTracker[coord[0], coord[1]] = 'M';
            }
            else
            {
                throw new Exception("Fleet grid should only contain 'B' or ' '");
            }
            Console.WriteLine();
        }
        
        // Function to take a computer turn with random coordinates
        static void ComputerTurn() 
        {
            // Variables
            const string HitMessage = "Boom! One of your boats was hit by the enemy";
            const string MissMessage = "Splash... Your enemy missed";
            int[] coord = new int[2];

            // Get random coordinates that haven't been tried already
            Random rand = new();
            do
            {
                coord[0] = rand.Next(8);
                coord[1] = rand.Next(8);
            } while (ComputerFleetGrid[coord[0], coord[1]] != ' ');

            // Check hit or miss, update target tracker and hit counter and output to user
            if (PlayerFleetGrid[coord[0], coord[1]] == 'B')
            {
                Console.WriteLine(HitMessage);
                ComputerTargetTracker[coord[0], coord[1]] = 'H';
                computerHits++;
            }
            else if (PlayerFleetGrid[coord[0], coord[1]] == ' ')
            {
                Console.WriteLine(MissMessage);
                ComputerTargetTracker[coord[0], coord[1]] = 'M';
            }
            else
            {
                throw new Exception("Fleet grid should only contain 'B' or ' '");
            }
            Console.WriteLine();
        }


        // Function to save the current game to the save file
        static void SaveGameToFile() 
        {
            // Variables
            const int Xsize = 8;
            const int Ysize = 8;

            // Open file in create mode (overwrites if already exists)
            using (BinaryWriter bw = new BinaryWriter(File.Open(SaveFile, FileMode.Create)))
            {
                // Save non-grid variables
                bw.Write(playerHits);
                bw.Write(computerHits);
                bw.Write(turns);

                // Iterate through grid
                for (int i = 0; i < Ysize; i++)
                {
                    for (int j = 0; j < Xsize; j++)
                    {
                        // Write value from each grid
                        bw.Write(PlayerFleetGrid[i,j]);
                        bw.Write(PlayerTargetTracker[i,j]);
                        bw.Write(ComputerFleetGrid[i,j]);
                        bw.Write(ComputerTargetTracker[i,j]);
                    }
                }
            }
        }

        // Function to wipe the save file
        static void WipeFile()
        {
            // Truncates file to 0 bytes and then closes it
            using (File.Open(SaveFile, FileMode.Truncate)) ;
        }

        static void DisplayEndGame(bool playerWon)
        {
            // Variables
            const string PlayerWinMessage = "Well done, you won!";
            const string ComputerWinMessage = "Better luck next time, you lost...";

            // Check who won based on argument and output appropriate message
            if (playerWon)
            {
                Console.WriteLine(PlayerWinMessage);
            }
            else
            {
                Console.WriteLine(ComputerWinMessage);
            }

            // Output statistics
            Console.WriteLine($"You sunk {playerHits} boats and the computer sunk {computerHits} in {turns} turns\n");
        }
        static void ReadInstructions() { }
    }
}