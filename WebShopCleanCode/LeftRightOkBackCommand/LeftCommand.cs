using WebShopCleanCode.Menus;

namespace WebShopCleanCode.LeftRightOkBackCommand;

public class LeftCommand : IDirectionCommand
{
    private IMenu _menu;

    public LeftCommand(IMenu menu)
    {
        _menu = menu;
    }

    public void Execute()
    {
        if (_menu.currentChoice > 1)
        {
            _menu.currentChoice--;
        }
    }
}