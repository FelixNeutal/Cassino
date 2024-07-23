using Domain;

namespace ConsoleGui;

public static class Cards
{
    private static string[] _heartsCard = {" _______ ",
        "|  _ _  |",
        "| ( V ) |",
        "|  \\ /  |",
        "|   .   |",
        "|______H|"};
    private static string[] _diamondsCard = {" _______ ",
        "|   ^   |",
        "|  / \\  |",
        "|  \\ /  |",
        "|   .   |",
        "|______D|"};
    private static string[] _clubsCard = {" _______ ",
        "|   _   |",
        "|  ( )  |",
        "| (_'_) |",
        "|   |   |",
        "|______C|"};
    private static string[] _spadesCard = {" _______ ",
        "|   .   |",
        "|  /.\\  |",
        "| (_._) |",
        "|   |   |",
        "|______S|"};
    private static string[] _emptyCard = {" _______ ",
        "| EMPTY |",
        "|       |",
        "|       |",
        "|       |",
        "|_______|"};
    private static string[] _opponentCard = {" _______ ",
        "|# # # #|",
        "| # # # |",
        "|# # # #|",
        "| # # # |",
        "|_______|"};
    
    public static void DrawCard(int left, int top, Card card, ConsoleColor color = ConsoleColor.Gray)
    {
        Console.ForegroundColor = color;
        foreach (var c in card.StringRepresentation!)
        {
            Console.SetCursorPosition(left, top);
            Console.Write(c);
            top++;
        }
    }
    
    private static string[] GetCorrectCard(Card card, string special = "none")
    {
        string[] correctCard = {};
        if (special != "none")
        {
            if (special == "OpponentCard")
            {
                return _opponentCard;
            } else if (special == "EmptyCard")
            {
                return _emptyCard;
            }
        }
        switch (card.Suit)
        {
            case ESuit.Clubs:
                string[] newArray = new string[_clubsCard.Length];
                _clubsCard.CopyTo(newArray, 0);
                correctCard = newArray;
                break;
            case ESuit.Diamonds:
                newArray = new string[_diamondsCard.Length];
                _diamondsCard.CopyTo(newArray, 0);
                correctCard = newArray;
                break;
            case ESuit.Hearts:
                newArray = new string[_heartsCard.Length];
                _heartsCard.CopyTo(newArray, 0);
                correctCard = newArray;
                break;
            case ESuit.Spades:
                newArray = new string[_spadesCard.Length];
                _spadesCard.CopyTo(newArray, 0);
                correctCard = newArray;
                break;
        }

        if (correctCard.Length == 0)
        {
            throw new ApplicationException($"Unknown card {card}");
        }

        var characters = correctCard[1].ToCharArray();

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

        return correctCard;
    }
}