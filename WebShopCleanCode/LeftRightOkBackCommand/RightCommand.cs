using WebShopCleanCode.MenuStates;

namespace WebShopCleanCode.LeftRightOkBackCommand;

public class RightCommand : IDirectionCommand
{
    public void Execute(MenuBase menu)
    {
        if (menu.currentMenu.Equals("purchase menu"))
        {
            if (menu.currentChoice < menu.productList.products.Count)
            {
                menu.currentChoice++;
            }
        }
        else
        {
            if (menu.currentChoice < menu.optionList.Count)
            {
                menu.currentChoice++;
            }
        }
    }
}