using WebShopCleanCode.Menu;
using WebShopCleanCode.MenuStates;

namespace WebShopCleanCode.Command.SortWaresMenuCommands;

public class SortByNameDescending : IImplementationCommand
{
    public void DoStuff()
    {
        MenuBase menuType = new SortWaresMenu();
        menuType.bubbleSort("name", false);
        menuType.WareSortedNotification();
    }
}