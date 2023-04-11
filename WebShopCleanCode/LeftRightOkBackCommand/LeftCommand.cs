using WebShopCleanCode.Menus;
using WebShopCleanCode.MenuStates;

namespace WebShopCleanCode.LeftRightOkBackCommand;

public class LeftCommand :  IDirectionCommand
{
    public void Execute(MenuBase menu)
    {
        if (menu.currentChoice > 1)
        {
            menu.currentChoice--;
        }
    }
}