using WebShopCleanCode.Menu;
using WebShopCleanCode.Menus;
using WebShopCleanCode.MenuStates;

namespace WebShopCleanCode.Command;

public class NavigateToLoginMenuCommand : IImplementationCommand
{
    public void DoStuff()
    {
        IMenu menuState = new LoginMenu();
        menuState.DisplayMenu();
    }
}