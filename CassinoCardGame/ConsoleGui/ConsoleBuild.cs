using Domain;

namespace ConsoleGui;

public class ConsoleBuild
{
    public int Left { get; set; }
    public int Top { get; set; }
    public List<Card>? Cards { get; private set; }
    public string? Specialcard { get; set; }

    public ConsoleBuild(List<Card> cards, int left, int top, string SpecialCard = "none")
    {
        Cards = cards;
        Top = top;
        Left = left;
        Specialcard = SpecialCard;
    }
    
    public ConsoleBuild()
    {
    }
    
}