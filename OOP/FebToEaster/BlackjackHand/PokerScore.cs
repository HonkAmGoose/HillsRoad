using System;

namespace HandClasses
{
    internal class PokerScore
    {
        public int Number;
        public int TypeRank;

        /* TypeRank:    description:    Number min - max
         * 
         * 0            high card       2 - 14
         * 1            pair            2 - 14
         * 2            two pair        2 - 14
         * 3            three of a kind 2 - 14
         * 4            straight        
         * 
         */

        public PokerScore(int number, int typeRank)
        {
            Number = number;
            TypeRank = typeRank;
        }

        public PokerScore()
        {
            Number = 0;
            TypeRank = 0;
        }


    }
}
