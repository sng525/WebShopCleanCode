using WebShopCleanCode.Menu;
using WebShopCleanCode.Menus;
using WebShopCleanCode.MenuStates;

namespace WebShopCleanCode.Command.WaresMenuCommands;

public class NavigateToSortWaresMenuCommand : IImplementationCommand
{
    public void DoStuff()
    {
        MenuContext menuState = new MenuContext();
        menuState.SetState(new SortWaresMenu());
        menuState.Request();
    }
}