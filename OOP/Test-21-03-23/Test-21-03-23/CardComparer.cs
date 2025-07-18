using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardClasses
{
    public class CardComparer : IComparer<Card>
        //compares cards, first by suit: C,D,H,S;  then by rank: 2,3, .., K, A
    {
        public int Compare(Card x, Card y)
        {
            int LR, RR;
            if ((x == null) || (y == null))
            {
                return 0;
            }
            if (x.GetSuit() > y.GetSuit())
            {
                return 1;
            }

            if (x.GetSuit() < y.GetSuit())
            {
                return -1;
            }
            if (x.GetSuit() == y.GetSuit())
            {
                if (x.GetRank() == 1)
                {
                    LR = 14;
                }
                else
                {
                    LR = x.GetRank();
                }
                if (y.GetRank() == 1)
                {
                    RR = 14;
                }
                else
                {
                    RR = y.GetRank();
                }
                if (LR > RR)
                {
                    return 1;
                }
                if (LR < RR)

                {
                    return -1;
                }
                if (LR == RR)
                {
                    return 0;
                }

            }
            return 0;
        }
    }
}
