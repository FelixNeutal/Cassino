using Domain;

namespace GameEngine;

public class Game
{
    public List<Card> FullDeck { get; set; } = new List<Card>();

    public void ShuffleNewDeck()
    {
        List<Card> deck = new List<Card>();
        Card card;
        var ranks = Enum.GetValues(typeof(ERank)).Cast<ERank>();
        var suits = Enum.GetValues(typeof(ESuit)).Cast<ESuit>();

        foreach (var rank in ranks)
        {
            foreach (var suit in suits)
            {
                deck.Add(new Card()
                {
                    Rank = rank,
                    Suit = suit
                });
            }
        }

        FullDeck = new List<Card>();
        Random rand = new Random();
        int randomIndex;
        while (deck.Count > 0)
        {
            randomIndex = rand.Next(0, deck.Count);
            FullDeck.Add(deck[randomIndex]);
            deck.RemoveAt(randomIndex);
        }
    }
}