using Domain;
using GameEngine;

namespace ConsoleGui;

public class Gui
{
    private static int _cardSpacing = 5;
    private static int _cardWidth = 9;
    private static int _cardHeight = 6;
    public static int BoardWidth { get; set; } = 74;
    public static int BoardHeight { get; set; } = 41;

    // Player card start point
    int playerLeft = 2;
    int playerTop = 28;
    // Opponent card start point
    int opponentLeft = BoardWidth / 2 - (4 * _cardWidth + 3 * _cardSpacing) / 2;
    int opponentTop = 4;
    // Table card start point
    int tableLeft = BoardWidth / 2 - (5 * _cardWidth + 4 * _cardSpacing) / 2;
    int tableTop = 12;   

    private Gui? ConsoleGui = null;

    private Gui GetInstance()
    {
        if (ConsoleGui == null)
        {
            ConsoleGui = new Gui();
        }

        return ConsoleGui;
    }
    
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

    public void DrawMenu(Card card)
    {
        int left = 58;
        int top = 28;
        Console.SetCursorPosition(left, top);
    }

    public void GetPlayerInput(List<Card> cards)
    {
        int currentCard = 0;
        int previousCard = 0;
        bool isTurnDone = false;
        ConsoleKey key;
        while (!isTurnDone)
        {
            //DrawCard(cards[previousCard].Left, cards[previousCard].Top, cards[previousCard]);
            //DrawCard(cards[currentCard].Left, cards[currentCard].Top, cards[currentCard], ConsoleColor.Yellow);
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
                if (currentCard < Game.Player!.Hand!.Count - 1)
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
            } else if (key == ConsoleKey.Escape)
            {
                //DrawCard(cards[currentCard].Left, cards[currentCard].Top, cards[currentCard]);
                //isTurnDone = true;
            }
        }
    }
}