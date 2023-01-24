using System;

namespace SimpleCardGameV2._0
{
    class Program
    {
        static Pack pack;
        static Card[] player1Hand;
        static Card[] player2Hand;


        static void CreateAndShuffle()
        {
            pack = new Pack();
            player1Hand = new Card[26];
            player2Hand = new Card[26];
            //!!! shuffle the pack
            //???

        }

        static void Deal()
        {
            for (int i = 0; i < 26; i++)
            {
                //!!! assign card from pack to player1 hand
                player1Hand[i] = //???
                //!!! assign card from pack to player2 hand
                player2Hand[i] = //???;
            }
        }

        static void Play()
        {
            int score1 = 0;
            int score2 = 0;
            for (int i = 0; i < 26; i++)
            {
                // your algorithm
                Console.WriteLine($"Player 1: {player1Hand[i].GetRankAsString()} of {player1Hand[i].GetSuitAsString()} ({player1Hand[i].GetScore()})");
                Console.WriteLine($"Player 2: {player2Hand[i].GetRankAsString()} of {player2Hand[i].GetSuitAsString()} ({player2Hand[i].GetScore()})");
                if (player1Hand[i].GetScore() > player2Hand[i].GetScore())
                {
                    Console.WriteLine("\nPlayer 1 wins this round!");
                    score1++;
                }
                else
                {
                    Console.WriteLine("\nPlayer 2 wins this round!");
                    score2++;
                }
                Console.ReadLine();
                Console.Clear();
                Console.WriteLine($"Player 1 Points: {score1}\nPlayer 2 Points: {score2}\n\n");
            }
            if (score1 > score2)
            {
                Console.WriteLine("Player 1 Wins!");
            }
            else if (score1 < score2)
            {
                Console.WriteLine("Player 2 Wins!");
            }
            else
            {
                Console.WriteLine("Draw!");
            }

        }
        static void Main(string[] args)
        {
            CreateAndShuffle();
            Deal();
            Play();
        }
    }
}
