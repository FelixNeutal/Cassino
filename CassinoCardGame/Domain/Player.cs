namespace Domain;

public class Player
{
    public List<Build>? Hand { get; set; } = new List<Build>();
    public int TotalScore { get; set; } = 0;
}