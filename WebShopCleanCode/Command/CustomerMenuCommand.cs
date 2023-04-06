using WebShopCleanCode.Menu;
using WebShopCleanCode.Menus;

namespace WebShopCleanCode.Command;

public class CustomerMenuCommand : ICommand
{
    private IMenu _menu;

    public CustomerMenuCommand(IMenu menu)
    {
        _menu = menu;
    }

    public void Execute()
    {
        switch (_menu.currentChoice)
        {
            case 1:
                _menu.currentCustomer.PrintOrders();
                break;
            case 2:
                _menu.currentCustomer.PrintInfo();
                break;
            case 3:
                AddFund(_menu.currentCustomer);
                break;
            default:
                WebShop.PrintDefaultMessage();
                break;
        }
    }
    
    public void AddFund(Customer currentCustomer)
    {
        Console.WriteLine("How many funds would you like to add?");
        string amountString = Console.ReadLine();
        try
        {
            int amount = int.Parse(amountString);
            if (amount < 0)
            {
                Console.WriteLine();
                Console.WriteLine("Don't add negative amounts.");
                Console.WriteLine();
            }
            else
            {
                currentCustomer.Funds += amount;
                Console.WriteLine();
                Console.WriteLine(amount + " added to your profile.");
                Console.WriteLine();
            }
        }
        catch (FormatException e)
        {
            Console.WriteLine();
            Console.WriteLine("Please write a number next time.");
            Console.WriteLine();
        }
    }
    
}