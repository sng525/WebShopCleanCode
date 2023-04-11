using WebShopCleanCode.Menu;
using WebShopCleanCode.Menus;
using WebShopCleanCode.MenuStates;

namespace WebShopCleanCode.Command;

public class NavigateToCustomerMenuCommand : IImplementationCommand
{
    public void DoStuff()
    {
        IMenu menuState = new CustomerMenu();
        menuState.DisplayMenu();
    }
}