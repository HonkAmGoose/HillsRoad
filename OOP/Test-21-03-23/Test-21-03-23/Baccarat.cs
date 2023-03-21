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

        
        
    }
}
