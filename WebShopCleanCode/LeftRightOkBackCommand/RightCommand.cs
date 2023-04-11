using WebShopCleanCode.Menus;
using WebShopCleanCode.MenuStates;

namespace WebShopCleanCode.LeftRightOkBackCommand;

public class RightCommand : IDirectionCommand
{
    public void Execute(MenuBase menu)
    {
        if (menu.currentChoice < menu.optionList.Count)
        {
            menu.currentChoice++;
        }
    }
}