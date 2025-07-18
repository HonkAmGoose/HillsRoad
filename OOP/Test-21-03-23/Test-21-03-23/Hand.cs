using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace CardClasses
{
    public class Hand
    // Hand is a collection of previously-created cards, typically contained
    // in Pack.Cards
    // Hand does not create any Cards itself
    {
        protected List<Card> cards = new List<Card>();

        public Card this[int i]
        {
            get { return cards[i]; } 
            // this provides read-only access to the List by index
        }
        protected int GetSize()
        {
            return cards.Count();
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

        public int FindCard(int r, int s)
        // find the position of a specified card in the hand
        // returns -1 if not found
        // useful in rummy-type games
        {
            int result = -1;
            for (int i = 0; i < Size; i++)
            {
                if ((cards[i].GetRank() == r) && (cards[i].GetSuit() == s))
                {
                    result = i;
                }
            }
            return result;
            //returns -1 if not present
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
        public Card RemoveCard(int i)
        // remove card from the hand, by index
        {
            if (Size > i)
            {
                Card result = cards[i];
                cards.RemoveAt(i);
                return result;
            }
            else
            {
                return null;
            }
        }
        public Card RemoveFirstCard()
        {
            if (!IsEmpty())
            {
                Card c = cards[0];
                cards.RemoveAt(0);
                return c;
            }
            else
            {
                return null;
            }

        }

        public void Clear()
        {
            cards.Clear();
        }

    

    }
}
