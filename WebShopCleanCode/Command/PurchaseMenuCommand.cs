using WebShopCleanCode.MenuStates;
using WebShopCleanCode.MenuStates.MenuTypes;

namespace WebShopCleanCode.Command;

public class PurchaseMenuCommand : IMenuCommand
{
    public void Execute(int currentChoice)
    {
        IMenu menuState = new PurchaseMenu();
        menuState.PurchaseWare();
    }
}