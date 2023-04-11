using System.Windows.Input;
using WebShopCleanCode;
using WebShopCleanCode.Command;
using WebShopCleanCode.Command.SortWaresMenuCommands;
using WebShopCleanCode.Menu;
using WebShopCleanCode.MenuStates;

public class SortWaresMenuCommand : IMenuCommand
{
    private Dictionary<int, IImplementationCommand> commands;

    public SortWaresMenuCommand()
    {
        commands = new Dictionary<int, IImplementationCommand>
        {
            { 1, new SortByNameDescending() },
            { 2, new SortByNameAscending() },
            { 3, new SortByPriceDescending() },
            { 4, new SortByPriceAscending()}
        };
    }
    public void Execute(int currentChoice)
    {
        if (commands.TryGetValue(currentChoice, out var command))
        {
            command.DoStuff();
            
            MenuContext menuState = new MenuContext();
            menuState.SetState(new WaresMenu());
            menuState.Request();
        }
        else
        {
            MenuBase.PrintDefaultMessage();
        }
    }
}