using WebShopCleanCode.Menu;
using WebShopCleanCode.Menus;
using WebShopCleanCode.MenuStates;

namespace WebShopCleanCode.Command;

public class NavigateToWaresMenuCommand : IImplementationCommand
{
    public void DoStuff()
    {
        IMenu menuState = new WaresMenu();
        menuState.DisplayMenu();
    }
}