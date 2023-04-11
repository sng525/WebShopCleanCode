using WebShopCleanCode.Menu;
using WebShopCleanCode.Menus;
using WebShopCleanCode.MenuStates;

namespace WebShopCleanCode.Command.WaresMenuCommands;

public class SeeAllWaresCommand : IImplementationCommand
{
    public void DoStuff()
    {
        IMenu menuState = new WaresMenu();
        menuState.SeeAllWares();
        menuState.DisplayMenu();
    }
}