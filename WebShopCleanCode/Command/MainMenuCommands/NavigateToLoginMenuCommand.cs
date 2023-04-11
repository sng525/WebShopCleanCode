using WebShopCleanCode.MenuStates;
using WebShopCleanCode.MenuStates.MenuTypes;

namespace WebShopCleanCode.Command;

public class NavigateToLoginMenuCommand : IImplementationCommand
{
    public void DoStuff()
    {
        IMenu menuState = new LoginMenu();

        if (MenuContext.GetInstance().GetCurrentCustomer() != null)
        {
            Console.WriteLine();
            Console.WriteLine(MenuContext.GetInstance().GetCurrentCustomer().Username + " logged out.");
            Console.WriteLine();
            MenuContext.GetInstance().SetCurrentCustomer(null);
            menuState = new MainMenu();
            menuState.DisplayMenu();
        }
        else
        {
            menuState.DisplayMenu();
        }
    }
}