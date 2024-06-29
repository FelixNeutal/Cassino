namespace Domain;

public class Card
{
    public ERank Rank { get; set; }
    public ESuit Suit { get; set; }

    public override string ToString()
    {
        return Rank.ToString() + Suit;
    }
}