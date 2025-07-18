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
            Randomise();
        }

        public int Roll()
        {
            Randomise();
            return GetValue();
        }
        public void Randomise()
        {
            value = rnd.Next(sides) + 1;
        }
        public int GetValue()
        {
            return value;
        }
    }
}
