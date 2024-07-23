namespace Domain;

public class Card
{
    public ERank Rank { get; set; }
    public ESuit Suit { get; set; }
    public List<Card>? BuildCards { get; set; } = new List<Card>();
    public int HandValue { get; set; }
    public int TableValue { get; set; }
    public ECardType CardType { get; set; }
    public int  Left { get; set; }
    public int  Top { get; set; }
    public string[]? StringRepresentation { get; set; }

    public void AddBuildCard(Card card)
    {
        BuildCards!.Add(card);
    }

    public override string ToString()
    {
        return Rank.ToString() + Suit;
    }
}