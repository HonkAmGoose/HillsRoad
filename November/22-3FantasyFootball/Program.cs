using System.IO;

namespace FantasyFootball
{
    class Program
    {
        static void Main (string[] args)
        {
            const string filename = "playerdb.txt";
            const string menuBeforePrompt = "Please choose what you want to do from the following options:";
            const string menuAfterPrompt = "Please enter the number of the option:";
            string[] menuOptions = { "Store new footballer", "View current team", "View team value", "Quit"};
            bool quit = false;

            while (!quit)
            {
                switch (Menu(menuBeforePrompt, menuAfterPrompt, menuOptions))
                {
                    case 1:
                        StoreNewPlayer(filename);
                        break;

                    case 2:
                        ViewTeam(filename);
                        break;

                    case 3:
                        break;

                    case 4:
                        quit = true;
                        break;
    
                    default:
                        throw new Exception("Impossible");
                }
            }
        }
        static int GetIntInput(string enterPrompt, string formatErrorPrompt, string outOfBoundErrorPrompt, int lowerBound, int upperBound) // Function to get int input
        {
            Console.WriteLine(enterPrompt);
            int response;
            while (true)
            {
                try
                {
                    response = Convert.ToInt32(Console.ReadLine());
                }
                catch (FormatException)
                {
                    Console.WriteLine(formatErrorPrompt);
                    continue;
                }
                if (response > upperBound | response < lowerBound)
                {
                    Console.WriteLine(outOfBoundErrorPrompt);
                    continue;
                }
                break;
            }
            Console.WriteLine();
            return response;
        }
        static int Menu(string beforePrompt, string afterPrompt, string[] options) // Function to display menu and return input using GetIntInput()
        {
            int length = options.Length;
            Console.WriteLine(beforePrompt);
            for (int i = 0; i < length; i++)
            {
                Console.WriteLine($"\t{i+1}. {options[i]}");
            }
            Console.WriteLine();
            return GetIntInput(afterPrompt, "Invalid", "Invalid", 1, length);
        }
        static void StoreNewPlayer(string filename) // Method to store a new player, handling number of players already there
        {
            if (File.Exists(filename) && File.ReadAllLines(filename).Count() >= 25) // File has 5 players so don't add any more
            {
                Console.WriteLine("You already have the maximum of 5 players on your team.\n");
            }
            else // File doesn't exist or has less than 5 players so allow adding another
            {
                Console.WriteLine("Enter the details of the new player:");
                string[] prompts = { "Player name: ", "Goals scored: ", "Yellow cards: ", "Red cards: " };
                using (StreamWriter sw = new StreamWriter(filename, true))
                {
                    foreach (string prompt in prompts) // Iterate through prompts and get input for them
                    {
                        Console.Write("\t" + prompt);
                        sw.WriteLine(prompt + Console.ReadLine());
                    }
                    sw.WriteLine("\n"); // Separate players with new line
                }
                Console.WriteLine();
            }
        }
        static void ViewTeam(string filename) // Method to output the current details of the team, handling an empty file
        {
            Console.WriteLine("Here are the details of your current team:");
            if (File.Exists(filename)) // Check whether the team exists
            {
                using (StreamReader sr = new StreamReader(filename))
                {
                    string line;
                    while ((line = sr.ReadLine()) != null) // Iterate through lines and print them out
                    {
                        Console.WriteLine("\t" + line);
                    }
                }
            }
            else
            {
                Console.WriteLine("Team doesn't currently exist.\n");
            }
        }
        static void CountTeam(string filename) // Method to count the value of the team and output details, handling any number of footballers
        {

        }
    }
}