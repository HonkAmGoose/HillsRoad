using System;
using System.Text;

namespace RLECompression
{
    internal class Program
    {
        static void Main(string[] args)
        {
            do
            {
                bool encodeIfTrue = AskYNQuestion("Do you want to encode (Y) or decode (N) a string?", true);
                if (encodeIfTrue)
                {
                    string toEncode = SafeInput("Enter a string to encode");
                    string encoded = EncodeString(toEncode);
                    Console.WriteLine($"The encoded string is {encoded}");
                }
                else
                {
                    string toDecode = SafeInput("Enter a string to decode");
                    string decoded = DecodeString(toDecode);
                    Console.WriteLine($"The decoded string is {decoded}");
                }
            } while (AskYNQuestion("Do you want to go again?", false));
        }
        static bool AskYNQuestion(string question, bool defaultYes)
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
            string response = Console.ReadLine().ToUpper();
            if (response.Equals("Y"))
            {
                return true;
            }
            else if (response.Equals("N"))
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
        static string SafeInput(string prompt)
        {
            string response;
            Console.WriteLine(prompt);
            response = Console.ReadLine();
            if (response == null)
            {
                response = "";
            }
            return response;
        }
        static string EncodeString (string toEncode)
        {
            string encoded = string.Empty;
            char letter = toEncode[0];
            int number = 1;
            bool reset = true;
            for (int i = 1; i < toEncode.Length; i++)
            {
                
                if (letter == toEncode[i])
                {
                    number++;
                }
                else
                {
                    encoded += number.ToString();
                    encoded += letter;
                    number = 1;
                    letter = toEncode[i];
                    reset = true;
                }
            }
            encoded += number.ToString();
            encoded += letter;
            return encoded;
        }
        static string DecodeString(string toDecode)
        {
            string decoded = string.Empty;
            char letter;
            int number;
            for (int i = 0; i < toDecode.Length; i += 2)
            {
                letter = toDecode[i+1];
                number = Convert.ToInt32(toDecode[i].ToString());
                for (int j = 0; j < number; j++)
                {
                    decoded += letter;
                }
            }
            return decoded;
        }
    }
}