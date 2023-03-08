namespace Uno
{
    /// <summary>
    /// A static class containing useful helper functions
    /// </summary>
    static class Helpers
    {
        /// <summary>
        /// Method to get a string input
        /// </summary>
        /// <param name="enterPrompt">Prompt for the user</param>
        /// <returns>The string that was input</returns>
        public static string GetStrInput(string enterPrompt)
        {
            Console.WriteLine(enterPrompt);
            return Console.ReadLine();
        }

        /// <summary>
        /// Method to get bounded integer input
        /// </summary>
        /// <param name="enterPrompt">Prompt for the user</param>
        /// <param name="formatErrorPrompt">Prompt if input not integer</param>
        /// <param name="outOfBoundErrorPrompt">Prompt if input not in bounds</param>
        /// <param name="lowerBound">Inclusive lower bound for acceptable input</param>
        /// <param name="upperBound">Inclusive upper bound for acceptable input</param>
        /// <returns>The integer that was input within the specified bounds</returns>
        public static int GetIntInput(string enterPrompt, string formatErrorPrompt, string outOfBoundErrorPrompt, int lowerBound, int upperBound)
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

        /// <summary>
        /// Method to display menu and get an integer response corresponding to the menu index; implements GetIntInput
        /// </summary>
        /// <param name="beforePrompt">User prompt before the menu</param>
        /// <param name="afterPrompt">User prompt after the menu</param>
        /// <param name="formatErrorPrompt">Prompt if input not integer</param>
        /// <param name="outOfBoundErrorPrompt">Prompt if input not in bounds</param>
        /// <param name="options">string[] with options for the menu</param>
        /// <returns>Integer corresponding to the menu index</returns>
        public static int DisplayMenu(string beforePrompt, string afterPrompt, string formatErrorPrompt, string outOfBoundErrorPrompt, string[] options)
        {
            // Variables
            int length = options.Length;

            // Prompt user
            Console.WriteLine(beforePrompt);

            // Output options from array
            for (int i = 0; i < length; i++)
            {
                Console.WriteLine($"\t{i}. {options[i]}");
            }
            Console.WriteLine();

            // Get integer input corresponding to a menu item and return it
            return GetIntInput(afterPrompt, formatErrorPrompt, outOfBoundErrorPrompt, 0, length - 1);
        }

        /// <summary>
        /// Method to ask the user to press enter to do something
        /// </summary>
        /// <param name="to___">What to press enter to do in default colour</param>
        public static void PressEnterTo(string to___)
        {
            Console.Write($"Press enter to {to___}");
            Console.ReadLine();
        }
    }
}
