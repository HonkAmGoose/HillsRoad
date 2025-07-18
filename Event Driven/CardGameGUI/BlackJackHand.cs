using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardClasses
{
    class BlackJackHand : ScoringHand
    {
        public override int GetScore()
        {
            int score = 0;
            int aces = 0;
            foreach (Card c in cards)
            {
                int cardscore = c.GetRank();
                if (cardscore > 10)
                {
                    cardscore = 10;
                }
                if (cardscore == 1)
                {
                    cardscore = 11;
                    aces++;
                }
                score = score + cardscore;
            }
            while ((score > 21) && (aces > 0))
            {
                score = score - 10;
                aces--;
            }
            return score;

        }
    }
}
