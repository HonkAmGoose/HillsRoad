using System;
using CardClasses;


namespace HandClasses
{
    class TexasHoldemHand : ScoringHand
    {
        // Uses ace high - rank 14 (rank 1 unused)
        public override Score GetScore()
        {
            int cardNo = cards.Count;
            
            int[] ranks = new int[cardNo];
            int[] suits = new int[cardNo];

            int flushSuit = -1;
            int straightHighest = -1;

            for (int i = 0; i < cardNo; i++)
            {
                ranks[i] = cards[i].GetRank();
                suits[i] = cards[i].GetScore();
            }

            for (int i = 0; i < 4; i++)
            {
                if (ranks.Count(s => s == i) >= 5)
                {
                    flushSuit = i;
                }
            }
        }
    }
}
