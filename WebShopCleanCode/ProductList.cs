namespace WebShopCleanCode;

public class ProductList
{
    public List<Product> products = new List<Product>();
    Database database = new Database();
    Menu menu;

    public ProductList()
    {
        products = database.GetProducts();
    }
    
    public void GetProductList(Customer currentCustomer)
    {
        for (int i = 0; i < menu.amountOfOptions; i++)
        {
            Console.WriteLine(i + 1 + ": " + products[i].Name + ", " + products[i].Price + "kr");
        }

        Console.WriteLine("Your funds: " + currentCustomer.Funds);
    }

    public void PurchaseWare(Customer currentCustomer)
    {
        int index = menu.currentChoice - 1;
        Product product = products[index];
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
    
    public void SeeAllWares()
    {
        Console.WriteLine();
        foreach (Product product in products)
        {
            product.PrintInfo();
        }

        Console.WriteLine();
    }
}