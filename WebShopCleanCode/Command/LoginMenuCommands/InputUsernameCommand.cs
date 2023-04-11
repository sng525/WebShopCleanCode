using WebShopCleanCode.MenuStates;

namespace WebShopCleanCode.Command.LoginMenuCommands;

public class InputUsernameCommand : IImplementationCommand
{
    public void DoStuff()
    {
        MenuContext menuState = new MenuContext();
        var output = menuState.InputUserInfo("username");
        menuState.SetUsername(output);
    }
}