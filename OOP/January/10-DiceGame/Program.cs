using System;

namespace DiceGame
{
    class Program
    {
        static void Main(string[] args)
        {
            Dice myDice = new Dice(6);

            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine("Rolling the dice...");
                myDice.Roll();
                Console.WriteLine($"The dice shows: {myDice.getValue()}");
            }
        }
    }
}