using System;
using CardClasses;

namespace HandClasses
{
    class BlackjackHand : Hand
    {
        // Uses ace low - rank 1 (rank 14 unused)
        public BlackjackScore GetScore()
        {
            BlackjackScore _return = new BlackjackScore();

            // Special case for blackjack
            if (cards.Count == 2)
            {
                int rank0 = cards[0].GetRank();
                int rank1 = cards[1].GetRank();
                if (
                    (rank0 >= 11 && rank0 <= 13 && rank1 == 1) 
                    |
                    (rank0 == 1 && rank1 >= 11 && rank1 <= 13)
                    )
                {
                    _return.Number = 21;
                    _return.Type = "Blackjack";
                    return _return;
                }
            }

            // Initialise variables
            _return.Number = 0;
            _return.Type = "Hand";
            int aces = 0;

            // Add up card scores
            foreach (Card card in cards)
            {
                // Get rank
                int rank = card.GetRank();

                if (rank >= 2 && rank <= 10)
                {
                    // Number cards have equal value to rank
                    _return.Number += rank;
                }
                else if (rank >= 11 && rank <= 13)
                {
                    // Picture cards score 10
                    _return.Number += 10;
                }
                else if (rank == 1)
                {
                    // Assume aces score 11, will adjust later
                    _return.Number += 11;
                    aces++;
                }
                else
                {
                    // Invalid rank
                    throw new Exception("Must be 1 <= rank <= 13");
                }
            }

            // Adjust for aces if required
            while (_return.Number > 21 && aces > 0)
            {
                _return.Number -= 10;
                aces--;
            }

            // Special case for five card trick
            if (cards.Count >= 5 && _return.Number <= 21)
            {
                _return.Type = "5 Card Trick";
                return _return;
            }

            // Case for gone bust
            if (_return.Number > 21)
            {
                _return.Type = "Bust";
            }

            return _return;
        }
    }
}
