using System.Reflection.Metadata;

namespace MenuSystem;

public class ArrowMenu
{
    public List<MenuItem> MenuItems { get; set; } = new List<MenuItem>();
    public List<MenuItem> SpecialMenuItems { get; set; } = new List<MenuItem>();
    public List<string> ReservedShortcuts { get; set; } = new List<string>() {"E", "B", "M"};
    public Dictionary<int, MenuItem> MenuItemLocations { get; set; } = new Dictionary<int, MenuItem>();
    public string Title { get; set; } = default!;
    public EMenuLevel MenuLevel { get; set; }
    public string MenuSeparator { get; set; } = "============================================";

    public ArrowMenu(string title, EMenuLevel menuLevel)
    {
        Title = title;
        MenuLevel = menuLevel;
        Console.CursorVisible = false;
        GenerateSpecialMenuItems();
    }

    public void AddMenuItem(MenuItem item)
    {
        //  throw new ApplicationException($"Conflicting menu shortcut {item.ShortCut.ToUpper()}");
        if (ListContains(MenuItems, item.Shortcut) || ListContains(SpecialMenuItems, item.Shortcut))
        {
            throw new ApplicationException($"Conflicting menu shortcut {item.Shortcut.ToUpper()}");    
        }
        MenuItems.Add(item);
    }

    public void AddMenuItems(List<MenuItem> items)
    {
        foreach (var item in items)
        {
            AddMenuItem(item);
        }
    }

    public void DeleteMenuItem(MenuItem item)
    {
        if (!MenuItems.Contains(item))
        {
            throw new ApplicationException($"Menuitem {item} is not in list");
        }
        MenuItems.Remove(item);
    }
    
    public void DeleteSpecialMenuItem(MenuItem item)
    {
        if (!SpecialMenuItems.Contains(item))
        {
            throw new ApplicationException($"Menuitem {item} is not in list");
        }
        SpecialMenuItems.Remove(item);
    }

    private void GenerateSpecialMenuItems()
    {
        if (MenuLevel == EMenuLevel.Second)
        {
            SpecialMenuItems.Add(new MenuItem("B", "Back", null));    
        } else if (MenuLevel == EMenuLevel.More)
        {
            SpecialMenuItems.Add(new MenuItem("B", "Back", null));    
            SpecialMenuItems.Add(new MenuItem("M", "Main menu", null));    
        }
        SpecialMenuItems.Add(new MenuItem("E", "Exit", null));
    }
    
    public string Run()
    {
        string? playerInput = "";
        MenuItem selectedMenuItem = new MenuItem();
        Func<string>? runItem = null;
        do
        {
            DrawMenu();
            playerInput = GetPlayerInput();
            if (ListContains(MenuItems, playerInput))
            {
                selectedMenuItem = GetMenuItem(MenuItems, playerInput);
                runItem = selectedMenuItem.MethodToRun;
                if (runItem != null)
                {
                    playerInput = runItem();
                    if (playerInput == "B" || (playerInput == "M" && MenuLevel == EMenuLevel.First))
                    {
                        playerInput = "";
                    }
                }
            }
        } while (!ReservedShortcuts.Contains(playerInput));
        return playerInput;
    }

    private String GetPlayerInput()
    {
        ConsoleColor selectedColor = ConsoleColor.Yellow;
        ConsoleColor defaultColor = ConsoleColor.Gray;
        int[] positions = MenuItemLocations.Keys.ToArray();
        int currentIndex = 0;
        int previousIndex = 0;
        String input = "";
        bool inputFound = false;
        Console.SetCursorPosition(0, positions[currentIndex]);
        Console.ForegroundColor = selectedColor;
        Console.Write(MenuItemLocations[positions[currentIndex]]);
        ConsoleKey key;
        while (!inputFound)
        {
            key = Console.ReadKey().Key;
            if (key == ConsoleKey.UpArrow)
            {
                if (currentIndex > 0)
                {
                    previousIndex = currentIndex;
                    currentIndex--;
                }
            } else if (key == ConsoleKey.DownArrow)
            {
                if (currentIndex < MenuItemLocations.Count - 1)
                {
                    previousIndex = currentIndex;
                    currentIndex++;
                }
            } else if (key == ConsoleKey.Enter)
            {
                inputFound = true;
            }
            Console.SetCursorPosition(0, positions[previousIndex]);
            Console.ForegroundColor = defaultColor;
            Console.Write(MenuItemLocations[positions[previousIndex]]);
            
            Console.SetCursorPosition(0, positions[currentIndex]);
            Console.ForegroundColor = selectedColor;
            Console.Write(MenuItemLocations[positions[currentIndex]]);
            Console.ForegroundColor = defaultColor;
        }

        return MenuItemLocations[positions[currentIndex]].Shortcut;
    }

    private void DrawMenu()
    {
        Console.Clear();
        Console.WriteLine(MenuSeparator);
        Console.WriteLine(Title);
        Console.WriteLine(MenuSeparator);
        foreach (var item in MenuItems)
        {
            if (!MenuItemLocations.ContainsKey(Console.GetCursorPosition().Top))
            {
                MenuItemLocations.Add(Console.GetCursorPosition().Top, item);
            }
            Console.WriteLine(item);
        }
        Console.WriteLine();
        foreach (var item in SpecialMenuItems)
        {
            if (!MenuItemLocations.ContainsKey(Console.GetCursorPosition().Top))
            {
                MenuItemLocations.Add(Console.GetCursorPosition().Top, item);
            }
            Console.WriteLine(item);
        }
        Console.WriteLine(MenuSeparator);
    }

    public bool ListContains(List<MenuItem> items, string shortcut)
    {
        bool isFound = false;
        foreach (var item in items)
        {
            if (item.Shortcut.Equals(shortcut))
            {
                isFound = true;
                break;
            }
        }
        return isFound;
    }
    
    public MenuItem GetMenuItem(List<MenuItem> items, string shortcut)
    {
        MenuItem foundItem = new MenuItem();
        foreach (var item in items)
        {
            if (item.Shortcut.Equals(shortcut))
            {
                foundItem = item;
                break;
            }
        }
        return foundItem;
    }
}