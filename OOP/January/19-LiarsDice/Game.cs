using System;

namespace LiarsDice
{
    internal class Game
    {
        private Hand[] hands;
        private int numberOfPlayers;
        private int numberOfComputers;
        private int numberOfHands;
        private int dicePerPlayer;
        private int sidesPerDie;
        
        public Game(int numberOfPlayers, int numberOfComputers, int dicePerPlayer, int sidesPerDie)
        {
            if ((numberOfPlayers + numberOfComputers) * dicePerPlayer > 99)
            {
                throw new Exception("Overall number of dice must be strictly less than 100");
            }
            
            this.numberOfPlayers = numberOfPlayers;
            this.numberOfComputers = numberOfComputers;
            this.numberOfHands = numberOfPlayers + numberOfComputers;
            this.dicePerPlayer = dicePerPlayer;
            this.sidesPerDie = sidesPerDie;
            
            hands = new Hand[numberOfHands];
            for (int i = 0; i < numberOfHands; i++)
            {
                hands[i] = new Hand(dicePerPlayer, sidesPerDie);
            }

            foreach(Hand hand in hands)
            {
                foreach(Die die in hand.GetDice())
                {
                    Console.WriteLine(die.GetValue());
                }
            }
        }

        public void Play()
        {
            do
            {
                TakeTurn();
                Console.WriteLine("Play again? (Y/n)");
            } while (Console.ReadLine().ToLower() != "n");
        }

        public void TakeTurn()
        {
            bool changed;
            Bid current = new Bid();
            
            do
            {
                changed = false;
                for (int i = 0; i < numberOfPlayers; i++)
                {
                    changed = hands[i].PlayerTurn(current);
                }
                for (int i = numberOfPlayers; i < numberOfHands; i++)
                {
                    changed = hands[i].ComputerTurn(current);
                }
            } while (changed == true);
        }
    }
}
