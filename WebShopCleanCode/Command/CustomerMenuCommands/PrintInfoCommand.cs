using WebShopCleanCode.MenuStates;

namespace WebShopCleanCode.Command.CustomerMenuCommands;

public class PrintInfoCommand : IImplementationCommand
{
    public void DoStuff()
    {
        var currentCustomer = MenuContext.GetInstance().GetCurrentCustomer();
        currentCustomer.PrintInfo();
    }
}