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
            

            gameUI.FinalResult(game);
            Console.ReadLine();
    }
    }
}
