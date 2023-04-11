using WebShopCleanCode.MenuStates;

namespace WebShopCleanCode.Command;

public class PrintInfoCommand : IImplementationCommand
{
    public void DoStuff()
    {
        MenuContext menuState = new MenuContext();
        var currentCustomer = menuState.GetCurrentCustomer();
        currentCustomer.PrintInfo();
    }
}