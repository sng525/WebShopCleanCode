using WebShopCleanCode.Menus;
using WebShopCleanCode.MenuStates;

namespace WebShopCleanCode.Command;

public class PrintOrdersCommand : IImplementationCommand
{
    public void DoStuff()
    {
        var currentCustomer = MenuContext.GetInstance().GetCurrentCustomer();
        currentCustomer.PrintOrders();
    }
}