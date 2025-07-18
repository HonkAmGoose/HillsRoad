using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CardClasses;

namespace Baccarat
{
    class Program
    {
        static void Main(string[] args)
        {
            BaccaratGameUI gameUI = new BaccaratGameUI();
            Baccarat game = new Baccarat();
            game.Deal();
            gameUI.Display(game);

            if (game.Natural() == true)
            {
                Console.WriteLine("One player has a Natural: the game is over");
            }
            else
            {
                game.Draw();
                gameUI.DisplayDraw(game);
                gameUI.Display(game);
            }

            gameUI.FinalResult(game);
            Console.ReadLine();
        }
    }
}
