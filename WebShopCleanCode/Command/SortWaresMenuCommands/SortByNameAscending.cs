using WebShopCleanCode.MenuStates;
using WebShopCleanCode.MenuStates.MenuTypes;

namespace WebShopCleanCode.Command.SortWaresMenuCommands;

public class SortByNameAscending: IImplementationCommand
{
    public void DoStuff()
    {
        MenuBase menuType = new SortWaresMenu();
        // menuType.bubbleSort("name", true);
        menuType.QuickSortByName(menuType.productList.products, 0, menuType.productList.products.Count - 1, true);
        menuType.WareSortedNotification();
    }
}