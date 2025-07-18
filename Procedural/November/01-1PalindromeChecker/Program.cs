namespace PalindromeChecker
{
    internal class Program
    {
        // Main method
        static void Main(string[] args)
        {
            do
            {
                // Get the string to be checked in lowercase with spaces removed
                string toCheck = SafeInput("Enter a string to check if it is a palindrome:").ToLower().Replace(" ", "");
                bool palindrome;

                // Check if it is a palindrome with one of two methods
                if (AskYNQuestion("Would you like to use the check half method (y) or the reverse method (n)?", true))
                {
                    palindrome = IsPalindromeCheckHalf(toCheck);
                }
                else
                {
                    palindrome = IsPalindromeReverse(toCheck);
                }

                // Display result
                if (palindrome)
                {
                    Console.WriteLine("It was a palindrome");
                }
                else
                {
                    Console.WriteLine("It was not a palindrome");
                }
            // Keeps going until the user wants to stop
            } while (AskYNQuestion("Do you want to check another?", true));
        }

        // Checks if a string is a palindrome by going through it and checking the corresponding character
        static bool IsPalindromeCheckHalf (string toCheck) 
        {
            int length = toCheck.Length;

            // Only goes through first half of sequence to compare to last half
            for (int i = 0; i < length / 2; i++) 
            {
                if (toCheck[i] != toCheck[length - i - 1])
                {
                    // If any of them do not match, we know it isn't a palindrome and can return false
                    return false;
                }
            }
            // If it goes through without returning false, we know it must be a palindrome and can return true
            return true; 
        }

        // Checks if a string is a palindrome by reversing it and checking if it is equal to the original
        static bool IsPalindromeReverse (string toCheck)
        {
            int length = toCheck.Length;
            string reversed = string.Empty;

            // Go through string from back to front and append to reversed
            for (int i = length - 1; i >= 0; i--)
            {
                reversed += toCheck[i];
            }

            // Return whether or not it equals the original string
            return reversed.Equals(toCheck);
        }

        // Gets an input after prompting the user
        static string SafeInput(string prompt) 
        {
            Console.WriteLine(prompt);
            string response = Console.ReadLine();

            // If response is null, change it to an empty string
            if (response == null) 
            {
                response = "";
            }
            return response;
        }

        // Asks a yes/no question and returns the input
        static bool AskYNQuestion
            (
            string question, // The string to prompt the user with
            bool defaultYes  // If answer is not Y or N, what to default to
            ) 
        {
            Console.WriteLine(question);
            if (defaultYes)
            {
                Console.Write("Y/n: ");
            }
            else
            {
                Console.Write("y/N: ");
            }
            string response = Console.ReadLine().ToLower();
            if (response.Equals("y"))
            {
                return true;
            }
            else if (response.Equals("n"))
            {
                return false;
            }
            else if (defaultYes)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}