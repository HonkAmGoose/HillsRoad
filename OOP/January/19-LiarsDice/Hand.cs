using System;

namespace LiarsDice
{
    internal class Hand
    {
        private Die[] dice;
        public Hand(int numberOfDice, int sidesPerDice)
        {
            dice = new Die[numberOfDice];
            for (int i = 0; i < numberOfDice; i++)
            {
                dice[i] = new Die(sidesPerDice);
            }
        }
    }
}
