using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Baccarat
{
    public class BaccaratGameUI
    {
        public void Display(Baccarat game)
        // displays players' hands and scores
        {
            Console.WriteLine("Player's cards: ");
            for (int i = 0; i < game.PHand.Size; i++)
            {
                Console.WriteLine(game.PHand[i].GetRankAsString() + " of "
                    + game.PHand[i].GetSuitAsString());
            }
                Console.WriteLine();
                Console.WriteLine("Banker's cards: ");
            for (int i = 0; i < game.BHand.Size; i++)
            {
                Console.WriteLine(game.BHand[i].GetRankAsString() + " of "
                    + game.BHand[i].GetSuitAsString());
            }
            Console.WriteLine();
            Console.WriteLine("Player's score: " + game.PScore);
            Console.WriteLine("Banker's score: " + game.BScore);
            Console.WriteLine();
        }

        public void DisplayDraw(Baccarat game)
        // displays outcome of draw phase of game
        {
            if (game.PHand.Size == 2)
            {
                Console.WriteLine("The player has stood");
            }
            if (game.PHand.Size == 3)
            {
                Console.WriteLine("The player has drawn the " + game.PHand[2].GetRankAsString()
                    + " of " + game.PHand[2].GetSuitAsString());
            }
            if (game.BHand.Size == 2)
            {
                Console.WriteLine("The banker has stood");
            }
            if (game.BHand.Size == 3)
            {
                Console.WriteLine("The banker has drawn the " + game.BHand[2].GetRankAsString()
                    + " of " + game.BHand[2].GetSuitAsString());
            }
            Console.WriteLine();
        }

        public void FinalResult(Baccarat game)
        // displays outcome of game
        {
            if (game.PScore > game.BScore)
            {
                Console.WriteLine("The Player has won");
            }
            if (game.BScore > game.PScore)
            {
                Console.WriteLine("The Banker has won");
            }
            if (game.PScore == game.BScore)
            {
                Console.WriteLine("It's a tie");
            }
        }
    }
}
