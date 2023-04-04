

using WebShopCleanCode;
using WebShopCleanCode.Command;
using WebShopCleanCode.Menu;
using WebShopCleanCode.Menus;

public class WaresMenuCommand : ICommand
{
    private MenuBase _menu;
    private List<Product> products;

    public WaresMenuCommand(MenuBase menu, List<Product> products) 
    {
        _menu = menu;
        this.products = products;
    }

    public void Execute(Customer currentCustomer, ref int currentChoice, ref int amountOfOptions)
    {
        switch (currentChoice)
        {
            case 1:
                _menu = new WaresMenu();
                SeeAllWares(products);
                break;
            case 2:
                _menu = new CustomerMenu();
                _menu.DisplayMenu(currentCustomer, ref amountOfOptions);
                amountOfOptions = products.Count;
                currentChoice = 1;
                // _menu.NavigateToAMenu(new PurchaseMenu());
                break;
            case 3:
                _menu = new SortWaresMenu();
                _menu.DisplayMenu(currentCustomer, ref amountOfOptions);
                // _menu.NavigateToAMenu(new SortWaresMenu());
                break;
            case 4:
                // TODO duplicated code but there is one different variable
                _menu = new LoginMenu();
                _menu.DisplayMenu(currentCustomer, ref amountOfOptions);
                currentChoice = 1;
                // _menu.NavigateFromWaresMenuToLoginMenu(currentCustomer);
                break;
            case 5:
                break;
            default:
                WebShop.PrintDefaultMessage();
                break;
        }
    }
    
        
    public void SeeAllWares(List<Product> products)
    {
        Console.WriteLine();
        foreach (Product product in products)
        {
            product.PrintInfo();
        }

        Console.WriteLine();
    }
}