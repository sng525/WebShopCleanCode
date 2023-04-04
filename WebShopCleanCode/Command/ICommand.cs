using WebShopCleanCode.Menus;

namespace WebShopCleanCode.Command;

public interface ICommand
{
    void Execute(Customer currentCustomer, ref int currentChoice, ref int amountOfOptions);
}