using WebShopCleanCode.Menu;

namespace WebShopCleanCode.Command;

public class MainMenuCommand : ICommand
{
    MenuBase _menu;

    public void Execute(Customer currentCustomer, ref int currentChoice, ref int amountOfOptions)
    {
        switch (currentChoice)
        {
            case 1:
                _menu = new WaresMenu();
                _menu.DisplayMenu(currentCustomer, ref amountOfOptions);
                currentChoice = 1;
                amountOfOptions = 4;
                // _menu.NavigateToAMenu(new WaresMenu());
                break;
            case 2:
                _menu = new CustomerMenu();
                _menu.DisplayMenu(currentCustomer, ref amountOfOptions);
                currentChoice = 1;
                amountOfOptions = 3;
                //_menu.NavigateToAMenu(new CustomerMenu());
                break;
            case 3:
                _menu = new LoginMenu();
                _menu.DisplayMenu(currentCustomer, ref amountOfOptions);
                currentChoice = 1;
                amountOfOptions = 4;
                // _menu.NavigateToAMenu(new LoginMenu());
                break;
            default:
                WebShop.PrintDefaultMessage();
                break;
        }
    }
}