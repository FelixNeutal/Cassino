using Domain;

namespace ConsoleGui;

public class Gui
{
    private List<ConsoleBuild> _playerCards = new List<ConsoleBuild>();
    private List<ConsoleBuild> _opponentCards = new List<ConsoleBuild>();
    private List<ConsoleBuild> _tableCards = new List<ConsoleBuild>();
    private bool PlayerCardSelected = false;
    private int _cardSpacing = 5;
    private int _cardWidth = 9;
    private int _cardHeight = 6;
    public int BoardWidth { get; set; } = 74;
    public int BoardHeight { get; set; } = 41;

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
    private string[] _spadesCard = {" _______ ",
                                "|   .   |",
                                "|  /.\\  |",
                                "| (_._) |",
                                "|   |   |",
                                "|______S|"};
    private string[] _emptyCard = {" _______ ",
                                "| EMPTY |",
                                "|       |",
                                "|       |",
                                "|       |",
                                "|_______|"};
    private string[] _opponentCard = {" _______ ",
                                "|# # # #|",
                                "| # # # |",
                                "|# # # #|",
                                "| # # # |",
                                "|_______|"};

    public void InitBoard()
    {
        Console.CursorVisible = false;
        // Console.SetWindowSize(640, 480);
        // Console.WriteLine(Console.LargestWindowHeight); // 41
        // Console.WriteLine(Console.LargestWindowWidth); // 74
        
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
        string opponentTurnLabel = "Opponent's hand";
        Console.SetCursorPosition(BoardWidth / 2 - 8, 3);
        Console.Write(opponentTurnLabel);
        // Draw table 
        Console.SetCursorPosition(1, 11);
        Console.Write(new string('=', BoardWidth - 2));
        Console.SetCursorPosition(1, 26);
        Console.Write(new string('=', BoardWidth - 2));
    }

    public void DrawMenu(ConsoleBuild card)
    {
        
    }

    public void GetPlayerMove()
    {
        GetPlayerMove(_tableCards, 2);
    }

    public void GetPlayerMove(List<ConsoleBuild> cards, int level)
    {
        int currentCard = 0;
        int previousCard = 0;
        bool isTurnDone = false;
        ConsoleKey key;
        while (!isTurnDone)
        {
            DrawCard(cards[previousCard].Left, cards[previousCard].Top, cards[previousCard]);
            DrawCard(cards[currentCard].Left, cards[currentCard].Top, cards[currentCard], ConsoleColor.Yellow);
            DrawMenu(cards[currentCard]);            
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
                if (currentCard < cards.Count - 1)
                {
                    previousCard = currentCard;
                    currentCard++;
                }
            } else if (key == ConsoleKey.Enter)
            {
                
            //} else if (key == ConsoleKey.UpArrow && level == 1)
            //{
            //    DrawCard(cards[currentCard].Left, cards[currentCard].Top, cards[currentCard]);
            //    GetPlayerMove(null, _tableCards, 2);
            } else if (key == ConsoleKey.Escape && level == 2)
            {
                DrawCard(cards[currentCard].Left, cards[currentCard].Top, cards[currentCard]);
                isTurnDone = true;
            }
        }
    }

    public void DrawPlayerCards(List<Build>? cards)
    {
        if (cards == null)
        {
            throw new ApplicationException("Player cards are null");
        }
        int left = 2;
        int top = 28;
        foreach (var card in cards)
        {
            ConsoleBuild ccard = new ConsoleBuild()
            {
                Cards = { card.Cards[0] },
                Left = left,
                Top = top
            };
            ccard.Left = left;
            ccard.Top = top;
            DrawCard(left, top, ccard);
            _playerCards.Add(ccard);
            left += _cardWidth + _cardSpacing;
        }
    }
    
    public void DrawOpponentCards(List<Build>? cards)
    {
        if (cards == null)
        {
            throw new ApplicationException("Opponent cards are null");
        }
        // int left = 10;
        
        int left = BoardWidth / 2 - (4 * _cardWidth + 3 * _cardSpacing) / 2;
        int top = 4;
        foreach (var card in cards)
        {
            //ConsoleBuild ccard = new ConsoleBuild(card.Cards[0], left, top, "OpponentCard");
            ConsoleBuild ccard = new ConsoleBuild()
            {
                Cards = { card.Cards[0] },
                Left = left,
                Top = top,
                Specialcard = "OpponentCard"
            };
            ccard.Left = left;
            ccard.Top = top;
            DrawCard(left, top, ccard);
            _opponentCards.Add(ccard);
            left += _cardWidth + _cardSpacing;
        }
    }
    
    public void DrawTableCards(List<Build>? cards)
    {
        if (cards == null)
        {
            throw new ApplicationException("Table cards are null");
        }
        // int left = 10;
        int left = BoardWidth / 2 - (5 * _cardWidth + 4 * _cardSpacing) / 2;
        int top = 12;
        for (int i = 0; i < 10; i++)
        {
            if (i == 5)
            {
                left = BoardWidth / 2 - (5 * _cardWidth + 4 * _cardSpacing) / 2;
                top += _cardHeight + 1;   
            }

            ConsoleBuild ccard;
            if (i < cards.Count)
            {
                //ccard = new ConsoleBuild(cards[i].Cards[0], left, top);
                ccard = new ConsoleBuild()
                {
                    Cards = { cards[i].Cards[0] },
                    Left = left,
                    Top = top,
                };
            }
            else
            {
                //ccard = new ConsoleBuild(new Card(), left, top, "EmptyCard");   
                ccard = new ConsoleBuild()
                {
                    Cards = { new Card() },
                    Left = left,
                    Top = top,
                    Specialcard = "EmptyCard"
                };
            }
            ccard.Left = left;
            ccard.Top = top;
            DrawCard(left, top, ccard);
            _tableCards.Add(ccard);
            left += _cardWidth + _cardSpacing;
        }
    }
    
    public void DrawCard(int left, int top, ConsoleBuild build, ConsoleColor color = ConsoleColor.Gray)
    {
        string[] correctCard = GetCorrectCard(build);
        Console.ForegroundColor = color;
        foreach (var c in correctCard)
        {
            Console.SetCursorPosition(left, top);
            Console.Write(c);
            top++;
        }
        
    }

    private string[] GetCorrectCard(ConsoleBuild build)
    {
        string[] correctCard = {};
        if (build.Specialcard != "none")
        {
            if (build.Specialcard == "OpponentCard")
            {
                return _opponentCard;
            } else if (build.Specialcard == "EmptyCard")
            {
                return _emptyCard;
            }
        }
        switch (build.Cards?[build.Cards.Count].Suit)
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
            throw new ApplicationException($"Unknown build {build}");
        }

        var characters = correctCard[1].ToCharArray();

        switch (build.Cards?[build.Cards.Count].Rank)
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