using System;

namespace LiarsDice
{
    internal class Game
    {
        private Hand[] hands;
        public Game(int numberOfHands, int dicePerPlayer, int sidesPerDice)
        {
            hands = new Hand[numberOfHands];
            for (int i = 0; i < numberOfHands; i++)
            {
                hands[i] = new Hand(dicePerPlayer, sidesPerDice);
            }

            foreach(Hand hand in hands)
            {
                foreach(Die die in hand)
                {

                }
            }
        }
    }
}
