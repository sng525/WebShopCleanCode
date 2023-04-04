using WebShopCleanCode.Menu;
using WebShopCleanCode.Menus;

namespace WebShopCleanCode.LeftRightOkBackCommand;

public class BackCommand : IDirectionCommand
{
    private MenuBase _menu;
    private readonly Customer _currentCustomer;

    public BackCommand(MenuBase menu, Customer currentCustomer)
    {
        _menu = menu;
        _currentCustomer = currentCustomer;
    }
    

    public int Execute(ref int currentChoice, ref int amountOfOptions, string currentMenu)
    {
        if (currentMenu.Equals("main menu"))
        {
            Console.WriteLine();
            Console.WriteLine("You're already on the main menu.");
            Console.WriteLine();
        }
        
        else if (currentMenu.Equals("purchase menu"))
        {;
            _menu = new WaresMenu();
            _menu.DisplayMenu(_currentCustomer, ref amountOfOptions);
        }
        else
        {
            _menu = new MainMenu();
            _menu.DisplayMenu(_currentCustomer, ref amountOfOptions);
        }

        return currentChoice;
    }
}