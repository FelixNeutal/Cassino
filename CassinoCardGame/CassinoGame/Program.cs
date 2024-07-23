// See https://aka.ms/new-console-template for more information

// using ConsoleGui;

using MenuSystem;

Menu menu = new Menu("First menu", EMenuLevel.First);
menu.AddMenuItems(new List<MenuItem>()
{
    new MenuItem()
    {
        Shortcut = "S",
        Title = "Start",
        MethodToRun = null
    },
    
    new MenuItem()
    {
        Shortcut = "T",
        Title = "Stop",
        MethodToRun = null
    },
});
menu.Init();
menu.Run();


