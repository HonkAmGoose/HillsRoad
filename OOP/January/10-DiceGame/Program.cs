using System;

namespace DiceGame
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create object of class dice with specified number of sides
            Console.WriteLine("Enter the number of sides you would like the dice to have:");
            int sides = Convert.ToInt32(Console.ReadLine());
            Dice myDice = new Dice(sides);

            // Create int[] of length specified
            Console.WriteLine("Enter how many rolls you would like to simulate:");
            int simulations = Convert.ToInt32(Console.ReadLine());
            int[] rolls = new int[simulations];

            // Create dictionary to track frequency of each roll
            Dictionary<int, int> frequency = new Dictionary<int, int>();

            // Loop for number specified and add to array
            for (int i = 0; i < simulations; i++)
            {
                Console.WriteLine($"Roll {i}");
                myDice.Roll();
                rolls[i] = myDice.getValue();
            }
        }
    }
}