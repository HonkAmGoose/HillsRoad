using System;
using CardClasses;

namespace War
{   
    //NB uses System and CardClasses
    public class GameOfWar 
    {
        private Pack pack;
        private int noOfPlayers;
        private Hand[] hands;
        private Card[] cardsNotNeeded;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="noOfPlayers">Number of players</param>
        public GameOfWar(int noOfPlayers)
        {
            pack = new Pack();
            pack.Shuffle();
            hands = new Hand[noOfPlayers]; // the array for the hands of the players is created
            for (int i = 0; i < noOfPlayers; i++)
            {
                hands[i] = new Hand(); // hands for each player are created and assigned to the array
            }
            this.noOfPlayers = noOfPlayers;
        }

        public void Deal()
        {
            // if the number of players is not divisible into 52, deal any leftovers
            int leftovers = 52 % noOfPlayers;
            cardsNotNeeded = new Card[leftovers];
            for (int i = 0; i < leftovers; i++)
            {
                cardsNotNeeded[i] = pack.DealCard();
            }

            // now they can be dealt and each player will get the same amount of cards
            while (!pack.IsEmpty())
            {
                for(int i = 0; i < noOfPlayers; i++)
                {
                    hands[i].AddCard(pack.DealCard());
                }
            }
        }

        public void Play()
        {
            Hand[] cardsInPlayArray = new Hand[noOfPlayers];
            for (int i = 0; i < noOfPlayers; i++)
            {
                // create a hand in each position of the array cardsInPlay
                cardsInPlayArray[i] = new Hand(); 
            }

            int winner = -1;

            // if the game is finished GameFinished will return true and winner will have the player that won the game 
            while (!GameFinished(ref winner))
            {
                int roundWinner = 0;
                do
                {
                    for(int i = 0; i < noOfPlayers; i++)
                    {
                        cardsInPlayArray[i].AddCard(hands[i].RemoveFirstCard());
                        Console.WriteLine(cardsInPlayArray[i].Last().GetName());
                    }                   
                } while ((roundWinner = GetRoundWinner(cardsInPlayArray)) == -1); // loop while there is a war
                
                Console.WriteLine($"Round Winner: {roundWinner+1}");

                // winner gets all cards in table
                while (cardsInPlayArray[0].Size > 0)
                {
                    for (int i = 0; i < noOfPlayers; i++)
                    {
                        hands[roundWinner].AddCard(cardsInPlayArray[i].RemoveFirstCard());
                    }
                }

                // display the number of cards each player has after the round
                for (int i = 0; i < noOfPlayers; i++)
                {
                    Console.WriteLine($"Player {i+1} has {hands[i].Size} cards");
                }
            }
            Console.WriteLine($"The winner is: {winner + 1} with {hands[winner].Size} cards");
        }

        /// <summary>
        /// Finds the winner of the round
        /// </summary>
        /// <param name="cardsInPlayArray"></param>
        /// <returns>It returns the player that won the game or -1 if there is a war</returns>
        private int GetRoundWinner(Hand[] cardsInPlayArray)
        {
            int roundWinner = 0;
            int currentCard = cardsInPlayArray[0].Last().GetRank();
            int newCard;

            for (int i = 1; i < noOfPlayers; i++)
            {
                newCard = cardsInPlayArray[i].Last().GetRank();
                if (newCard > currentCard)
                {
                    roundWinner = i;
                    currentCard = newCard;
                }
                else if (newCard == currentCard)
                {
                    roundWinner = -1;
                }
            }

            return roundWinner;
        }

        /// <summary>
        /// Returns true if the game has finished
        /// The condition can be that a player has 0 cards
        /// or a particular number
        /// Two steps:
        ///  1- check if there is a player with 0 cards
        ///  2- find the player with more cards and returns it
        /// </summary>
        /// <param name="winner">winner is returned</param>
        /// <returns>true if game has finished</returns>
        private bool GameFinished(ref int winner)
        {
            // 1- check if there is a player with 0 cards
            bool finished = false;







            // 2- find the player with more cards
            winner = -1;
           






            return finished;
        }
    }
}
