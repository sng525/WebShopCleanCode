using WebShopCleanCode.MenuStates;

namespace WebShopCleanCode.Command.LoginMenuCommands;

public class InputUsernameCommand : IImplementationCommand
{
    public void DoStuff()
    {
        // var menuState = new MenuContext();
        var output = MenuContext.GetInstance().InputUserInfo("username");
        MenuContext.GetInstance().SetUsername(output);
    }
}