using WebShopCleanCode.MenuStates;
using WebShopCleanCode.MenuStates.MenuTypes;

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