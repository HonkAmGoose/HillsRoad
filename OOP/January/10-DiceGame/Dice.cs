using System;

namespace DiceGame
{
    public class Dice
    {
        public int value;
        public int sides;
        Random rnd = new Random();

        public Dice(int numSides)
        {
            sides = numSides;
        }

        public int getValue()
        {
            return value;
        }

        public void Roll()
        {
            value = rnd.Next(sides) + 1;
        }
    }
}
