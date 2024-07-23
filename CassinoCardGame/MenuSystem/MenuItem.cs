namespace MenuSystem;

public class MenuItem
{
    public string? Shortcut { get; set; } = default!;
    public string? Title { get; set; } = default!;
    public Func<string>? MethodToRun { get; set; } = null;
    public int Left { get; set; }
    public int Right { get; set; }

    public override string ToString()
    {
        return $"{Shortcut}) {Title}";
    }
}