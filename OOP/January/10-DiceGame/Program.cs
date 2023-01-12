using System;

namespace DiceGame
{
    class Program
    {
        static void Main(string[] args)
        {
            Dice myDice = new Dice(6);

            Console.WriteLine("The dice shows: " + myDice.getValue());
            Console.WriteLine("Roll the dice:");
            myDice.Roll();
            Console.WriteLine("The dice shows: " + myDice.getValue());
            Console.WriteLine("Roll the dice:");
            myDice.Roll();
            Console.WriteLine("The dice shows: " + myDice.getValue());
            myDice.value = 3;
            Console.WriteLine("The dice shows: " + myDice.value);
            myDice.sides = 4;
            Console.ReadLine();

        }
    }
}