using WebShopCleanCode.MenuStates;
using WebShopCleanCode.MenuStates.MenuTypes;

namespace WebShopCleanCode.Command.SortWaresMenuCommands;

public class SortByNameDescending : IImplementationCommand
{
    public void DoStuff()
    {
        MenuBase menuType = new SortWaresMenu();
        // menuType.bubbleSort("name", false);
        menuType.QuickSortByName(menuType.productList.products, 0, menuType.productList.products.Count - 1, false);
        menuType.WareSortedNotification();
    }
}