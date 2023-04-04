using WebShopCleanCode;
using WebShopCleanCode.Command;
using WebShopCleanCode.Menus;

public class PurchaseMenuCommand : ICommand
{
    
    private PurchaseMenu _menu;
    private List<Product> products;
    
    public PurchaseMenuCommand(PurchaseMenu menu, List<Product> products) {
        _menu = menu;
        this.products = products;
    }
    
    public void Execute(Customer currentCustomer, ref int currentChoice, ref int amountOfOptions)
    {
        PurchaseWare(ref currentChoice, currentCustomer);
    }
    
    public void PurchaseWare(ref int currentChoice, Customer currentCustomer)
    {
        int index = currentChoice - 1;
        var product = products[index];
        if (product.InStock())
        {
            if (currentCustomer.CanAfford(product.Price))
            {
                currentCustomer.Funds -= product.Price;
                product.NrInStock--;
                currentCustomer.Orders.Add(new Order(product.Name, product.Price, DateTime.Now));
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