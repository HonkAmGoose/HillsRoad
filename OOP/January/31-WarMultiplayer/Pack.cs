using System;
using System.Collections.Generic;
using System.Text;

namespace CardClasses
{
    public class Pack
    {
        Random rnd = new Random();
        private Card[] cardsArray = new Card[52];

        private int front;
        private int rear;

        private int size;  // size is number of cards currently in pack
        public int Size  //property to provide read-only access to size field
        {
            get { return size; }
        }

        //constructor
        public Pack() 
        {
            for (int i = 0; i <= 51; i++)
            {
                cardsArray[i] = new Card((i % 13) + 1, i / 13);
            }
            front = 0;
            rear = 51;
            size = 52;
        }

        public void Shuffle()
        {
            //Fisher-Yates shuffle
            for (int i = 0; i < size - 1; i++)
            {
                int r = rnd.Next(i + 1, 52);
                Card temp = cardsArray[i];
                cardsArray[i] = cardsArray[r];
                cardsArray[r] = temp;
            }
        }

        public bool IsEmpty()
        {
            return size == 0;
        }

        public bool IsFull()
        {
            return size == 52;
        }

        public Card DealCard()
        {
            if (!IsEmpty())
            {
                Card ACard = cardsArray[front];
                if (front == 51)
                    front = 0;
                else
                    front++;
                size--;
                return ACard;
            }
            else
                return null;
        }

        public void AddCard(Card ACard)
        {
            if (!IsFull())
            {
                if (rear == 51)
                {
                    rear = 0;
                }
                else
                {
                    rear++;
                }
                cardsArray[rear] = ACard;
                size++;
            }
        }

    }
}
