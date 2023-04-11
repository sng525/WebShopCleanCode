using WebShopCleanCode.MenuStates;

namespace WebShopCleanCode.Command.LoginMenuCommands;

public class InputPasswordCommand : IImplementationCommand
{
    public void DoStuff()
    {
        // var menuState = new MenuContext();
        var output = MenuContext.GetInstance().InputUserInfo("password");
        MenuContext.GetInstance().SetPassword(output);
    }
}