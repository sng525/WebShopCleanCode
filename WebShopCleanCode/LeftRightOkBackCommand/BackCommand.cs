using WebShopCleanCode.Menu;
using WebShopCleanCode.Menus;

namespace WebShopCleanCode.LeftRightOkBackCommand;

public class BackCommand : IDirectionCommand
{
    private IMenu _menu;

    public BackCommand(IMenu menu)
    {
        _menu = menu;
    }

    public void Execute()
    {
        if (_menu.currentMenu.Equals("main menu"))
        {
            Console.WriteLine();
            Console.WriteLine("You're already on the main menu.");
            Console.WriteLine();
        }

        else if (_menu.currentMenu.Equals("purchase menu"))
        {
            ;
            _menu = new WaresMenu();
            _menu.DisplayMenu();
        }
        else
        {
            _menu = new MainMenu();
            _menu.DisplayMenu();
        }
    }
}