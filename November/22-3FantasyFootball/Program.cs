using System.IO;

namespace FantasyFootball
{
    class Program
    {
        static void Main (string[] args)
        {
            const string menuBeforePrompt = "Please choose what you want to do from the following options:";
            const string menuAfterPrompt = "Please enter the number of the option:";
            string[] menuOptions = { "Store new footballer", "View current team", "View team value"};

            switch (Menu(menuBeforePrompt, menuAfterPrompt, menuOptions))
            {
                case 1:
                    break;

                case 2:
                    break;

                case 3:
                    break;

                default:
                    throw new Exception("Impossible");
            }
        }
        static int GetIntInput(string enterPrompt, string formatErrorPrompt, string outOfBoundErrorPrompt, int lowerBound, int upperBound)
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
            return response;
        }
        static int Menu(string beforePrompt, string afterPrompt, string[] options)
        {
            int length = options.Length;
            Console.WriteLine(beforePrompt);
            for (int i = 0; i < length; i++)
            {
                Console.WriteLine($"\t{i+1}. {options[i]}");
            }
            return GetIntInput(afterPrompt, "Invalid", "Invalid", 1, length);
        }
    }
}