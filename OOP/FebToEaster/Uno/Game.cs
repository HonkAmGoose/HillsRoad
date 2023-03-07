using System;
using CardClasses;

namespace Uno
{
    class Game
    {
        int Humans;
        int Computers;

        Player[] Players;

        public Game(int humans, int computers)
        {
            Humans = humans;
            Computers = computers;
            Players = new Player[Humans + Computers];

            for (int i = 0; i < Humans; i++)
            {
                Players[i] = new HumanPlayer();
            }
        }
    }
}
