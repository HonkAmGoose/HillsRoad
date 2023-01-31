using System;

namespace War
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("GAME OF WAR");
            Console.WriteLine("Multiplayer version DJ.1.1");
            Console.Write("Number of players (2 or more): ");
            int noOfPlayers = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine();
            GameOfWar game = new GameOfWar(noOfPlayers);
            game.Deal();
            game.Play();
            //Console.ReadLine();
        }
    }
}
