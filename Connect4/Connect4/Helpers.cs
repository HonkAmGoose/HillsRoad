using System;

namespace Connect4
{
    static class Helpers
    {
        public static string GetStrInput(string enterPrompt)
        {
            Console.WriteLine(enterPrompt);
            return Console.ReadLine();
        }

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
    }
}
