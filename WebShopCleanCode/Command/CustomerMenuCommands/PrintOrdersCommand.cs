using WebShopCleanCode.MenuStates;

namespace WebShopCleanCode.Command.CustomerMenuCommands;

public class PrintOrdersCommand : IImplementationCommand
{
    public void DoStuff()
    {
        var currentCustomer = MenuContext.GetInstance().GetCurrentCustomer();
        currentCustomer.PrintOrders();
    }
}