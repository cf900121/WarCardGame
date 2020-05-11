using System;
using System.Collections.Generic;

namespace WarCardGame
{ 
    class Deck
    {
        //deck and length properties
        private List<Card> deck52;
        private int length;

        //constructor for original 52 card deck
        public Deck()
        {
            this.Deck52 = new List<Card>();
            //generates 52 card deck
            createDeck();
            //shuffles deck randomly
            shuffleDeck();
        }

        //Auto-generated getter and setter
        public int Length { get => length; set => length = value; }
        public List<Card> Deck52 { get => deck52; set => deck52 = value; }

        private void createDeck()
        {
            //lists for all card numbers and suits
            String[] names = { "2", "3", "4", "5", "6", "7", "8", "9", "10", "J", "Q", "K", "A" };
            String[] suit = { "Diamonds", "Hearts", "Clubs", "Spades" };

            //loop to make all 52 combinations of card and suit
            for (int x = 0; x < suit.Length; x++)
            {
                for (int y = 0; y < names.Length; y++)
                {
                    Deck52.Add(new Card(y, names[y], suit[x]));
                }
            }
        }
        private void shuffleDeck()
        {
            //creates a second copy of unshuffled deck
            List<Card> unshuffled = new List<Card>(Deck52);

            //clear deck to rebuild it randomly
            Deck52.Clear();

            for (int x = 52; x > 0; x--)
            {
                //generate random value between 0 and current size of deck
                Random random = new Random();
                int index = random.Next(x);

                //add random card to deck
                Deck52.Add(unshuffled[index]);

                //pop that card out of unshuffled deck
                unshuffled.RemoveAt(index);
            }
        }
    }
}
