using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardClasses
{
    abstract class ScoringHand:Hand
    {
        public abstract int GetScore();
    }
}
