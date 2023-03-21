using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardClasses
{
    public class Card
    {
        private int Rank;
        private int Suit;

        public Card(int r, int s)
        {
            Rank = r;
            Suit = s;
        }
        public int GetRank()
        {
            return Rank;
        }
        public int GetSuit()
        {
            return Suit;
        }
        public string GetSuitAsString()
        {
            switch (Suit)
            {
                case 0:
                    return "Clubs";

                case 1:
                    return "Diamonds";

                case 2:
                    return "Hearts";


                case 3:
                    return "Spades";
                default:
                    return "???";

            }
        }
        public string GetRankAsString()
        {
            switch (Rank)
            {

                case 1:
                    return "Ace";

                case 2:
                    return "Two";

                case 3:
                    return "Three";

                case 4:
                    return "Four";

                case 5:
                    return "Five";

                case 6:
                    return "Six";

                case 7:
                    return "Seven";

                case 8:
                    return "Eight";

                case 9:
                    return "Nine";

                case 10:
                    return "Ten";

                case 11:
                    return "Jack";

                case 12:
                    return "Queen";

                case 13:
                    return "King";

                default:
                    return "???";

            }
        }
        public string GetName()
        {
         return GetRankAsString() + " of " + GetSuitAsString();
        }




    }
}

