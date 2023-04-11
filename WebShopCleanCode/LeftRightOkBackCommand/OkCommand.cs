using WebShopCleanCode.Command;
using WebShopCleanCode.Command.CustomerMenuCommands;
using WebShopCleanCode.Command.MainMenuCommands;
using WebShopCleanCode.Command.SortWaresMenuCommands;
using WebShopCleanCode.Command.WaresMenuCommands;
using WebShopCleanCode.MenuStates;
using ICommand = WebShopCleanCode.Command.IMenuCommand;

namespace WebShopCleanCode.LeftRightOkBackCommand;

public class OkCommand : IDirectionCommand
{
    private Dictionary<string, IMenuCommand> commandDict;
    
    public OkCommand()
    {
        commandDict = new Dictionary<string, IMenuCommand>
        {
            { "main menu", new MainMenuCommand() },
            { "customer menu", new CustomerMenuCommand() },
            { "sort menu", new SortWaresMenuCommand() },
            { "wares menu", new WaresMenuCommand() },
            { "login menu", new LogInMenuCommand() },
            { "purchase menu", new PurchaseMenuCommand() }
        };
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