using System;
using System.Collections.Generic;
using System.Linq;

namespace WarCardGame
{
    class Hand
    {
        private List<Card> hand26;
        private int length;

        public Hand()
        {
        }

        public Hand(Deck deck, int start, int count)
        {
            createHand(deck, start, count);
            this.Length = Hand26.Count;
        }

        //Auto-generated getters and setters
        public List<Card> Hand26 { get => hand26; set => hand26 = value; }
        public int Length { get => length; set => length = value; }

        private void createHand(Deck deck, int start, int count)
        {
            //takes the first or second 26 cards of shuffled 52 deck to make each hand
            this.Hand26 = new List<Card>(deck.Deck52.GetRange(start, count));
        }

        public Card getCard(int x)
        {
            //try to return card at given index
            try
            {
                return Hand26[x];
            }
            catch (Exception)
            {
                Console.WriteLine("Someone ran out of cards during war");
            }

            return null;
        }

        public int getLength()
        {
            //return length of hand
            return Hand26.Count;
        }

        public void winner(Card x, Card y)
        {
            //remove top card
            Hand26.RemoveAt(0);
            //add both top cards to bottom of deck
            Hand26.Add(x);
            Hand26.Add(y);
        }

        public void winner(List<Card> temp1, List<Card> temp2, int index)
        {
            //remove appropriate amount of cards from top of deck
            loser(index);
            //add war winning to bottom of deck
            Hand26.AddRange(temp1);
            Hand26.AddRange(temp2);
        }

        public void loser()
        {
            //remove top card
            Hand26.RemoveAt(0);
        }

        public void loser(int index)
        {
            //remove appropriate amount of cards from top of deck
            for (int x = 0; x <= index; x++)
            {
                Hand26.RemoveAt(0);
            }
        }

    }
}
