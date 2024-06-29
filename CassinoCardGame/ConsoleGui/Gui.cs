using Domain;

namespace ConsoleGui;

public class Gui
{
    private string[] HeartsCard = {" _____",
                                "| _ _ |",
                                "|( V )|",
                                "| \\ / |",
                                "|  .  |",
                                "|____H|"};
    private string[] DiamondsCard = {" _____",
                                  "|  ^  |",
                                  "| / \\ |",
                                  "| \\ / |",
                                  "|  .  |",
                                  "|____D|"};
    private string[] ClubsCard = {" _____",
                               "|  _  |",
                               "| ( ) |",
                               "|(_'_)|",
                               "|  |  |",
                               "|____C|"};
    private string[] SpadesCard = {" _____",
                                "|  .  |",
                                "| /.\\ |",
                                "|(_._)|",
                                "|  |  |",
                                "|____S|"};
    public void DrawCard(int x, int y, Card card, ConsoleColor color = ConsoleColor.Gray)
    {
        Console.SetCursorPosition(x, y);
    }

    public void Drawcard()
    {
        Console.WriteLine(HeartsCard);
        Console.WriteLine(DiamondsCard);
        Console.WriteLine(ClubsCard);
        Console.WriteLine(SpadesCard);
    }

    public void DrawTable()
    {
        string table = "    ------------------------------" +
                       "   /                              \\" +
                       "  /                                \\" +
                       " /                                  \\" +
                       "/                                    \\" +
                       "|                                      |" +
                       "|                                      |" +
                       "|                                      |" +
                       "|                                      |" +
                       "----------------------------------------";
        Console.Write(table);
    }
}