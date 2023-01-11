using System;

namespace Test1
{
    class Program1
    {
        public static void Main(string[] args)
        {
            Random rnd = new Random();

            Console.WriteLine("Enter your name: ");
            string name = Console.ReadLine();
            bool playerTurn = true;
            int player = 0;
            int computer = 0;

            do
            {
                if (playerTurn)
                {
                    player += rnd.Next(1, 7);
                    Console.WriteLine($"{name}'s score: {player}");
                    playerTurn = false;
                }
                else
                {
                    computer += rnd.Next(1, 7);
                    Console.WriteLine($"Computer score: {computer}");
                    playerTurn = true;
                }
            } while (player < 21 && computer < 21);

            if (player >= 21)
            {
                Console.WriteLine($"{name} wins!");
            }
            else
            {
                Console.WriteLine("Computer wins!");
            }
        }
    }
}