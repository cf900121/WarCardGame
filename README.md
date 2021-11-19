# WarCardGame

Chris Falco
“Provide a plan on how you would design a digital game of the classic card game of war”
What are the core aspects of the game? (Based on the official Bicycle Cards website)
- 2 players 
- 52 cards
o Divided randomly between the 2 players
o 13 values (2, 3, 4, 5, 6, 7, 8, 9, 10, Jack, Queen, King, Ace)
o 4 suits (Diamonds, Hearts, Clubs, Spades)
- Player A and Player B each flip a card
o Player A’s card > Player B’s card → Player A puts both cards under his/her deck
o Player B’s card > Player A’s card → Player B puts both cards under his/her deck
o Player A’s card = Player B’s card → War
- War
o Each player places a new card face-down, and another new card face-up.
▪ Higher face-up card wins, and all cards go to bottom of the winner’s deck. 
▪ If they tie again, repeat war step.
▪ If someone runs out of cards, they lose.

Making the game:
- Card Object:
o String Name (2, 3, 4, 5, 6, 7, 8, 9, 10, Jack, Queen, King, Ace)
o int Value (0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12)
▪ The specific number values are irrelevant, as long 
o String Suit (Diamonds, Hearts, Clubs, Spades)
o Getters and Setters
o Override ToString
- Deck Object
o List of Card objects 
o Getter and Setter
o Create all 52 cards and put them into a deck - per suit (4) per value (13)
o Shuffle the deck randomly
- Hand Object:
o List of Card Objects
o Length of the list
o Getters and Setters
o Create a 26-card hand from the original deck using requested range
o Try to return a card from requested hand index
o Return updated length of the hand
o 2 round-winner and 2 round-loser functions, one overloaded for war

Since War is a game where you can’t see your deck, there isn’t much work to be done for a 
player digitally. Both players could be automatic, the opponent could be automatic, or neither 
could be automatic, but ultimately the only function of the user would be to press a button to 
draw each card. I assume human vs. bot in this project. -- Chris → 8 : 5  BOT –

Game:
- Main
o Create deck
o Shuffle deck
o Game intro/ name prompt
o Play();
o Announce victory status
- Play
o Create hands
o Loop gameplay until one hand is empty
▪ Get top cards and compare
▪ Reallocate cards appropriately
▪ showMove();
▪ If top cards are equal, call war();
- War
o Initialize index variable and increase for each consecutive war
o Loop until war is broken
▪ Set each play card to new index
▪ If index is null, someone ran out and game ends
o Reallocate cards appropriately
o showMove();
- showMove
o Display a semblance of what each turn would look like
▪ Player name
▪ Bot
▪ Card played this turn
▪ Amount of cards in each deck

My process in making this game began with defining as best I could everything it would need to operate. 
When I got in and started coding there was a good bit that I didn’t consider, but the overall themes 
remained intact. My first version worked but didn’t utilize object-oriented concepts as best as it could 
have. It only had a Card class. Then I reworked it so that I could have a Deck class. The deck object was 
also used for the creation of each hand. For cleanliness, my final version takes all of the hand-specific 
properties and functions of Deck and moves them into their own class. Last I made sure all the 
properties, and any functions that I thought necessary, were encapsulated. (The automatic getters and 
setters in Visual Studio are really cool – I had never used them before).
