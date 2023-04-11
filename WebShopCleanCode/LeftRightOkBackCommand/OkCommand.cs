using System.Windows.Input;
using WebShopCleanCode.Command;
using WebShopCleanCode.Menu;
using WebShopCleanCode.Menus;
using WebShopCleanCode.MenuStates;
using ICommand = WebShopCleanCode.Command.IMenuCommand;

namespace WebShopCleanCode.LeftRightOkBackCommand;

public class OkCommand : IDirectionCommand
{
    private Dictionary<string, IMenuCommand> commandDict;
    
    public OkCommand()
    {
        commandDict = new Dictionary<string, IMenuCommand>();
        commandDict.Add("main menu", new MainMenuCommand());
        commandDict.Add("customer menu", new CustomerMenuCommand());
        commandDict.Add("sort menu", new SortWaresMenuCommand());
        commandDict.Add("wares menu", new WaresMenuCommand());
        commandDict.Add("login menu", new LogInMenuCommand());
        commandDict.Add("purchase menu", new PurchaseMenuCommand());
    }
    
    public void Execute(MenuBase menu)
    {
        if (commandDict.TryGetValue(menu.currentMenu, out var command))
        {
            command.Execute(menu.currentChoice);
        }
        else
        {
            MenuBase.PrintDefaultMessage();
        }
    }
    
}