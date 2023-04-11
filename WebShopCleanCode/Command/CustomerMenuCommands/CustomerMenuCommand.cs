using WebShopCleanCode.MenuStates;
using WebShopCleanCode.MenuStates.MenuTypes;

namespace WebShopCleanCode.Command.CustomerMenuCommands;

public class CustomerMenuCommand : IMenuCommand
{
    private Dictionary<int, IImplementationCommand> commands;

    public CustomerMenuCommand()
    {
        commands = new Dictionary<int, IImplementationCommand>
        {
            { 1, new PrintOrdersCommand() },
            { 2, new PrintInfoCommand() },
            { 3, new AddFundCommand() }
        };
    }
    
    public void Execute(int currentChoice)
    {
        if (commands.TryGetValue(currentChoice, out var command))
        {
            command.DoStuff();
            
            MenuContext menuState = new MenuContext();
            menuState.SetState(new CustomerMenu());
            menuState.Request();
        }
        else
        {
            MenuBase.PrintDefaultMessage();
        }
    }
}