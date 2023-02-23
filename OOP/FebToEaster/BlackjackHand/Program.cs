﻿using System;
using CardClasses;

namespace BlackjackHand
{
    class Program
    {
        static void Main(string[] args)
        {
            // Empty hand
            BlackjackHand hand = new BlackjackHand(); // Empty
            EvalResults(hand, 0, "Hand");

            // Blackjack
            hand.AddCard(new Card(11, 0)); // Jack
            hand.AddCard(new Card(1, 0)); // Ace
            EvalResults(hand, 21, "Blackjack");

            // Blackjack
            hand.AddCard(new Card(1, 0)); // Ace
            hand.AddCard(new Card(13, 0)); // King
            EvalResults(hand, 21, "Blackjack");

            // No blackjack because ten not face card
            hand.AddCard(new Card(10, 0)); // Ten
            hand.AddCard(new Card(1, 0)); // Ace
            EvalResults(hand, 21, "Hand");

            // Five card trick
            hand.AddCard(new Card(2, 0)); // 2
            hand.AddCard(new Card(3, 0)); // 3
            hand.AddCard(new Card(4, 0)); // 4
            hand.AddCard(new Card(5, 0)); // 5
            hand.AddCard(new Card(6, 0)); // 6
            EvalResults(hand, 20, "5 Card Trick");
        }

        static bool EvalResults(BlackjackHand hand, int expectedNumber, string expectedType)
        {
            BlackjackHand.Score score = new BlackjackHand.Score();
            score = hand.GetScore();
            hand.Clear();
            Console.Write($"Score {score.number} (expected {expectedNumber}), Type {score.type} (expected {expectedType}) ");
            if (score.number == expectedNumber && score.type == expectedType)
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
}

/*

// 
            hand.AddCard(new Card(, 0)); // 
            hand.AddCard(new Card(, 0)); // 
            EvalResults(hand, , "Hand");

*/
