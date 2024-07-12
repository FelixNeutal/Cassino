using ConsoleGui;
using Domain;
using GameEngine;

namespace Controller;

public class GameController
{
    public Player? Player { get; set; }
    public List<Player>? Opponents { get; set; }

    public Game? Game { get; set; }
    public Gui? Gui { get; set; }

    public GameController(Game game, Gui gui)
    {
        Game = game;
        Gui = gui;
        Player = new Player();
        Opponents = new List<Player>()
        {
            new Player()
        };
        Game = new Game()
        {
            Player = Player,
            Opponents = Opponents
        };
        Gui = new Gui();
    }

public void RunGame()
    {
        Gui!.InitBoard();
        Game!.DealStartCards();
        foreach (var h in Game.Opponents![0].Hand!)
        {
            Console.WriteLine(h.Cards);
        }
        //Gui.DrawOpponentCards(Game.Opponents![0].Hand);
        //Gui.DrawPlayerCards(Game.Player!.Hand);
        //Gui.DrawTableCards(Game.TableCards);
        
        //public void DrawCard(int x, int y, Cards card, ConsoleColor color = ConsoleColor.Gray)
        int i = 0;
        while (i < 3)
        {
            Gui.GetPlayerMove();
            i++;
        }
    }

    public bool IsValidMove(EGameMove move, Build b1, Build b2)
    {
        switch (move)
        {
            case EGameMove.Build:
                return Game!.CanBuild(b1, b2);
            case EGameMove.Call:
                return Game!.CanCall(b1, b2);
            case EGameMove.Capture:
                return Game!.CanCapture(b1, b2);
            case EGameMove.Combine:
                return Game!.CanCombine(b1, b2);
            case EGameMove.Trail:
                return Game!.CanTrail(b1);
        }

        return false;
    }
    
    public Build MakeAMove(EGameMove move, Build b1, Build b2)
    {
        Build b = new Build();
        switch (move)
        {
            case EGameMove.Build:
                break;
            case EGameMove.Call:
                break;
            case EGameMove.Capture:
                b = Game!.Capture(b1, b2);
                break;
            case EGameMove.Combine:
                break;
            case EGameMove.Trail:
                break;
        }

        return b;
    }
}