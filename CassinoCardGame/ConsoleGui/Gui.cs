using Domain;

namespace ConsoleGui;

public class Gui
{
    private string[] _heartsCard = {" _______ ",
                                "|  _ _  |",
                                "| ( V ) |",
                                "|  \\ /  |",
                                "|   .   |",
                                "|______H|"};
    private string[] _diamondsCard = {" _______ ",
                                  "|   ^   |",
                                  "|  / \\  |",
                                  "|  \\ /  |",
                                  "|   .   |",
                                  "|______D|"};
    private string[] _clubsCard = {" _______ ",
                               "|   _   |",
                               "|  ( )  |",
                               "| (_'_) |",
                               "|   |   |",
                               "|______C|"};
    private string[] _spadesCard = {" ________ ",
                                "|   .   |",
                                "|  /.\\  |",
                                "| (_._) |",
                                "|   |   |",
                                "|______S|"};
    public void DrawCard(int x, int y, Card card, ConsoleColor color = ConsoleColor.Gray)
    {
        string[] correctCard = GetCorrectCard(card);
        foreach (var c in correctCard)
        {
            Console.WriteLine(c);
        }
        
    }
    
    public void DrawTable()
    {
        
    }

    public void DrawPlayerHand()
    {
        
    }

    private string[] GetCorrectCard(Card card)
    {
        string[] correctCard = {};
        switch (card.Suit)
        {
            case ESuit.Clubs:
                correctCard = _clubsCard;
                break;
            case ESuit.Diamonds:
                correctCard = _diamondsCard;
                break;
            case ESuit.Hearts:
                correctCard = _heartsCard;
                break;
            case ESuit.Spades:
                correctCard = _spadesCard;
                break;
        }

        if (correctCard.Length == 0)
        {
            throw new ApplicationException($"Unknown card {card}");
        }

        var characters = correctCard[1].ToCharArray();
        Console.WriteLine(characters.Length);

        switch (card.Rank)
        {
            case ERank.Ace:
                characters[1] = 'A';
                break;
            case ERank.Two:
                characters[1] = '2';
                break;
            case ERank.Three:
                characters[1] = '3';
                break;
            case ERank.Four:
                characters[1] = '4';
                break;
            case ERank.Five:
                characters[1] = '5';
                break;
            case ERank.Six:
                characters[1] = '6';
                break;
            case ERank.Seven:
                characters[1] = '7';
                break;
            case ERank.Eight:
                characters[1] = '8';
                break;
            case ERank.Nine:
                characters[1] = '9';
                break;
            case ERank.Ten:
                characters[1] = '1';
                characters[2] = '0';
                break;
            case ERank.Jack:
                characters[1] = 'J';
                break;
            case ERank.Queen:
                characters[1] = 'Q';
                break;
            case ERank.King:
                characters[1] = 'K';
                break;
        }
        correctCard[1] = new string(characters);
        Console.WriteLine("Yeah" + correctCard[1] + "Yeah");

        return correctCard;
    }
}