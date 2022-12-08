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
            string[] options =
            {
                "Create new game",
                "Resume game from save",
                "Read instructions",
                "Quit game"
            };
            const string WelcomePrompt = "Welcome to this Battle Boats game!";
            const string EnterPrompt = "Please select what you would like to do:";
            const string FormatErrorPrompt = "Sorry, you need to enter an integer";
            const string OutOfBoundErrorPrompt = "Sorry, you need to enter a menu option";
            const string ExitPrompt = "Thank you for playing, come back again soon!\nPress any key to close this window...";

            bool cont = true;
            while (cont)
            {
                switch (Menu(WelcomePrompt, EnterPrompt, FormatErrorPrompt, OutOfBoundErrorPrompt, options))
                {
                    case 1:
                        PlayNewGame();
                        break;

                    case 2:
                        ResumeGame();
                        break;

                    case 3:
                        ReadInstructions();
                        break;

                    case 4:
                        cont = false;
                        break;

                    default:
                        throw new Exception("This should be unreachable (GetIntInput() within Menu() should ensure return value is within constraints)");
                }
            }
            Console.WriteLine(ExitPrompt);
            Console.ReadKey();
        }
        static int GetIntInput(string enterPrompt, string formatErrorPrompt, string outOfBoundErrorPrompt, int lowerBound, int upperBound) // Function to get bounded integer input
        {
            Console.WriteLine(enterPrompt);
            int response;
            while (true)
            {
                try // Check if it is an integer
                {
                    response = Convert.ToInt32(Console.ReadLine());
                }
                catch (FormatException)
                {
                    Console.WriteLine(formatErrorPrompt);
                    continue;
                }
                if (response > upperBound | response < lowerBound) // Check whether it is within the bounds
                {
                    Console.WriteLine(outOfBoundErrorPrompt);
                    continue;
                }
                break;
            }
            Console.WriteLine();
            return response;
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
            return GetIntInput(afterPrompt, formatErrorPrompt, outOfBoundErrorPrompt, 1, length);
        }
        static void PlayNewGame() 
        {
            SetupNewGame();
            PlayGame();
        }
        static void SetupNewGame() { }
        static void ResumeGame()
        {
            SetupGameFromFile();
            PlayGame();
        }
        static void SetupGameFromFile() { }
        static void PlayGame()
        {
            int status = 0; // *0 for no win yet, *1 for player win, *2 for computer win, 0* for keep going, 1* for player quit
            while (status / 10 == 0)
            {
                PlayerTurn();
                ComputerTurn();
                SaveGameToFile();
                status = CheckForWin();
                if (status == 0)
                {

                }
            }
        }
        static void PlayerTurn() { }
        static void ComputerTurn() { }
        static void SaveGameToFile() { }
        static int CheckForWin() { return 0; }
        static void DisplayEndGame() { }
        static void ReadInstructions() { }
    }
}