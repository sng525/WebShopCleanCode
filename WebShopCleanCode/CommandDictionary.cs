using WebShopCleanCode.Command;
using WebShopCleanCode.LeftRightOkBackCommand;
using WebShopCleanCode.Menus;

namespace WebShopCleanCode;

public class CommandDictionary
{
    public IMenu menu;
    public Dictionary<(string currentMenu, int currentChoice), ICommand> menuCommandDictionary;
    public Dictionary<string, IDirectionCommand> directionCommandDict;
    List<Customer> customers;

    public CommandDictionary(IMenu menu, List<Customer> customers)
    {
        this.menu = menu;
        this.customers = customers;
        directionCommandDict = InitializeDirectionCommandDictionary();
    }

    private Dictionary<string, IDirectionCommand> InitializeDirectionCommandDictionary()
    {

        directionCommandDict.Add("left", new LeftCommand(menu));
        directionCommandDict.Add("l", new LeftCommand(menu));
            
        directionCommandDict.Add("right", new RightCommand(menu));
        directionCommandDict.Add("r", new RightCommand(menu));
            
        directionCommandDict.Add("ok", new OkCommand(menu, menuCommandDictionary));
        directionCommandDict.Add("k", new OkCommand(menu, menuCommandDictionary));
        directionCommandDict.Add("o", new OkCommand(menu, menuCommandDictionary));
            
        directionCommandDict.Add("back", new BackCommand(menu));
        directionCommandDict.Add("b", new BackCommand(menu));
            
        directionCommandDict.Add("quit", new QuitCommand());
        directionCommandDict.Add("q", new QuitCommand());
        return directionCommandDict;
    }

    private Dictionary<(string currentMenu, int currentChoice), ICommand> InitializeMenuCommandDictionary()
    {
        menuCommandDictionary.Add(("main menu", 1), new MainMenuCommand(menu));
        menuCommandDictionary.Add(("main menu", 2), new MainMenuCommand(menu));
        menuCommandDictionary.Add(("main menu", 3), new MainMenuCommand(menu));
            
        menuCommandDictionary.Add(("customer menu", 1), new CustomerMenuCommand(menu));
        menuCommandDictionary.Add(("customer menu", 2), new CustomerMenuCommand(menu));
        menuCommandDictionary.Add(("customer menu", 3), new CustomerMenuCommand(menu));
            
        menuCommandDictionary.Add(("sort menu", 1), new SortWaresMenuCommand(menu));
        menuCommandDictionary.Add(("sort menu", 2), new SortWaresMenuCommand(menu));
        menuCommandDictionary.Add(("sort menu", 3), new SortWaresMenuCommand(menu));
        menuCommandDictionary.Add(("sort menu", 4), new SortWaresMenuCommand(menu));
            
        menuCommandDictionary.Add(("wares menu", 1), new WaresMenuCommand(menu));
        menuCommandDictionary.Add(("wares menu", 2), new WaresMenuCommand(menu));
        menuCommandDictionary.Add(("wares menu", 3), new WaresMenuCommand(menu));
        menuCommandDictionary.Add(("wares menu", 4), new WaresMenuCommand(menu));
            
        menuCommandDictionary.Add(("login menu", 1), new LogInMenuCommand(menu, customers));
        menuCommandDictionary.Add(("login menu", 2), new LogInMenuCommand(menu, customers));
        menuCommandDictionary.Add(("login menu", 3), new LogInMenuCommand(menu, customers));
        menuCommandDictionary.Add(("login menu", 4), new LogInMenuCommand(menu, customers));
            
        menuCommandDictionary.Add(("purchase menu", 1), new PurchaseMenuCommand(menu));
        return menuCommandDictionary;
    }
}