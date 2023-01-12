using System;

namespace CardGame
{
    class Program
    {
        static void Main(string[] args)
        {
            for (int rank = 1; rank < 14; rank++)
            {
                for (int suit = 0; suit < 4; suit++)
                {
                    Card card = new(rank, suit);
                    Console.WriteLine($"Your card is the {card.getRankString()} of {card.getSuitString()}, with score {card.getScore()}");
                }
            }
        }
    }
}