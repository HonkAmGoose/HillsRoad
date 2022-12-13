using System;

namespace BattleBoats
{
    public class Program
    {
        public char[,] PlayerFleetGrid = new char[8,8];
        public char[,] PlayerTargetTracker = new char[8, 8];
        public char[,] ComputerFleetGrid = new char[8, 8];
        public char[,] ComputerTargetTracker = new char[8, 8];

        public void Main(String[] args)
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
            const string EnterPrompt = "Please select what you would like to do:";
            const string FormatErrorPrompt = "Sorry, you need to enter an integer";
            const string OutOfBoundErrorPrompt = "Sorry, you need to enter a menu option";
            const string ExitPrompt = "Thank you for playing, come back again soon!\nPress any key to close this window...";

            // Setting up variables
            bool cont = true;

            // Main loop until user wants to quit
            while (cont)
            {
                switch (Menu(WelcomePrompt, EnterPrompt, FormatErrorPrompt, OutOfBoundErrorPrompt, menuOptions))
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
                        throw new Exception("This should be unreachable (GetIntInput() within Menu() should ensure return value is within constraints)");
                }// MAKE SURE TO UPDATE MENUoPTIONS WHEN UPDATING SWITCH CASE STATEMENT
            }
            Console.WriteLine(ExitPrompt);
            Console.ReadKey(); // Wait for user to press a key to exit
        }
        static void OutputGrid(char[,] grid)
        {
            for (int i = 0; i < grid.GetLength(0); i++)
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