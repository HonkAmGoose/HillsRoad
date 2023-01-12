using System;

namespace CardGame
{
    class Program
    {
        static void Main(string[] args)
        {
            do
            {
                Random random = new();
                Card card = new(random.Next(1, 14), random.Next(0, 4));

                Console.WriteLine($"Your card is the {card.getRankString()} of {card.getSuitString()}, with score {card.getScore()}");

                Console.WriteLine("Type 'q<enter>' to quit, '<enter>' to continue");
            } while (Console.ReadLine().ToLower() != "q");
        }
    }
}