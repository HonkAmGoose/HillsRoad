using System;

namespace LiarsDice
{
    internal class Die
    {
        private int value;
        private int sides;
        private Random rnd = new Random();

        public Die(int numberOfSides)
        {
            this.sides = numberOfSides;
        }

        public int Roll()
        {
            value = rnd.Next(sides) + 1;
            return value;
        }
    }
}
