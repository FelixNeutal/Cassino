namespace Domain;

public class Player
{
    public string Name { get; set; } = "Player1";
    public List<Card>? Hand { get; set; } = new List<Card>();
    public List<Card>? CapturedCards { get; set; } = new List<Card>();
    public int TotalScore { get; set; } = 0;

    public void AddToCapturedCards(Card card)
    {
        CapturedCards!.Add(card);
    }
}