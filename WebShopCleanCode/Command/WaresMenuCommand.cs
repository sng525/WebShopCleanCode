

using WebShopCleanCode;
using WebShopCleanCode.Command;
using WebShopCleanCode.Menu;
using WebShopCleanCode.Menus;

public class WaresMenuCommand : ICommand
{
    private IMenu _menu;
    
    public WaresMenuCommand(IMenu menu)
    {
        _menu = menu;
    }

    public void Execute()
    {
        switch (_menu.currentChoice)
        {
            case 1:
                _menu = new WaresMenu();
                SeeAllWares(_menu.productList.products);
                break;
            case 2:
                _menu = new PurchaseMenu();
                _menu.DisplayMenu();
                break;
            case 3:
                _menu = new SortWaresMenu();
                _menu.DisplayMenu();
                break;
            case 4:
                // TODO duplicated code but there is one different variable
                _menu = new LoginMenu();
                _menu.DisplayMenu();
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