using System;

namespace TimesTab
{
    public class Program
    {
        public static void Main(string[] args)
        {
            const string SecretPassword = "Password1";

            int tries = 0;
            bool incorrect = true;

            Console.WriteLine("I am thinking of a (not) VERY secure password. See if you can guess it!");

            do
            {
                Console.Write("Guess:");


                tries++;
            } while (incorrect && tries < 3);
        }
    }
}
