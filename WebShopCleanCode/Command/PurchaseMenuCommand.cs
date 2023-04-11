using WebShopCleanCode.Command;
using WebShopCleanCode.Menus;

public class PurchaseMenuCommand : IMenuCommand
{
    public void Execute(int currentChoice)
    {
        IMenu menuState = new PurchaseMenu();
        menuState.SeeAllWares();
        menuState.PurchaseWare();
    }
}