
using WebShopCleanCode;
using WebShopCleanCode.Command;
using WebShopCleanCode.Menu;

public class SortWaresMenuCommand : ICommand
{
    private MenuBase _menu;
    private List<Product> products;
    
    public SortWaresMenuCommand(SortWaresMenu menu, List<Product> products) {
        _menu = menu;
        this.products = products;
    }

    public void Execute(Customer currentCustomer, ref int currentChoice, ref int amountOfOptions)
    {
        bool back = true;
        switch (currentChoice)
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
            _menu.DisplayMenu(currentCustomer, ref amountOfOptions);
        }
    }
    
    
    public void bubbleSort(string variable, bool ascending)
    {
        if (variable.Equals("name"))
        {
            int length = products.Count;
            for (int i = 0; i < length - 1; i++)
            {
                bool sorted = true;
                int length2 = length - i;
                for (int j = 0; j < length2 - 1; j++)
                {
                    if (ascending)
                    {
                        if (products[j].Name.CompareTo(products[j + 1].Name) < 0)
                        {
                            Product temp = products[j];
                            products[j] = products[j + 1];
                            products[j + 1] = temp;
                            sorted = false;
                        }
                    }
                    else
                    {
                        if (products[j].Name.CompareTo(products[j + 1].Name) > 0)
                        {
                            Product temp = products[j];
                            products[j] = products[j + 1];
                            products[j + 1] = temp;
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
            int length = products.Count;
            for (int i = 0; i < length - 1; i++)
            {
                bool sorted = true;
                int length2 = length - i;
                for (int j = 0; j < length2 - 1; j++)
                {
                    if (ascending)
                    {
                        if (products[j].Price > products[j + 1].Price)
                        {
                            Product temp = products[j];
                            products[j] = products[j + 1];
                            products[j + 1] = temp;
                            sorted = false;
                        }
                    }
                    else
                    {
                        if (products[j].Price < products[j + 1].Price)
                        {
                            Product temp = products[j];
                            products[j] = products[j + 1];
                            products[j + 1] = temp;
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