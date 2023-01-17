using System;

namespace CardGame
{
    class Program
    {
        const int Length = 52;
        static Card[] pack = new Card[Length];
        static Card[] hand1 = new Card[Length / 2];
        static Card[] hand2 = new Card[Length / 2];

        static void Create()
        {
            for (int i = 0; i < Length; i++)
            {
                pack[i] = new Card(i % 13 + 1, i / 13);
            }
        }

        static void Shuffle()
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

        static void Deal()
        {
            for (int i = 0; i < 26; i++)
            {
                hand1[i] = pack[2 * i];
                hand2[i] = pack[2 * i + 1];

            }
        }

        static void Play()
        {
            int score1 = 0;
            int score2 = 0;
            int card1, card2;

            for (int i = 0; i < 26; i++)
            {
                card1 = hand1[i].GetScore();
                card2 = hand2[i].GetScore();

                if (card1 > card2)
                {
                    score1++;
                    Console.WriteLine($"Player1 won with their {hand1[i]}, to Player2's {hand2[i]}");
                }
                else if (card2 > card1)
                {
                    score2++;
                    Console.WriteLine($"Player2 won with their {hand2[i]}, to Player1's {hand1[i]}");
                }
                else
                {
                    throw new Exception("Card 1 and 2 cannot be the same");
                }

                Console.ReadLine();
            }

            if (score1 > score2)
            {
                Console.WriteLine($"Player1 won the game, winning {score1} rounds to Player2's {score2}");
            }
            else if (score2 > score1)
            {
                Console.WriteLine($"Player2 won the game, winning {score2} rounds to Player1's {score1}");
            }
        }

        static void Main(string[] args)
        {
            Create();
            Shuffle();
            Deal();
            Play();
        }
    }
}
