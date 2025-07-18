using System;
using System.Collections.Generic;
using System.Text;

namespace CardClasses
{
    public class Card
    {

        private int rank;
        private int suit;
        
        // constructor
        public Card(int r, int s)
        {
            rank = r;
            suit = s;
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
              "Jack","Queen", "King" };
            return ranks[rank - 1];
        }

        public string GetSuitAsString()
        {
            string[] suits = { "Clubs", "Diamonds", "Hearts", "Spades" };
            return suits[suit];
        }

        public string GetName()
        {
            return GetRankAsString() + " of " + GetSuitAsString();
        }

    }
}
