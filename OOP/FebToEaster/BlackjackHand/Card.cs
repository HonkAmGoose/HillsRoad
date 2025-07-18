using System;

namespace CardClasses
{
    public class Card
    {

        private int rank;
        // 0 Hearts, 1 Clubs, 2 Diamonds, 3 Spades
        private int suit;
        // 1 Ace (low), (2 Two - 10 Ten), 11 Jack, 12 Queen, 13 King, 14 Ace (high)
        
        // constructor
        public Card(int rank, int suit)
        {
            this.rank = rank;
            this.suit = suit;
        }

        public int GetRank()
        {
            return rank;
        }

        public int GetSuit()
        {
            return suit;
        }

        public int GetScore()
        {
            int score = rank * 4 + suit;
            return score;
        }

        public string GetRankAsString()
        {
            string[] ranks = { "Ace", "Two", "Three", "Four", "Five",
              "Six","Seven", "Eight", "Nine", "Ten",
              "Jack","Queen", "King", "Ace" };
            return ranks[rank - 1];
        }

        public string GetSuitAsString()
        {
            string[] suits = { "Hearts", "Clubs", "Diamonds", "Spades" };
            return suits[suit];
        }

        public string GetName()
        {
            return GetRankAsString() + " of " + GetSuitAsString();
        }

    }
}
