using WebShopCleanCode.Menu;
using WebShopCleanCode.Menus;

namespace WebShopCleanCode.Command;

public class MainMenuCommand : ICommand
{
    IMenu _menu;

    public MainMenuCommand(IMenu menu)
    {
        _menu = menu;
    }

    public void Execute()
    {
        switch (_menu.currentChoice)
        {
            case 1:
                _menu = new WaresMenu();
                _menu.DisplayMenu();
                break;
            case 2:
                _menu = new CustomerMenu();
                _menu.DisplayMenu();
                break;
            case 3:
                _menu = new LoginMenu();
                _menu.DisplayMenu();
                break;
            default:
                WebShop.PrintDefaultMessage();
                break;
        }
    }
}