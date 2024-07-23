using System.Xml.Schema;

namespace MenuSystem;

public class Menu
{
    public List<MenuItem>? MenuItems { get; private set; } = new List<MenuItem>();
    public List<MenuItem>? SpecialMenuItems { get; private set; } = new List<MenuItem>();
    public EMenuLevel? MenuLevel { get; private set; }
    public string? Title { get; set; }
    private string MenuSeparator = "############################################";

    public Menu(string title, EMenuLevel level)
    {
        Title = title;
        MenuLevel = level;
    }

    public void AddMenuItems(List<MenuItem> items)
    {
        foreach (var item in items)
        {
            AddMenuItem(item);
        }
    }
    
    public void AddMenuItem(MenuItem item)
    {
        MenuItems?.Add(item);
    }

    public void RemoveMenuItem(MenuItem item)
    {
        MenuItems?.RemoveAt(MenuItems.FindIndex(a => a.Equals(item)));
    }
    
    public void Init()
    {
        MenuItem returnToPrevious = new MenuItem()
        {
            Shortcut = "R",
            Title = "Return",
            MethodToRun = null
        };
        MenuItem mainMenu = new MenuItem()
        {
            Shortcut = "M",
            Title = "Main Menu",
            MethodToRun = null
        };
        MenuItem exit = new MenuItem()
        {
            Shortcut = "E",
            Title = "Exit",
            MethodToRun = null
        };

        if (MenuLevel == EMenuLevel.First)
        {
            SpecialMenuItems?.Add(exit);
        } else if (MenuLevel == EMenuLevel.Second)
        {
            SpecialMenuItems?.Add(returnToPrevious);
            SpecialMenuItems?.Add(exit);
        }
        else if (MenuLevel == EMenuLevel.More)
        {
            SpecialMenuItems?.Add(mainMenu);
            SpecialMenuItems?.Add(returnToPrevious);
            SpecialMenuItems?.Add(exit);
        }
        else if (MenuLevel == EMenuLevel.None)
        {
        }
    }
    
    public string Run()
    {
        Console.WriteLine(MenuSeparator);
        Console.WriteLine(Title);
        Console.WriteLine(MenuSeparator);
        foreach (var item in MenuItems!)
        {
            Console.WriteLine(item);
        }
        Console.WriteLine(MenuSeparator);
        foreach (var item in SpecialMenuItems!)
        {
            Console.WriteLine(item);
        }

        string playerInput = "";
        do
        {
            Console.Write("Enter your choice: ");
            playerInput = Console.ReadLine()!.Trim().ToLower();
            if (IsShortcutInMenuList(MenuItems, playerInput))
            {
                
            }
        } while (!IsShortcutInMenuList(SpecialMenuItems, playerInput));
        return "";
    }

    protected string GetPlayerInput()
    {
        string playerInput = "";
        do
        {
            Console.Write("Enter your choice: ");
            playerInput = Console.ReadLine()!.Trim().ToLower();
        } while (!IsShortcutInMenuList(SpecialMenuItems, playerInput));
        return playerInput;
    }

    private bool IsShortcutInMenuList(List<MenuItem> items, string shortcut)
    {
        foreach (var item in items!)
        {
            if (item.Shortcut?.Trim().ToLower() == shortcut)
            {
                return true;
            }   
        }
        return false;
    }
}