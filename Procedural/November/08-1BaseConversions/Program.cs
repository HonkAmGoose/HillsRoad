using System;

namespace BaseConversions
{
    class Program
    {
        static void testMain(string[] args)
        {
            Console.WriteLine("This is a test");
        }
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
            const string notAllowedBinaryPrompt = "Sorry, your number must only contain 1s and 0s";

            char[] allowedBinary = new char[] { '0', '1' };

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
                        Console.WriteLine("Your answer is: " + BinToDec(GetRestrictedStrInput(
                                "Enter the binary int16 representation",
                                notAllowedBinaryPrompt,
                                allowedBinary
                            )));
                        break;

                    case 3:
                        Console.WriteLine("Your answer is: " + DecToTC(GetIntInput(
                                "Enter the decimal int representation",
                                formatErrorDecIntPrompt,
                                outOfBoundsPrompt,
                                0,
                                Int32.MaxValue
                            )));
                        break;

                    case 4:
                        Console.WriteLine("Your answer is: " + TCToDec(GetRestrictedStrInput(
                                "Enter the twos complement representation",
                                notAllowedBinaryPrompt,
                                allowedBinary
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
        
        static string DecToBin(int dec)
        {
            int bit;
            string bin = "";
            while (dec != 0)
            {
                bit = dec % 2;
                bin = bit.ToString().Replace("-", "") + bin;
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
        static string DecToTC(int dec) //TODO
        {
            string bin = DecToBin(dec);
            return "";
        }
        static int TCToDec(string tc)
        {
            if (tc[0] == '0')
            {
                return BinToDec(tc[1..]);
            }
            else if (tc[0] == '1')
            {
                return (- BinToDec(tc[1..]) - 1);
            }
            else
            {
                throw new Exception("Impossible");
            }
        }

        static string BinaryIncrement(string bin)
        {
            int length = bin.Length;
            for (int i = length - 1; i >= 0; i--)
            {
                if (bin[i] == '0')
                {
                    bin = bin.Substring(0, i) + '1' + bin.Substring(i + 1);
                    break;
                }
                else
                {
                    if (i >= length - 1) // Too high
                    {
                        bin = bin.Substring(0, i) + '0';
                    }
                    else if (i < 1) // Too low
                    {
                        bin = "10" + bin.Substring(i + 1);
                    }
                    else
                    {
                        bin = bin.Substring(0, i) + '0' + bin.Substring(i + 1);
                    }
                }
            }
            return bin;
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
        static string GetRestrictedStrInput(string enterPrompt, string notAllowedPrompt, char[] allowedChars)
        {
            Console.WriteLine(enterPrompt);
            string response = "";
            while (true)
            {
                response = Console.ReadLine();
                foreach (char c in response)
                {
                    if (!allowedChars.Contains(c))
                    {
                        Console.WriteLine(notAllowedPrompt);
                        continue;
                    }
                }
                break;
            }
            return response;
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
    }
}