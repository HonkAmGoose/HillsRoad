using System;
using CardClasses;
using HandClasses;

class Program
{
    static void Main(string[] args)
    {
        // Empty hand
        BlackjackHand hand = new BlackjackHand(); // Empty
        EvalResults(hand, 0, "Hand");

        // Blackjack
        hand.AddCard(new Card(11, 0)); // J
        hand.AddCard(new Card(1, 0)); // A
        EvalResults(hand, 21, "Blackjack");

        // Blackjack
        hand.AddCard(new Card(1, 0)); // A
        hand.AddCard(new Card(13, 0)); // K
        EvalResults(hand, 21, "Blackjack");

        // No blackjack because ten not face card
        hand.AddCard(new Card(10, 0)); // T
        hand.AddCard(new Card(1, 0)); // A
        EvalResults(hand, 21, "Hand");

        // Five card trick
        hand.AddCard(new Card(2, 0)); // 2
        hand.AddCard(new Card(3, 0)); // 3
        hand.AddCard(new Card(4, 0)); // 4
        hand.AddCard(new Card(5, 0)); // 5
        hand.AddCard(new Card(6, 0)); // 6
        EvalResults(hand, 20, "5 Card Trick");

        // Two aces
        hand.AddCard(new Card(1, 0)); // A
        hand.AddCard(new Card(1, 0)); // A
        EvalResults(hand, 12, "Hand");

        // Four aces
        hand.AddCard(new Card(1, 0)); // A
        hand.AddCard(new Card(1, 0)); // A
        hand.AddCard(new Card(1, 0)); // A
        hand.AddCard(new Card(1, 0)); // A
        EvalResults(hand, 14, "Hand");

        // Both aces as one
        hand.AddCard(new Card(10, 0)); // T
        hand.AddCard(new Card(1, 0)); // A
        hand.AddCard(new Card(1, 0)); // A
        EvalResults(hand, 12, "Hand");

        // Only just gone bust
        hand.AddCard(new Card(10, 0)); // T
        hand.AddCard(new Card(10, 0)); // T
        hand.AddCard(new Card(2, 0)); // 2
        EvalResults(hand, 22, "Bust");
    }

    static bool EvalResults(BlackjackHand hand, int expectedNumber, string expectedType)
    {
        BlackjackScore score = new BlackjackScore();
        score = hand.GetScore();
        hand.Clear();
        Console.Write($"Score {score.Number} (expected {expectedNumber}),\tType {score.Type} (expected {expectedType})\t");
        if (score.Number == expectedNumber && score.Type == expectedType)
        {
            Console.Write("Test passed\n");
            return true;
        }
        else
        {
            Console.Write("Test failed --------------------------------\n");
            return false;
        }
    }
}


/*

// 
            hand.AddCard(new Card(, 0)); // 
            hand.AddCard(new Card(, 0)); // 
            EvalResults(hand, , "Hand");

*/
