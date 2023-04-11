using WebShopCleanCode.MenuStates;
using WebShopCleanCode.MenuStates.MenuTypes;

namespace WebShopCleanCode.Command;

public class NavigateToCustomerMenuCommand : IImplementationCommand
{
    public void DoStuff()
    {
        IMenu menuState = new CustomerMenu();
        menuState.DisplayMenu();
    }
}