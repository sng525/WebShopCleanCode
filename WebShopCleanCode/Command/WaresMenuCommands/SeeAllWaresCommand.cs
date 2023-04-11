using WebShopCleanCode.MenuStates;
using WebShopCleanCode.MenuStates.MenuTypes;

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