using Domain;

namespace ConsoleGui;

public class Gui
{
    private Dictionary<(int, int), Card> PlayerCards = new Dictionary<(int, int), Card>();
    private Dictionary<(int, int), Build> TableCards = new Dictionary<(int, int), Build>();
    private bool PlayerCardSelected = false;
    public int BoardWidth { get; set; } = 150;
    public int BoardHeight { get; set; } = 200;

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

    public void InitBoard()
    {
        Console.Write(new string('#', BoardWidth));
        Console.SetCursorPosition(0, 1);
        Console.Write("#");
        Console.SetCursorPosition(BoardWidth - 1, 1);
        Console.Write("#");
        Console.WriteLine();
        Console.WriteLine(new string('#', BoardWidth));
        for (int i = 3; i < BoardHeight - 1; i++)
        {
            //Console.SetCursorPosition(0, i);
            Console.Write("#");
            Console.SetCursorPosition(BoardWidth - 1, i);
            Console.WriteLine("#");
        }
        Console.WriteLine(new string('#', BoardWidth));
    }

    public void PlayerMove()
    {
        int currentCard = 0;
        int previousCard = 0;
        bool isTurnDone = false;
        ConsoleKey key;
        List<(int, int)> keys = PlayerCards.Keys.ToList();
        while (!isTurnDone)
        {
            DrawCard(keys[previousCard].Item1, keys[previousCard].Item1, PlayerCards[keys[previousCard]]);
            DrawCard(keys[currentCard].Item1, keys[currentCard].Item1, PlayerCards[keys[currentCard]], ConsoleColor.Yellow);
            key = Console.ReadKey().Key;
            if (key == ConsoleKey.LeftArrow)
            {
                if (currentCard > 0)
                {
                    previousCard = currentCard;
                    currentCard--;
                }
            } else if (key == ConsoleKey.RightArrow)
            {
                if (currentCard < keys.Count - 2)
                {
                    previousCard = currentCard;
                    currentCard++;
                }
            } else if (key == ConsoleKey.Enter)
            {
                
            }
        }
    }
    
    private void TableMove(int currentCard) {}
    /// <summary>
    /// Draws card in specified position
    /// </summary>
    /// <param name="x"></param>
    /// <param name="y"></param>
    /// <param name="card"></param>
    /// <param name="color"></param>
    public void DrawCard(int x, int y, Card card, ConsoleColor color = ConsoleColor.Gray)
    {
        string[] correctCard = GetCorrectCard(card);
        foreach (var c in correctCard)
        {
            Console.SetCursorPosition(x, y);
            Console.Write(c);
            y++;
        }
        
    }
    
    
    
    public void DrawTable()
    {
        
    }

    public void DrawPlayerHand(List<Card> cards)
    {
        int x = 10;
        foreach (var card in cards)
        {
            DrawCard(x, 10, card);
            x += 10;
        }
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