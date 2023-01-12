using System;

namespace CardGame
{
    public class Card
    {
        public int rank;
        public int suit;

        public Card(int rank, int suit)
        {
            // Ensure acceptable values
            if (rank < 1 | rank > 13)
            {
                throw new FormatException("Rank should be 1-13 inclusive");
            }
            if (suit < 0 | suit > 3)
            {
                throw new FormatException("Suit should be 0-3 inclusive");
            }

            // Set attributes
            this.rank = rank;
            this.suit = suit;
        }

        public int getRank()
        {
            return rank;
        }

        public string getRankString()
        {
            switch (rank)
            {
                case 1: return "ace";
                case 2: return "two";
                case 3: return "three";
                case 4: return "four";
                case 5: return "five";
                case 6: return "six";
                case 7: return "seven";
                case 8: return "eight";
                case 9: return "nine";
                case 10: return "ten";
                case 11: return "jack";
                case 12: return "queen";
                case 13: return "king";
                default: throw new FormatException("Rank should be 1-13 inclusive");
            }    
        }

        public int getSuit()
        {
            return suit;
        }

        public string getSuitString()
        {
            switch (suit)
            {
                case 0: return "clubs";
                case 1: return "diamonds";
                case 2: return "hearts";
                case 3: return "spades";
                default : throw new FormatException("Suit should be 0-3 inclusive");
            }
        }

        public int getScore()
        {
            return (rank * 4 + suit);
        }
    }
}
