using System;

namespace Connect4
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Game game = new Game(2, 0);
            game.Play();
        }
    }
}