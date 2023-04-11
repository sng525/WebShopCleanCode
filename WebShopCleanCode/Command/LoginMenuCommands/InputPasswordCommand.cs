using WebShopCleanCode.MenuStates;

namespace WebShopCleanCode.Command.LoginMenuCommands;

public class InputPasswordCommand : IImplementationCommand
{
    public void DoStuff()
    {
        MenuContext menuState = new MenuContext();
        var output = menuState.InputUserInfo("password");
        menuState.SetPassword(output);
    }
}