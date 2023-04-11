using WebShopCleanCode.Menus;
using WebShopCleanCode.MenuStates;

namespace WebShopCleanCode.Command;

public class PrintOrdersCommand : IImplementationCommand
{
    public void DoStuff()
    {
        MenuContext menuState = new MenuContext();
        var currentCustomer = menuState.GetCurrentCustomer();
        currentCustomer.PrintOrders();
    }
}