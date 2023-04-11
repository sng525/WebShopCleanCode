using WebShopCleanCode.MenuStates;
using WebShopCleanCode.MenuStates.MenuTypes;

namespace WebShopCleanCode.Command.SortWaresMenuCommands;

public class SortByPriceDescending : IImplementationCommand
{
    public void DoStuff()
    {
        MenuBase menuType = new SortWaresMenu();
        // menuType.bubbleSort("price", false);
        menuType.QuickSortByName(menuType.productList.products, 0, menuType.productList.products.Count - 1, false);
        menuType.WareSortedNotification();
    }
}