namespace CardClasses
{
    class Card
    {
        private int rank;
        // 0 Hearts, 1 Clubs, 2 Diamonds, 3 Spades
        private int suit;
        // 1 Ace (low), (2 Two - 10 Ten), 11 Jack, 12 Queen, 13 King
        
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
              "Jack","Queen", "King" };
            return ranks[rank - 1];
        }

        public string GetSuitAsString()
        {
            string[] suits = { "Hearts", "Clubs", "Diamonds", "Spades" };
            return suits[suit];
        }

        // New functions to get things in different formats ----------------------------------------------------------------------------------------
        public string GetRankAsChar()
        {
            string[] ranks = { "A", "2", "3", "4", "5", "6", "7", "8", "9", "T", "J", "Q", "K" };
            return ranks[rank - 1];
        }

        public string GetSuitAsChar()
        {
            string[] suits = { "♥", "♣", "♦", "♠" };
            return suits[suit];
        }

        public string GetNameAs2Char()
        {
            return GetRankAsChar() + GetSuitAsChar();
        }

        public string GetNameAsVerboseString()
        {
            return GetRankAsString() + " of " + GetSuitAsString();
        }
    }
}
