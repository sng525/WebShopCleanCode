using WebShopCleanCode.MenuStates;
using WebShopCleanCode.MenuStates.MenuTypes;

namespace WebShopCleanCode.Command;

public class NavigateToWaresMenuCommand : IImplementationCommand
{
    public void DoStuff()
    {
        IMenu menuState = new WaresMenu();
        menuState.DisplayMenu();
    }
}