using WebShopCleanCode;
using WebShopCleanCode.Command;
using WebShopCleanCode.Command.LoginMenuCommands;
using WebShopCleanCode.Menu;
using WebShopCleanCode.Menus;
using WebShopCleanCode.MenuStates;

public class LogInMenuCommand : IMenuCommand
{
    private Dictionary<int, IImplementationCommand> commands;

    public LogInMenuCommand()
    {
        commands = new Dictionary<int, IImplementationCommand>
        {
            { 1, new InputUsernameCommand() },
            { 2, new InputPasswordCommand() },
            { 3, new UserLoginCommand() },
            { 4, new UserRegisterCommand() },
        };
    }

    public void Execute(int currentChoice)
    {
        if (commands.TryGetValue(currentChoice, out var command))
        {
            command.DoStuff();

            MenuContext menuState = new MenuContext();
            menuState.SetState(new LoginMenu());
            menuState.Request();
        }
        else
        {
            MenuBase.PrintDefaultMessage();
        }
    }
}