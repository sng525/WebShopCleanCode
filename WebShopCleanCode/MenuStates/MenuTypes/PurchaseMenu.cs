namespace WebShopCleanCode.MenuStates.MenuTypes;

public class PurchaseMenu : MenuBase
{
    public PurchaseMenu()
    {
        optionList = new List<string>();
        productList = new ProductList();
        currentMenu = "purchase menu";
        info = "What would you like to purchase?";
        currentChoice = 1;
    }

    public override void DisplayMenu()
    {
        if (MenuContext.GetInstance().currentCustomer != null)
        {
            Console.WriteLine(info);
            DisplayPurchaseList();
            MenuBar();
            CheckLogInStatus();
            AskChoice();
            DisplayMenu();
        }
        else
        {
            Console.WriteLine();
            Console.WriteLine("You must be logged in to purchase wares.");
            Console.WriteLine();
        }
    }
    
    public override void PurchaseWare()
    {
        int index = currentChoice - 1;
        var product = productList.products[index];
        if (product.InStock())
        {
            if (MenuContext.GetInstance().currentCustomer.CanAfford(product.Price))
            {
                MenuContext.GetInstance().currentCustomer.Funds -= product.Price;
                product.NrInStock--;
                MenuContext.GetInstance().currentCustomer.Orders
                    .Add(new Order(product.Name, product.Price, DateTime.Now));
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

    private void DisplayPurchaseList()
    {
        for (int i = 0; i < productList.products.Count; i++)
        {
            Console.WriteLine(i + 1 + ": " + productList.products[i].Name + ", " + productList.products[i].Price + "kr");
        }

        Console.WriteLine("Your funds: " + MenuContext.GetInstance().GetCurrentCustomer().Funds);
    }
}