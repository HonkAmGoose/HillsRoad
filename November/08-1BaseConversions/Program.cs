using System;

namespace BaseConversions
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] menuOptions =
                {
                    "Decimal int to binary uint16",
                    "Binary uint16 to decimal int",
                    "Decimal int to twos complement binary int16",
                    "Twos complement binary int16 to decimal int",
                    "Real to binary int16",
                    "Binary int16 to real",
                    "Quit"
                };  // If changed, update switch-case to reflect correct ordering
            
            const string formatErrorDecIntPrompt = "Sorry, must be a decimal integer";
            const string outOfBoundsPrompt = "Sorry, your number is out of bounds";

            // Repeat while user wants to
            bool cont = true;
            while (cont)
            {
                int choice = Menu(
                                    menuOptions,
                                    "Hello, please select the correct function for your needs",
                                    "Enter your choice:",
                                    "Sorry, your choice must be an integer",
                                    "Sorry, your choice must be one on the menu",
                                    "Thank you for choosing"
                                 );
                switch (choice)
                {
                    case 1:
                        Console.WriteLine("Your answer is: " + DecToBin(GetIntInput(
                                "Enter the decimal int representation",
                                formatErrorDecIntPrompt,
                                outOfBoundsPrompt,
                                0,
                                Int32.MaxValue
                            )));
                        break;

                    case 2:
                        Console.WriteLine("Your answer is: " + BinToDec(GetStrInput(
                                "Enter the binary int16 representation"
                            )));
                        break;

                    
                    case 7:
                        // Stop repeating
                        Console.WriteLine("Quitting");
                        cont = false;
                        break;

                    default:
                        // Should be an impossible state to get to
                        throw new Exception("Impossible");
                }
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
        static string GetStrInput(string enterPrompt)
        {
            Console.WriteLine(enterPrompt);
            return Console.ReadLine();
        }
        static int Menu(string[] menuOptions, string firstPrompt, string enterPrompt, string formatErrorPrompt, string outOfBoundErrorPrompt, string thankPrompt)
        {
            Console.WriteLine(firstPrompt);
            for (int i = 0; i < menuOptions.Length; i++)
            {
                Console.WriteLine((i + 1).ToString() + ". " + menuOptions[i]);
            }
            return GetIntInput(enterPrompt, formatErrorPrompt, outOfBoundErrorPrompt, 0, menuOptions.Length);
        }
        static string DecToBin(int dec)
        {
            int bit;
            string bin = "";
            while (dec > 0)
            {
                bit = dec % 2;
                bin = bit.ToString() + bin;
                dec /= 2;
            }
            return bin;
        }
        static int BinToDec(string bin)
        {
            int power = 1;
            int dec = 0;
            for (int i = bin.Length - 1; i >= 0; i--)
            {
                dec = dec + power * Convert.ToInt32(bin[i].ToString());
                power *= 2;
            }
            return dec;
        }
    }
}