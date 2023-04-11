using WebShopCleanCode.MenuStates;
using WebShopCleanCode.MenuStates.MenuTypes;

namespace WebShopCleanCode.Command.SortWaresMenuCommands;

public class SortByPriceAscending : IImplementationCommand
{
    public void DoStuff()
    {
        MenuBase menuType = new SortWaresMenu();
        // menuType.bubbleSort("price", true);
        menuType.QuickSortByPrice(menuType.productList.products, 0, menuType.productList.products.Count - 1, true);
        
        menuType.WareSortedNotification();
    }
}
