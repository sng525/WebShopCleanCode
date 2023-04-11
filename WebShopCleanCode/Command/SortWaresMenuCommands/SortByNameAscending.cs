using WebShopCleanCode.Menu;
using WebShopCleanCode.MenuStates;

namespace WebShopCleanCode.Command.SortWaresMenuCommands;

public class SortByNameAscending: IImplementationCommand
{
    public void DoStuff()
    {
        MenuBase menuType = new SortWaresMenu();
        menuType.bubbleSort("name", true);
        menuType.WareSortedNotification();
    }
}