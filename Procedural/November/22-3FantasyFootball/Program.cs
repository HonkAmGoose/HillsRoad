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
                switch (Menu(menuBeforePrompt, menuAfterPrompt, menuOptions)) // Display menu and get input from user
                {
                    case 1:
                        StoreNewPlayer(filename); // Add a footballer to the team
                        break;

                    case 2:
                        ViewTeam(filename); // Output the current team
                        break;

                    case 3:
                        CountTeam(filename); // Calculate and output the score for the team
                        break;

                    case 4:
                        quit = true; // Quit
                        break;
    
                    default:
                        throw new Exception("Impossible");
                }
            }
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
        static int Menu(string beforePrompt, string afterPrompt, string[] options) // Function to display menu and return input using GetIntInput()
        {
            int length = options.Length;
            Console.WriteLine(beforePrompt);
            for (int i = 0; i < length; i++) // Output options from array
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
                string[] prompts = { "Player name:\t", "Goals scored:\t", "Yellow cards:\t", "Red cards:\t" };
                using (StreamWriter sw = new StreamWriter(filename, true))
                {
                    foreach (string prompt in prompts) // Iterate through prompts and get input for them
                    {
                        Console.Write("\t" + prompt);
                        sw.WriteLine(prompt + Console.ReadLine());
                    }
                    sw.WriteLine(); // Separate players with new line
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
            else // File doesn't exist
            {
                Console.WriteLine("Team doesn't currently exist.\n");
            }
        }
        static void CountTeam(string filename) // Method to count the value of the team and output details, handling any number of footballers
        {
            Console.WriteLine("Here is the score for your current team:");
            if (File.Exists(filename)) // Check whether the team exists
            {
                int total = 0;
                int numberOfPlayers = File.ReadAllLines(filename).Count() / 5; // Each player takes up five lines
                using (StreamReader sr = new StreamReader(filename))
                {
                    int goals, yellows, reds;
                    string[] vals = new string[5];
                    for (int i = 0; i < numberOfPlayers; i++) // Iterate through players
                    {
                        for (int j = 0; j < 4; j++) // Iterate through 4 lines of input
                        {
                            vals[j] = sr.ReadLine().Split("\t")[1].Replace(" ", ""); // Take anything after the tab, removing whitespace
                        }
                        sr.ReadLine(); // Read the separating line
                        goals = Convert.ToInt32(vals[1]);
                        yellows = Convert.ToInt32(vals[2]);
                        reds = Convert.ToInt32(vals[3]);
                        total += ((10 * goals) + (-2 * yellows) + (-5 * reds)); // Calculate score for player and add to total
                    }
                }
                Console.WriteLine(total + "\n"); // Output total
            }
            else // File doesn't exist
            {
                Console.WriteLine("Team doesn't currently exist.\n");
            }
        }
    }
}