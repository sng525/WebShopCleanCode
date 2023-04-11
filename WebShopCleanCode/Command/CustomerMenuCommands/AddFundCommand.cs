using WebShopCleanCode.Menus;
using WebShopCleanCode.MenuStates;

namespace WebShopCleanCode.Command;

public class AddFundCommand : IImplementationCommand
{
    public void DoStuff()
    {
        var menuState = new MenuContext();
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
                var currentCustomer = menuState.GetCurrentCustomer();
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
