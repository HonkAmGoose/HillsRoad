using System;

namespace LiarsDice
{
    internal class Hand
    {
        private Die[] dice;
        public Hand(int numberOfDice, int sidesPerDie)
        {
            dice = new Die[numberOfDice];
            for (int i = 0; i < numberOfDice; i++)
            {
                dice[i] = new Die(sidesPerDie);
            }
        }

        public Die[] GetDice()
        {
            return dice;
        }

        public bool PlayerTurn(bid current)
        {
            Console.WriteLine(
                $"The current bid is {current.GetNum()} {current.GetRoll()}s\n" +
                "To make a new bid, type a number and roll separated by a space (both in numerals)\n" +
                "To challenge the current bid, type 'Liar'"
                );
            bidInput = Console.ReadLine();

            if (bidInput.ToLower().Equals("liar"))
            {
                return false;
            }

            
            return true;
        }

        public bool ComputerTurn()
        {
            return true;
        }
    }
}
