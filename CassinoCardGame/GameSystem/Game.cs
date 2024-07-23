using Domain;

namespace GameEngine;

public static class Game
{
    public static Stack<Card>? FullDeck { get; set; }
    public static Player? Player { get; set; }
    public static List<Player>? Opponents { get; set; }
    public static List<Card>? TableCards { get; set; }

    public static void NewGame()
    {
        
    }

    public static void DealStartCards()
    {
        ShuffleNewDeck();
        Player!.Hand = DealFourCards();
        foreach (var opponent in Opponents!)
        {
            opponent.Hand = DealFourCards();   
        }
        TableCards = DealFourCards();
        for (int i = 4; i < 10; i++)
        {
            TableCards.Add(new Card()
            {
                Rank = ERank.Empty,
                Suit = ESuit.Empty,
                CardType = ECardType.Empty
            });
            Console.WriteLine(TableCards[i].Rank);
        }
    }

    public static void ShuffleNewDeck()
    {
        List<Card> deck = new List<Card>();
        Card card;
        var ranks = Enum.GetValues(typeof(ERank)).Cast<ERank>();
        var suits = Enum.GetValues(typeof(ESuit)).Cast<ESuit>();

        foreach (var rank in ranks)
        {
            foreach (var suit in suits)
            {
                int value = (int) rank;
                if (rank == ERank.Two && suit == ESuit.Spades)
                {
                    value = 15;
                } else if (rank == ERank.Ten && suit == ESuit.Diamonds)
                {
                    value = 16;
                }
                deck.Add(new Card()
                {
                    Rank = rank,
                    Suit = suit,
                    HandValue = value,
                    TableValue = (int) rank,
                    CardType = ECardType.Card
                });
            }
        }

        FullDeck = new Stack<Card>();
        Random rand = new Random();
        int randomIndex;
        while (deck.Count > 0)
        {
            randomIndex = rand.Next(0, deck.Count);
            FullDeck.Push(deck[randomIndex]);
            //b.Value = deck[randomIndex].Rank;
            deck.RemoveAt(randomIndex);
        }
    }

    public static List<Card> DealFourCards()
    {
        if (FullDeck?.Count < 4)
        {
            throw new ApplicationException("Too few cards left");
        }
        List<Card> cards = new List<Card>();
        for (int i = 0; i < 4; i++)
        {
            cards.Add(FullDeck?.Pop());
        }

        return cards;
    }

    public static bool CanCapture(int tableIndex, int handIndex)
    {
        return TableCards?[tableIndex].TableValue == Player?.Hand?[handIndex].HandValue;
    }
    
    public static bool CanBuild(List<int> indices)
    {
        bool canBuild = false;
        int totalValue = 0;
        foreach (var index in indices)
        {
            totalValue += TableCards![index].TableValue;
        }

        foreach (var card in Player!.Hand!)
        {
            if (card.HandValue == totalValue)
            {
                canBuild = true;
                break;
            }
        }

        return canBuild;
    }
    
    public static bool CanCall(int index)
    {
        int count = 0;
        Card tableCard = TableCards![index]!;
        foreach (var card in Player!.Hand!)
        {
            if (tableCard.TableValue == card.TableValue)
            {
                count++;
            }
        }
        return count >= 2;
    }
    
    public static bool CanTrail(int index)
    {
        return TableCards![index].CardType == ECardType.Empty;
    }
}