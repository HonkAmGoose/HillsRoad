using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CardClasses;

namespace Baccarat
{
    public class Baccarat
    {
        private Pack pack;
        private BaccaratHand _PHand;
        private BaccaratHand _BHand;

        private int getPScore()
        {
            return PHand.getScore();
        }

        public int PScore
        {
            get
            {
                return getPScore();
            }
        }
        private int getBScore()
        {
            return BHand.getScore();
        }

        public int BScore
        {
            get
            {
                return getBScore();
            }
        }

        public BaccaratHand PHand
        {
            get
            { return _PHand; }
        }

        public BaccaratHand BHand
        {
            get
            { return _BHand; }
        }
        public Baccarat()
        {
            pack = new Pack();
            _PHand = new BaccaratHand();
            _BHand = new BaccaratHand();
        }

        
        public void Deal()
        {
            pack.Shuffle();
            PHand.AddCard(pack.DealCard());
            PHand.AddCard(pack.DealCard());
            BHand.AddCard(pack.DealCard());
            BHand.AddCard(pack.DealCard());
        }

        
        public bool Natural()
        {
            if (getPScore() == 8 | getPScore() == 9 | getBScore() == 8 | getBScore() == 9)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void Draw()
        {
            if (getPScore() >= 0 && getPScore() <= 5)
            {
                PHand.AddCard(pack.DealCard());

                int drawn = PHand.Last().GetRank();
                int value = 0;

                if (drawn >= 0 && drawn <= 7)
                {
                    value = Convert.ToInt32(Math.Floor(drawn / 2d));
                }
                else if (drawn >= 8 && drawn <= 9)
                {
                    value = Convert.ToInt32(Math.Ceiling((drawn - 10) / 2d));
                }
                else if (drawn >= 10)
                {
                    value = 0;
                }

                value += 3;

                if (BScore <= value)
                {
                    BHand.AddCard(pack.DealCard());
                }
            }
            else if (getBScore() >= 0 && getBScore() <= 5)
            {
                BHand.AddCard(pack.DealCard());
            }
        }
    }
}
