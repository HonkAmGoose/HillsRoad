using System;

namespace CaesarCipher
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Please enter the message you want to encrypt:");
            string message = Console.ReadLine().ToUpper();
            Console.WriteLine("Please enter the key you want to encrypt it with (make it negative to decrypt)");
            int key = Convert.ToInt32(Console.ReadLine()) % 26;
            if (key < 0)
            {
                key += 26;
            }
            string output = "";
            int val;

            foreach(char c in message)
            {
                if (c >= 'A' && c <= 'Z')
                {
                    val = (int)c + key;
                    if (val > 90)
                    {
                        val -= 26;
                    }
                    output += (char)val;
                }
                else
                {
                    output += c;
                }
            }

            Console.WriteLine("Your message is now:\n" + output);
        }
    }
}