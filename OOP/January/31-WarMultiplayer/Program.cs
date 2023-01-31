using System;

namespace War
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("GAME OF WAR");
            Console.WriteLine("Multiplayer version 1.0");
            Console.Write("Number of players (2-4): ");
            int noOfPlayers = Convert.ToInt32(Console.ReadLine());
            GameOfWar game = new GameOfWar(noOfPlayers);
            game.Deal();
            game.Play();
            //Console.ReadLine();
        }
    }
}
