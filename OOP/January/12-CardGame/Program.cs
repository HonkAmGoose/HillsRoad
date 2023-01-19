using System;

namespace CardGame
{
    class Program
    {
        static void Main(string[] args)
        {
            Game game = new Game();
            game.Shuffle();
            game.Deal();
            game.Play();
        }
    }
}
