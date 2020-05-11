using System;
using System.Collections.Generic;
using System.Text;

namespace WarCardGame
{
    public class Card
    {
        //value, name, suit properties
        private int value;
        private String name;
        private String suit;
        public Card(int value, String name, String suit)
        {
            this.Value = value;
            this.Name = name;
            this.Suit = suit;
        }

        //Auto-generated getters and setters
        public int Value { get => value; set => this.value = value; }
        public string Name { get => name; set => name = value; }
        public string Suit { get => suit; set => suit = value; }

        //override ToString to display the name of cards
        public override string ToString()
         {
            return (Name + " of " + Suit);
        }
    }
}
