using WebShopCleanCode.Menu;
using WebShopCleanCode.MenuStates;

namespace WebShopCleanCode.Command.SortWaresMenuCommands;

public class SortByPriceDescending : IImplementationCommand
{
    public void DoStuff()
    {
        MenuBase menuType = new SortWaresMenu();
        menuType.bubbleSort("price", false);
        menuType.WareSortedNotification();
    }
}