using WebShopCleanCode.Menus;

namespace WebShopCleanCode;

public class ProductList
{
    public List<Product> products;
    Database database = new Database();

    public ProductList()
    {
        products = database.GetProducts();
    }
    
    public void GetProductList(Customer currentCustomer, int amountOfOptions)
    {
        for (int i = 0; i < amountOfOptions; i++)
        {
            Console.WriteLine(i + 1 + ": " + products[i].Name + ", " + products[i].Price + "kr");
        }

        Console.WriteLine("Your funds: " + currentCustomer.Funds);
    }

}