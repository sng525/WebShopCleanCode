using WebShopCleanCode.Menu;
using WebShopCleanCode.MenuStates;

namespace WebShopCleanCode.Command.SortWaresMenuCommands;

public class SortByPriceAscending : IImplementationCommand
{
    public void DoStuff()
    {
        MenuBase menuType = new SortWaresMenu();
        menuType.bubbleSort("price", true);
        menuType.WareSortedNotification();
    }
}
