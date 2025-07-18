using System;

namespace CardGame
{
    internal class Player
    {
        static Card[] hand;
        private string name;
        private int roundsWon;

        public Player(int handSize, string name)
        {
            hand = new Card[handSize];
            this.name = name;
            SetRounds();
        }

        public void AddToHand(Card card, int index)
        {
            hand[index] = card;
        }

        public int GetScoreFromHand(int index)
        {
            return hand[index].GetScore();
        }

        public string GetCardFromHand(int index)
        {
            return hand[index].ToString();
        }

        public string GetName()
        {
            return name;
        }

        public void GetRounds(int rounds)
        {
            roundsWon = rounds;
        }

        public void SetRounds()
        {
            GetRounds(0);
        }

        public void AddToRounds(int rounds)
        {
            roundsWon += rounds;
        }

        public void AddToRounds()
        {
            AddToRounds(1);
        }

        public int GetRounds()
        {
            return roundsWon;
        }
    }
}
