
using WebShopCleanCode;
using WebShopCleanCode.Command;
using WebShopCleanCode.Menu;
using WebShopCleanCode.Menus;

public class SortWaresMenuCommand : ICommand
{
    private IMenu _menu;

    public SortWaresMenuCommand(IMenu menu)
    {
        _menu = menu;
    }
    public void Execute()
    {
        bool back = true;
        switch (_menu.currentChoice)
        {
            case 1:
                bubbleSort("name", false);
                WareSortedNotification();
                break;
            case 2:
                bubbleSort("name", true);
                WareSortedNotification();
                break;
            case 3:
                bubbleSort("price", false);
                WareSortedNotification();
                break;
            case 4:
                bubbleSort("price", true);
                WareSortedNotification();
                break;
            default:
                back = false;
                WebShop.PrintDefaultMessage();
                break;
        }

        if (back)
        {
            _menu = new WaresMenu();
            _menu.DisplayMenu();
        }
    }
    
    public void bubbleSort(string variable, bool ascending)
    {
        if (variable.Equals("name"))
        {
            int length = _menu.productList.products.Count;
            for (int i = 0; i < length - 1; i++)
            {
                bool sorted = true;
                int length2 = length - i;
                for (int j = 0; j < length2 - 1; j++)
                {
                    if (ascending)
                    {
                        if (_menu.productList.products[j].Name.CompareTo(_menu.productList.products[j + 1].Name) < 0)
                        {
                            Product temp = _menu.productList.products[j];
                            _menu.productList.products[j] = _menu.productList.products[j + 1];
                            _menu.productList.products[j + 1] = temp;
                            sorted = false;
                        }
                    }
                    else
                    {
                        if (_menu.productList.products[j].Name.CompareTo(_menu.productList.products[j + 1].Name) > 0)
                        {
                            Product temp = _menu.productList.products[j];
                            _menu.productList.products[j] = _menu.productList.products[j + 1];
                            _menu.productList.products[j + 1] = temp;
                            sorted = false;
                        }
                    }
                }

                if (sorted == true)
                {
                    break;
                }
            }
        }
        else if (variable.Equals("price"))
        {
            int length = _menu.productList.products.Count;
            for (int i = 0; i < length - 1; i++)
            {
                bool sorted = true;
                int length2 = length - i;
                for (int j = 0; j < length2 - 1; j++)
                {
                    if (ascending)
                    {
                        if (_menu.productList.products[j].Price > _menu.productList.products[j + 1].Price)
                        {
                            Product temp = _menu.productList.products[j];
                            _menu.productList.products[j] = _menu.productList.products[j + 1];
                            _menu.productList.products[j + 1] = temp;
                            sorted = false;
                        }
                    }
                    else
                    {
                        if (_menu.productList.products[j].Price < _menu.productList.products[j + 1].Price)
                        {
                            Product temp = _menu.productList.products[j];
                            _menu.productList.products[j] = _menu.productList.products[j + 1];
                            _menu.productList.products[j + 1] = temp;
                            sorted = false;
                        }
                    }
                }

                if (sorted == true)
                {
                    break;
                }
            }
        }
    }
    
    public void WareSortedNotification()
    {
        Console.WriteLine();
        Console.WriteLine("Wares sorted.");
        Console.WriteLine();
    }
}