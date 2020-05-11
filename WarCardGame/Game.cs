using System;
using System.Collections.Generic;
using System.Linq;

namespace WarCardGame
{
    public class Game
    {
        //name of player
        static String name;
        //initialize deck object
        static Deck deck = new Deck();

        //declare hand objects
        static Hand hand1;
        static Hand hand2;

        //declares variables for flipped card of each hand
        static Card playerCard;
        static Card botCard;
        public static void Main(string[] args)
        {
            //intro
            Console.WriteLine("Welcome to War");
            Console.Write("Enter your name: ");
            name = Console.ReadLine();
            Console.WriteLine(" ");

            //begin game
            play();

            //announce win or loss
            if (hand1.Hand26.Any())
                Console.WriteLine("You Win!");
            else
                Console.WriteLine("Game Over: You lose");

        }

        public static void play()
        {
            //split the random deck into two separate hands
            hand1 = new Hand(deck, 0, 26);
            hand2 = new Hand(deck, 26, 26);

            Console.WriteLine("------------------------------------------------------");
            Console.WriteLine(hand1.getLength() + "|" + name + "| -->             |             <-- |BOT|" + hand2.getLength());
            Console.WriteLine("------------------------------------------------------");

            //Loop gameplay until one of the hands is empty
            while (hand1.Hand26.Any() && hand2.Hand26.Any())
            {
                //take ReadLine out to run automatically
                Console.WriteLine("Press 'Enter' to play a card");
                Console.ReadLine();

                //initialize flipped card variables
                playerCard = hand1.getCard(0);
                botCard = hand2.getCard(0);

                //if player card is greater, give both cards to player and show the play
                if (playerCard.Value > botCard.Value)
                {
                    hand1.winner(playerCard, botCard);
                    hand2.loser();
                    showMove();
                }

                //if bot card is greater, give both cards to bot and show the play
                else if (playerCard.Value < botCard.Value)
                {
                    hand2.winner(botCard, playerCard);
                    hand1.loser();
                    showMove();
                }

                //if top cards are equal, go to war
                else if (playerCard.Value == botCard.Value)
                {
                    war();
                }
            }
        }

        public static void war()
        {
            //x is the index to grab the next card
            //goes from index 0 to index 2 because index 1 is placed face down in war
            int index = 0;

            //declare lists of cards that will be moved to the bottom of a hand
            List<Card> temp1 = new List<Card>();
            List<Card> temp2 = new List<Card>();

            //loops until the war streak is broken
            while (playerCard.Value == botCard.Value)
            {
                //increases the flipped card index again in case of another war
                index += 2;

                Console.WriteLine("\n            -------------WAR-------------");
                showMove();

                //sets flipped card to the new index
                playerCard = hand1.getCard(index);
                botCard = hand2.getCard(index);

                //if one of the cards at the given index is null, someone ran out and the game ends.
                if (playerCard == null)
                {
                    hand1.Hand26.Clear();
                    return;
                }

                if (botCard == null)
                {
                    hand2.Hand26.Clear();
                    return;
                }

                Console.WriteLine("Press 'Enter' to place 1 face down and 1 face up");
                Console.ReadLine();
            }

            //takes the appropriate amount of cards from the top of each deck
            for (int i = 0; i <= index; i++)
            {
                temp1.Add(hand1.getCard(i));
                temp2.Add(hand2.getCard(i));
            }

            //if player wins the war
            if (playerCard.Value > botCard.Value)
            {
                hand1.winner(temp1, temp2, (index));
                hand2.loser(index);
            }

            //if bot wins the war
            if(playerCard.Value < botCard.Value)
            {
                hand2.winner(temp2, temp1, (index));
                hand1.loser(index);
            }

            showMove();
        }

        public static void showMove()
        {
            Console.WriteLine("------------------------------------------------------");
            Console.WriteLine(hand1.getLength() + "|" + name + "| --> " + playerCard + " | " + botCard + " <-- |BOT|" + hand2.getLength());
            Console.WriteLine("------------------------------------------------------");
        }

    }
}
