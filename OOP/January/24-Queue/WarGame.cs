using System;

namespace Queue
{
    public class WarGame
    {
        private Pack pack;
        private Hand p1Hand, p2Hand;
        private int rounds;

        public WarGame()
        {
            Create();
            pack.Shuffle();
            Deal();
        }

        public void Create()
        {
            pack = new Pack();
            p1Hand = new Hand();
            p2Hand = new Hand();
        }

        public void Deal()
        {
            while (!pack.IsEmpty())
            {
                p1Hand.AddCard(pack.DealCard());
                p2Hand.AddCard(pack.DealCard());
            }
        }

        public void PlayAndDisplay(int rounds)
        {
            this.rounds = rounds;
            Play(rounds);
            DeclareWinner();
        }

        public void Play(int rounds)
        {
            Hand p1CardsInPlay = new Hand();
            Hand p2CardsInPlay = new Hand();

            int n = 0;
            while (!p1Hand.IsEmpty() && !p2Hand.IsEmpty() && n < rounds)
            {
                Console.WriteLine($"Player 1 has {p1Hand.Size} cards\tPlayer 2 has {p2Hand.Size} cards");
                
                do
                {
                    p1CardsInPlay.AddCard(p1Hand.RemoveFirstCard());
                    p2CardsInPlay.AddCard(p2Hand.RemoveFirstCard());
                    Console.WriteLine($"P1: {p1CardsInPlay.Last().GetName()}\tP2: {p2CardsInPlay.Last().GetName()}");
                } while (p1CardsInPlay.Last().GetRank() == p2CardsInPlay.Last().GetRank());

                if (p1CardsInPlay.Last().GetRank() > p2CardsInPlay.Last().GetRank())
                {
                    Console.WriteLine("Player 1 wins");
                    while (!p1CardsInPlay.IsEmpty())
                    {
                        p1Hand.AddCard(p1CardsInPlay.RemoveFirstCard());
                        p1Hand.AddCard(p2CardsInPlay.RemoveFirstCard());
                    }
                }
                else if (p1CardsInPlay.Last().GetRank() < p2CardsInPlay.Last().GetRank())
                {
                    Console.WriteLine("\t\t\tPlayer 2 wins");
                    while (!p2CardsInPlay.IsEmpty())
                    {
                        p2Hand.AddCard(p1CardsInPlay.RemoveFirstCard());
                        p2Hand.AddCard(p2CardsInPlay.RemoveFirstCard());
                    }
                }
                else
                {
                    throw new Exception("This is an impossible state to get to");
                }

                Console.WriteLine();
                n++;
            }
            rounds = n;
        }

        public void DeclareWinner()
        {
            int p1Score = p1Hand.Size;
            int p2Score = p2Hand.Size;

            if (p1Score > p2Score)
            {
                Console.WriteLine($"****** After {rounds} rounds, player 1 wins with {p1Score} cards to {p2Score} ******");
            }
            else if (p2Score > p1Score)
            {
                Console.WriteLine($"****** After {rounds} rounds, player 2 wins with {p2Score} cards to {p1Score} ******");
            }
            else if (p1Score == p2Score)
            {
                Console.WriteLine("********************* Draw - Tiebreaker time! ********************\n");
                rounds++;
                Play(1);
                DeclareWinner();
            }
        }
    }
}
