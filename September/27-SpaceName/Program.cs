using System;

namespace SpaceName
{
    class Program
    {
        public static string Input(string prompt)
        {
            Console.WriteLine(prompt);
            return Console.ReadLine();
        }
        public static void Main(string[] args)
        {
            string firstName = Input("What is your first name?");
            string lastName = Input("What is your last name?");
            string town = Input("What town were you born in?");
            string month = Input("What month were you born in?");

            Console.WriteLine($"Your space first name is {lastName.Substring(0, 3) + firstName.Substring(0, 2)}");
            Console.WriteLine($"Your space last name is {town.Substring(0, 3) + month.Substring(month.Length - 2, 2)}");
        }
    }
}