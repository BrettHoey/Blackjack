using System;
using System.Collections.Generic;


public enum Suit
{
    Clubs,
    Diamonds,
    Hearts,
    Spades
}

// Enum for card ranks
public enum Rank
{
    Ace = 1,
    Two = 2,
    Three = 3,
    Four = 4,
    Five = 5,
    Six = 6,
    Seven = 7,
    Eight = 8,
    Nine = 9,
    Ten = 10,
    Jack = 10,
    Queen = 10,
    King = 10
}

// Card 
public class Card
{
    public Suit Suit { get; private set; }
    public Rank Rank { get; private set; }

    // initialize a card with given suit and rank
    public Card(Suit suit, Rank rank)
    {
        Suit = suit;
        Rank = rank;
    }

    // Method to get the card val
    public int GetValue()
    {
        
        return (int)Rank;
    }

    // Method to get a string for when its wrote in the console
    public override string ToString()
    {
        return $"{Rank} of {Suit}";
    }
}

// a deck of cards
public class Deck
{
    private List<Card> cards;

    
    public Deck()
    {
        cards = GenerateDeck();
    }

    //generate a deck of 52 cards
    private List<Card> GenerateDeck()
    {
        List<Card> newDeck = new List<Card>();

        foreach (Suit suit in Enum.GetValues(typeof(Suit)))
        {
            foreach (Rank rank in Enum.GetValues(typeof(Rank)))
            {
                newDeck.Add(new Card(suit, rank));
            }
        }

        return newDeck;
    }

    //shuffle the deck
    public void Shuffle()
    {
        Random rng = new Random();
        int n = cards.Count;
        while (n > 1)
        {
            n--;
            int k = rng.Next(n + 1);
            Card value = cards[k];
            cards[k] = cards[n];
            cards[n] = value;
        }
    }

    // deal a card 
    public Card DealCard()
    {
        if (cards.Count == 0)
        {
            throw new InvalidOperationException("The deck is empty. Cannot deal a card.");
        }

        Card dealtCard = cards[cards.Count - 1];
        cards.RemoveAt(cards.Count - 1);
        return dealtCard;
    }
}

// player class representing a player (dealer or user)
public class Player
{
    public string Name { get; private set; }
    private List<Card> hand;

    public Player(string name)
    {
        Name = name;
        hand = new List<Card>();
    }

    // add a card to the player hand
    public void AddCardToHand(Card card)
    {
        hand.Add(card);
    }

    // Method to calculate the score of the player's hand
    public int CalculateScore()
    {
        int score = 0;
        int aceCount = 0;

        foreach (Card card in hand)
        {
            if (card.Rank == Rank.Ace)
            {
                aceCount++;
            }
            score += card.GetValue();
        }

        // Adjust score for Aces (1 or 11)
        //WORK HERE
        //WORK HERE
        //WORK HERE
        //WORK HERE
        //WORK HERE
        //WORK HERE
        //WORK HERE
        //WORK HERE
        //WORK HERE
        //WORK HERE
        //WORK HERE
        //WORK HERE
        //WORK HERE
        //WORK HERE
        //WORK HERE
        //WORK HERE
        //WORK HERE
        while (aceCount > 0 && score > 21)
        {
            score -= 10;
            aceCount--;
        }

        return score;
    }

    // Method to show the player's hand
    public string ShowHand()
    {
        return string.Join(", ", hand);
    }

    // Method to clear player's hand for the next round
    public void ClearHand()
    {
        hand.Clear();
    }
}

// Game class 
public class Game
{
    private Deck deck;
    private Player dealer;
    private Player player;

    public Game()
    {
        deck = new Deck();
        dealer = new Player("Dealer");
        player = new Player("Player");
    }

    // Method to start the game
    public void StartGame()
    {
        Console.WriteLine("Welcome to Blackjack!");

        // Shuffle 
        deck.Shuffle();

        // Deal initial cards
        player.AddCardToHand(deck.DealCard());
        dealer.AddCardToHand(deck.DealCard());
        player.AddCardToHand(deck.DealCard());
        dealer.AddCardToHand(deck.DealCard());

        // Display hands
        Console.WriteLine($"Dealer's Hand: {dealer.ShowHand()}");
        Console.WriteLine($"Player's Hand: {player.ShowHand()}");

        // Check for blackjack
        if (player.CalculateScore() == 21 && dealer.CalculateScore() == 21)
        {
            Console.WriteLine("Push! Both dealer and player have Blackjack.");
            EndGame();
        }
        else if (player.CalculateScore() == 21)
        {
            Console.WriteLine("Player wins with Blackjack!");
            EndGame();
        }
        else if (dealer.CalculateScore() == 21)
        {
            Console.WriteLine("Dealer wins with Blackjack!");
            EndGame();
        }
        else
        {
            // Player's turn
            PlayerTurn();
        }
    }

    // Method to handle player's turn
    private void PlayerTurn()
    {
        while (true)
        {
            Console.Write("Hit or Stand? (h/s): ");
            string response = Console.ReadLine().ToLower();

            if (response == "h")
            {
                player.AddCardToHand(deck.DealCard());
                Console.WriteLine($"Player's Hand: {player.ShowHand()}");

                if (player.CalculateScore() > 21)
                {
                    Console.WriteLine("Player busts! Dealer wins.");
                    EndGame();
                    return;
                }
            }
            else if (response == "s")
            {
                // Player stands so dealer's turn
                DealerTurn();
                return;
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter 'h' to hit or 's' to stand.");
            }
        }
    }

    // Method to handle dealer's turn
    private void DealerTurn()
    {
        Console.WriteLine("Dealer's turn:");

        // Dealer hits until their score is 17 or higher
        while (dealer.CalculateScore() < 17)
        {
            dealer.AddCardToHand(deck.DealCard());
            Console.WriteLine($"Dealer hits: {dealer.ShowHand()}");
        }

        // Display final hands
        Console.WriteLine($"Dealer's Hand: {dealer.ShowHand()}");

        // Determine winner
        if (dealer.CalculateScore() > 21)
        {
            Console.WriteLine("Dealer busts! Player wins.");
        }
        else if (dealer.CalculateScore() == player.CalculateScore())
        {
            Console.WriteLine("Push! It's a tie.");
        }
        else if (dealer.CalculateScore() > player.CalculateScore())
        {
            Console.WriteLine("Dealer wins.");
        }
        else
        {
            Console.WriteLine("Player wins!");
        }

        EndGame();
    }

    // Method to end the game and prompt for a new game
    private void EndGame()
    {
        // Clear hands 
        dealer.ClearHand();
        player.ClearHand();

        Console.Write("Do you want to play again? (yes/no): ");
        string answer = Console.ReadLine().ToLower();

        if (answer == "yes")
        {
            Console.Clear();
            StartGame();
        }
        else
        {
            Console.WriteLine("Thanks for playing!");
        }
    }
}

// Main program to initiate and run the Blackjack game
class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Welcome to Blackjack!");

        bool playAgain ;
        do
        {
            Game game = new Game();
            game.StartGame();

            Console.Write("Do you want to play again? (yes/no): ");
            string answer = Console.ReadLine().ToLower();

            playAgain = (answer == "yes");

            Console.Clear(); // Clear console for the next round
        } while (playAgain);

        Console.WriteLine("Thanks for playing!");
    }
}
