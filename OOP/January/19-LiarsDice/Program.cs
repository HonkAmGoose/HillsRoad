using System;

namespace LiarsDice
{
    class Program
    {
        // Values for setting up the game
        const int playersPerGame = 1;
        const int computersPerGame = 1;
        const int dicePerHand = 5;
        const int sidesPerDie = 6;

        public static void Main(string[] args)
        {
            try 
            {
                Game game = new Game(playersPerGame, computersPerGame, dicePerHand, sidesPerDie);
                game.Play();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }
    }
}