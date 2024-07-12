using Domain;

namespace GameEngine;

public class Game
{
    public Stack<Build>? FullDeck { get; set; }
    public Player? Player { get; set; }
    public List<Player>? Opponents { get; set; }
    public List<Build>? TableCards { get; set; }

    public void DealStartCards()
    {
        ShuffleNewDeck();
        Player!.Hand = DealFourCards();
        foreach (var opponent in Opponents!)
        {
            opponent.Hand = DealFourCards();   
        }
        TableCards = DealFourCards();
    }

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

        FullDeck = new Stack<Build>();
        Random rand = new Random();
        int randomIndex;
        while (deck.Count > 0)
        {
            randomIndex = rand.Next(0, deck.Count);
            Build b = new Build();
            b.Cards.Add(deck[randomIndex]);
            FullDeck.Push(b);
            //b.Value = deck[randomIndex].Rank;
            deck.RemoveAt(randomIndex);
        }
    }

    public List<Build> DealFourCards()
    {
        if (FullDeck?.Count < 4)
        {
            throw new ApplicationException("Too few cards left");
        }
        List<Build> cards = new List<Build>();
        for (int i = 0; i < 4; i++)
        {
            cards.Add(FullDeck?.Pop());
        }

        return cards;
    }
    
    public bool CanCombine(Build b1, Build b2)
    {
        return b1.Value == b2.Value;
    }

    public bool CanCapture(Build b1, Build b2)
    {
        return b1.Value == b2.Value;
    }
    
    public bool CanBuild(Build b1, Build b2)
    {
        // Make logic
        return b1.Value == b2.Value;
    }
    
    public bool CanCall(Build b1, Build b2)
    {
        return b1.Value == b2.Value;
    }
    
    public bool CanTrail(Build b1)
    {
        return true;
    }

    public Build Combine(Build b1, Build b2)
    {
        Build b = new Build();
        b.Cards = b1.Cards.Concat(b2.Cards).ToList();
        return b;
    }
    
    public Build Capture(Build b1, Build b2)
    {
        Build b = new Build();
        b.Cards = b1.Cards.Concat(b2.Cards).ToList();
        return b;
    }
}