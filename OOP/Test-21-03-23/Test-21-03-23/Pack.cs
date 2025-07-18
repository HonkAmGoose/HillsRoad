using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardClasses
{


    public class Pack
    // Pack represents a standard pack of 52 cards
    // it creates and frees the Card objects
    {
        Random rnd = new Random();
        private Card[] cardsArray = new Card[52];
        private int front;
        public int Top
        {
            get
            {
                return front;
            }
            set
            {
                front = value;
            }
        }
        private int rear;
        public int Bottom
        {
            get
            {
                return rear;
            }
            set
            {
                rear = value;
            }
        }
        private int size;
        // size is number of cards currently in pack
        public int Size
        {
            get
            {
                return size;
            }
            set
            {
                size = value;
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
        public Pack()
        {
            for (int i = 0; i <= 51; i++)
            {
                cardsArray[i] = new Card((i % 13) + 1, i / 13);
            }
            Top = 0;
            Bottom = 51;
            size = 52;
        }
        public void Shuffle()
        {
            for (int i = Top; i <= Bottom; i++)
            {
                int r = rnd.Next(i, Bottom + 1);
                Card temp = cardsArray[i];
                cardsArray[i] = cardsArray[r];
                cardsArray[r] = temp;
            }
        }
        public Card DealCard()
        {
            if (!IsEmpty())
            {
                Card ACard = cardsArray[Top];
                if (Top == 51)
                    Top = 0;
                else
                    Top++;
                Size--;
                return ACard;
            }
            else
                return null;
        }
        public void AddCard(Card ACard)
        {
            if (!IsFull())
            {
                if (Bottom == 51)
                    Bottom = 0;
                else
                    Bottom++;
                cardsArray[Bottom] = ACard;
                Size++;
            }
        }

    }
}
