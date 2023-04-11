namespace WebShopCleanCode;

public class ProductList
{
    public List<Product> products;
    Database database = new Database();

    public ProductList()
    {
        products = database.GetProducts();
    }
}