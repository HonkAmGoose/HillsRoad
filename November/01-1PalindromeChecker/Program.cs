namespace PalindromeChecker
{
    internal class Program
    {
        static void Main(string[] args)
        {
            do
            {
                // Get the string to be checked in lowercase with spaces removed
                string toCheck = SafeInput("Enter a string to check if it is a palindrome:").ToLower().Replace(" ", "");

                // Uses function to check if it is a palindrome
                if (IsPalindrome(toCheck))
                {
                    Console.WriteLine("It was a palindrome");
                }
                else
                {
                    Console.WriteLine("It was not a palindrome");
                }
            } while (AskYNQuestion("Do you want to check another?", true)); // Keeps going until the user wants to stop
        }
        static bool IsPalindrome (string toCheck) // Checks if a string is a palindrome by going through it and checking the corresponding character
        {
            int length = toCheck.Length;
            for (int i = 0; i < length / 2; i++) // Only goes through first half of sequence to compare to last half
            {
                if (toCheck[i] != toCheck[length - i - 1])
                {
                    return false; // If any of them do not match, we know it isn't a palindrome and can return false
                }
            }
            return true; // If it goes through without returning false, we know it must be a palindrome and can return true
        }
        static string SafeInput(string prompt) // Gets an input after prompting the user
        {
            Console.WriteLine(prompt);
            string response = Console.ReadLine();
            if (response == null) // If response is null, change it to an empty string
            {
                response = "";
            }
            return response;
        }
        static bool AskYNQuestion // Asks a yes/no question and returns the input
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