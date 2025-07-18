using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CardClasses;

namespace Baccarat
{
    public class BaccaratHand : ScoringHand
    {
        public override int getScore()
        {
            int score = 0;

            foreach(Card card in cards)
            {
                int rank = card.GetRank();
                if (rank <= 9)
                {
                    score += rank;
                }
            }
            return score % 10;
        }
    }
}
