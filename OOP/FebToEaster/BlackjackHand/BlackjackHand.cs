using System;
using CardClasses;

namespace BlackjackHand
{
    internal class BlackjackHand : Hand
    {
        public struct Score
        {
            public int number;
            public string type;
        }

        public Score GetScore()
        {
            Score _return = new Score();

            // Special case for blackjack
            if (cards.Count == 2)
            {
                int rank0 = cards[0].GetRank();
                int rank1 = cards[1].GetRank();
                if (
                    (rank0 >= 11 && rank0 <= 13 && rank1 == 1) 
                    ||
                    (rank0 == 0 && rank1 >= 11 && rank1 <= 13)
                    )
                {
                    _return.number = 21;
                    _return.type = "Blackjack";
                    return _return;
                }
            }

            // Initialise variables
            _return.number = 0;
            _return.type = "Hand";
            int aces = 0;

            // Add up card scores
            foreach (Card card in cards)
            {
                // Get rank
                int rank = card.GetRank();

                if (rank >= 2 && rank <= 10)
                {
                    // Number cards have equal value to rank
                    _return.number += rank;
                }
                else if (rank >= 11 && rank <= 13)
                {
                    // Picture cards score 10
                    _return.number += 10;
                }
                else if (rank == 1)
                {
                    // Assume aces score 11, will adjust later
                    _return.number += 11;
                    aces++;
                }
                else
                {
                    // Invalid rank
                    throw new Exception("Must be 1 <= rank <= 13");
                }
            }

            // Adjust for aces if required
            while (_return.number > 21 && aces > 0)
            {
                _return.number -= 10;
                aces--;
            }

            // Special case for five card trick
            if (cards.Count >= 5 && _return.number <= 21)
            {
                _return.type = "5 Card Trick";
                return _return;
            }

            return _return;
        }
    }
}
