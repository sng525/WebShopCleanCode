using WebShopCleanCode.MenuStates;

namespace WebShopCleanCode.LeftRightOkBackCommand;

public interface IDirectionCommand
{
    void Execute(MenuBase menu);
}



