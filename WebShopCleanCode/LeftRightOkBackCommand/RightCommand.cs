using WebShopCleanCode.Menus;

namespace WebShopCleanCode.LeftRightOkBackCommand;

public class RightCommand : IDirectionCommand
{
    private IMenu _menu;

    public RightCommand(IMenu menu)
    {
        _menu = menu;
    }

    public void Execute()
    {
        if (_menu.currentChoice < _menu.amountOfOptions)
        {
            _menu.currentChoice++;
        }
    }
}