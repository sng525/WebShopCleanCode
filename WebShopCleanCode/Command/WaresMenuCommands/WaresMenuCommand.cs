

using WebShopCleanCode;
using WebShopCleanCode.Command;
using WebShopCleanCode.Command.WaresMenuCommands;
using WebShopCleanCode.Menu;
using WebShopCleanCode.Menus;
using WebShopCleanCode.MenuStates;
using NavigateToLoginMenuCommand = WebShopCleanCode.Command.NavigateToLoginMenuCommand;

public class WaresMenuCommand : IMenuCommand
{
    private Dictionary<int, IImplementationCommand> commands;

    public WaresMenuCommand()
    {
        commands = new Dictionary<int, IImplementationCommand>
        {
            { 1, new SeeAllWaresCommand() },
            { 2, new NavigateToPurchaseMenuCommand() },
            { 3, new NavigateToSortWaresMenuCommand() },
            { 4, new NavigateToLoginMenuCommand() }
        };
    }

    public void Execute(int currentChoice)
    {
        if (commands.TryGetValue(currentChoice, out var command))
        {
            command.DoStuff();
        }
        else
        {
            MenuBase.PrintDefaultMessage();
        }
    }
    
        

}