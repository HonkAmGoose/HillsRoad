using System;

namespace CardGame
{
    internal class Game
    {
        const int Length = 52;
        Card[] pack = new Card[Length];
        Player player1;
        Player player2;

        public Game()
        {
            Create();

            Console.WriteLine("Enter the name of player1:");
            player1 = new Player(Length / 2, Console.ReadLine());
            Console.WriteLine("Enter the name of player2:");
            player2 = new Player(Length / 2, Console.ReadLine());
        }
        
        public void Create()
        {
            for (int i = 0; i < Length; i++)
            {
                pack[i] = new Card(i % 13 + 1, i / 13);
            }
        }

        public void Shuffle()
        {
            Random rnd = new Random();

            for (int i = 0; i < pack.Length - 1; i++)
            {
                int r = rnd.Next(i + 1, 52);
                Card temp = pack[i];
                pack[i] = pack[r];
                pack[r] = temp;
            }
        }

        public void Deal()
        {
            for (int i = 0; i < 26; i++)
            {
                player1.AddToHand(pack[2 * i], i);
                player2.AddToHand(pack[2 * i + 1], i);

            }
        }

        public void Play()
        {
            int card1, card2;

            for (int i = 0; i < 26; i++)
            {
                card1 = player1.GetScoreFromHand(i);
                card2 = player2.GetScoreFromHand(i);

                if (card1 > card2)
                {
                    player1.AddToRounds();
                    Console.WriteLine($"{player1.GetName()} won with their {player1.GetCardFromHand(i)}, to {player2.GetName()}'s {player2.GetCardFromHand(i)}");
                }
                else if (card2 > card1)
                {
                    player2.AddToRounds();
                    Console.WriteLine($"{player2.GetName()} won with their {player2.GetCardFromHand(i)}, to {player1.GetName()}'s {player1.GetCardFromHand(i)}");
                }
                else
                {
                    throw new Exception("Card 1 and 2 cannot be the same");
                }

                Console.ReadLine();
            }

        }
        public void DeclareWinner()
        { 
            int rounds1 = player1.GetRounds();
            int rounds2 = player2.GetRounds();
            if (rounds1 > rounds2)
            {
                Console.WriteLine($"{player1.GetName()} won the game, winning {rounds1} rounds to {player2.GetName()}'s {rounds2}");
            }
            else if (rounds2 > rounds1)
            {
                Console.WriteLine($"{player2.GetName()} won the game, winning {rounds2} rounds to {player1.GetName()}'s {rounds1}");
            }
            else if (rounds1 == rounds2)
            {
                Console.WriteLine("Both player's drew with 13 hands");
            }
        }
    }
}
