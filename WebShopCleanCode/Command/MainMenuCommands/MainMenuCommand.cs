namespace WebShopCleanCode.Command;

public class MainMenuCommand : IMenuCommand
{
    private Dictionary<int, IImplementationCommand> commands;

    public MainMenuCommand()
    {
        commands = new Dictionary<int, IImplementationCommand>
        {
            { 1, new NavigateToWaresMenuCommand() },
            { 2, new NavigateToCustomerMenuCommand() },
            { 3, new NavigateToLoginMenuCommand() }
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