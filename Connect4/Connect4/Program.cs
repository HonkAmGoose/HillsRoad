using System;

namespace Connect4
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // Create new game with 2 human players, 0 computer players on a 7*6 board
            Game game = new Game(2, 0, 7, 6);

            // Play the game
            game.Play();
        }
    }
}