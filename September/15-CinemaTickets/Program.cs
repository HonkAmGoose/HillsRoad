using System;
using System.Reflection.Metadata.Ecma335;

namespace CinemaTickets
{
    class Program
    {
        static void Main(string[] args)
        {
            // Initialise the variables
            double price = 11.50;
            string ticketType;
            string extras = "None";
            bool member = false;
            bool valid;

            // Ask user for the ticket type
            Console.WriteLine("Enter the ticket type: ");
            ticketType = Console.ReadLine().ToLower();

            // Ask user if the ticket holder is a member
            do
            {
                Console.WriteLine("Is the ticket holder a member? (true or false) ");
                try
                {
                    member = Convert.ToBoolean(Console.ReadLine().ToLower());
                    valid = true;
                }
                catch (FormatException)
                {
                    valid = false;
                }
            }
            while (valid == false);

            // Calculate the price depending on the ticket type and membership
            if (ticketType == "infant")
            {
                // Infants go free
                price = 0.0;
            }
            else if ((ticketType == "student" || ticketType == "senior") && member)
            {
                price *= 0.7;
                extras = "Premier seats, Popcorn";
            }
            else if (ticketType == "student" || ticketType == "senior")
            {
                price *= 0.8;
            }
            else if (member)
            {
                ticketType = "Adult";
                price *= 0.9;
                extras = "Premier seats";
            }
            else
            {
                // Set the ticket type to Adult
                ticketType = "adult";
            }

            // Output the ticket details
            Console.WriteLine("Ticket type: " + ticketType);
            Console.WriteLine("Membership: " + member);
            Console.WriteLine("Ticket cost: £" + Math.Round(price, 2));
            Console.WriteLine("Extras: " + extras);
        }

        /* TASKS:
        1. Add an else if statement that checks if the ticket holder is a member:
            - If they are a member, reduce the ticket price by 10%
            - Assign the string “Premier seats” to the extras variable
        2. Add an else if statement that checks if the ticket type is “Student” or “Senior”:
            - Hint: use two of the pipe symbols || for the Logical OR operator
            - This should reduce the ticket price by 20%
        3. Add a nested if statement to the previous else if statement
            - If the ticket holder is a member as well as a Student or Senior, assign “Popcorn” as an extra  

        Extension: Try to program Task 3 using an Logical AND operator instead of a nested if statement
        */
    }
}
