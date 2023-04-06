using WebShopCleanCode;
using WebShopCleanCode.Command;
using WebShopCleanCode.Menus;

public class PurchaseMenuCommand : ICommand
{
    
    private IMenu _menu;
    
    public PurchaseMenuCommand(IMenu menu)
    {
        _menu = menu;
    }

    public void Execute()
    {
        PurchaseWare();
    }
    public void PurchaseWare()
    {
        int index = _menu.currentChoice - 1;
        var product = _menu.productList.products[index];
        if (product.InStock())
        {
            if (_menu.currentCustomer.CanAfford(product.Price))
            {
                _menu.currentCustomer.Funds -= product.Price;
                product.NrInStock--;
                _menu.currentCustomer.Orders.Add(new Order(product.Name, product.Price, DateTime.Now));
                Console.WriteLine();
                Console.WriteLine("Successfully bought " + product.Name);
                Console.WriteLine();
            }
            else
            {
                Console.WriteLine();
                Console.WriteLine("You cannot afford.");
                Console.WriteLine();
            }
        }
        else
        {
            Console.WriteLine();
            Console.WriteLine("Not in stock.");
            Console.WriteLine();
        }
    }
}