using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace CardClasses
{
    class Hand
    {
        protected List<Card> cards = new List<Card>();
        protected int GetSize()
        {
            return cards.Count();
        }

        public List<Card> Cards
        {
            get
            {
                return cards;
            }
        }
        public int Size
        {
            get
            {
                return GetSize();
            }
        }
        public void AddCard(Card card)
        {
            cards.Add(card);
        }
        public bool ContainsCard(Card card)
        {
            return cards.Contains(card);
        }
        public int FindCard(Card card)
        {
            return cards.IndexOf(card); //returns -1 if not present
        }
        public Card First()
        {
            return cards[0];
        }

        public bool IsEmpty()
        {
            return Size == 0;
        }
        public Card Last()
        {
            return cards[Size - 1];
        }
        public Card RemoveCard(Card card)
        {
            if (cards.Contains(card))
            {
                int i = cards.IndexOf(card);
                Card c = cards[i];
                cards.RemoveAt(i);
                return c;
            }
            else
            {
                return null;
            }
        }
        public Card RemoveFirstCard()
        {
            Card c = cards[0];
            cards.RemoveAt(0);
            return c;
        }





    }
}
