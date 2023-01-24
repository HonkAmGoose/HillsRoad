using System;

namespace Queue
{
    //NB uses System and CardClasses
    public class WarGame
    {
        private Pack pack;
        private Hand p1Hand, p2Hand;

        public WarGame()
        {
            //!!!!
            //create the pack and hands
            //!!!!
            //shuffle the pack
            //!!!!
        }

        public void Deal()
        {
            while (!pack.IsEmpty())
            {
                p1Hand.AddCard(pack.DealCard());
                p2Hand.AddCard(pack.DealCard());
            }
        }

        public void Play()
        {
            Hand p1CardsInPlay = new Hand();
            Hand p2CardsInPlay = new Hand();
            Random random = new Random();
            while (!p1Hand.IsEmpty() | !p2Hand.IsEmpty())
            {
                do
                {
                    p1CardsInPlay.AddCard(p1Hand.RemoveFirstCard());
                    p2CardsInPlay.AddCard(p2Hand.RemoveFirstCard());
                    Console.WriteLine(p1CardsInPlay.Last().GetName() + " " + p2CardsInPlay.Last().GetName());
                } while (p1CardsInPlay.Last().GetRank() == p2CardsInPlay.Last().GetRank());

                if (p1CardsInPlay.Last().GetRank() > p2CardsInPlay.Last().GetRank()) //!!!! Player1's card is higher than Player2's card
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
                    //!!!! do the same but for Player2
                    //!!!!
                    //!!!!
                    //!!!!
                    //!!!!
                }
                Console.WriteLine("Player 1 has " + p1Hand.Size + " cards");
                Console.WriteLine("Player 2 has " + p2Hand.Size + " cards");
            }
        }

    }
}
