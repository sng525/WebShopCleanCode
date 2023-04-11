using WebShopCleanCode.MenuStates;
using WebShopCleanCode.MenuStates.MenuTypes;

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