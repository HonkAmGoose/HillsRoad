using System;

namespace CardGame
{
    public class Card
    {
        private int rank;
        private int suit;

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

        public int GetRank()
        {
            // Return the rank as an integer from 1(ace) to 13(king)
            return rank;
        }

        public string GetRankString()
        {
            switch (rank)
            {
                // Return the rank as a string 1:ace, 2:two -> 10:ten, 11:jack, 12:queen, 13:king
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
                default: throw new FormatException("Rank should be 1-13 inclusive"); // Ensure acceptable value
            }    
        }

        public int GetSuit()
        {
            // Return the suit as an integer in alphabetical order 0(clubs) to 3(spades)
            return suit;
        }

        public string GetSuitString()
        {
            // Return the suit as a string 0-clubs, 1-diamonds, 2-hearts, 3-spades
            switch (suit)
            {
                case 0: return "clubs";
                case 1: return "diamonds";
                case 2: return "hearts";
                case 3: return "spades";
                default : throw new FormatException("Suit should be 0-3 inclusive"); // Ensure acceptable value
            }
        }

        public int GetScore()
        {
            // Calculate and return the score as rank * 4 + suit - 3, to create a score from 1 to 52 inclusive
            return (rank * 4 + suit - 3);
        }

        public override string ToString()
        {
            return $"{GetRankString()} of {GetSuitString()}";
        }
    }
}
